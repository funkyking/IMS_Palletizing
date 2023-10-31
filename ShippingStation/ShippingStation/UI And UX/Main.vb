Imports System.Windows.Documents
Imports QRCoder
Imports ZXing
Imports PdfSharp
Imports PdfSharp.Pdf
Imports ZXing.OneD
Imports PdfSharp.Drawing
Imports System.IO
Imports FxResources
Imports System.Linq.Expressions
Imports IronSoftware.Drawing
Imports System.Windows.Media
Imports System.Windows
Imports SixLabors.Fonts
Imports System.Windows.Forms
Imports Color = System.Drawing.Color
Imports MessageBox = System.Windows.MessageBox
Imports FlowDirection = System.Windows.Forms.FlowDirection
Imports Application = System.Windows.Forms.Application
Imports System.Data.SqlClient

Public Class Main

	Dim Pallet_Split = False
	Dim WorkOrder As String = ""
	Dim PoNumber As String = ""
	Dim SubGroup As String = ""
	Dim PalletNo As String = ""
	Dim Shift As String = ""
	Dim WorkOrderID As Guid
	Dim ContainerGUID As Guid
	Private connstr = ""
	Dim ISContainerNull = True




	Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		GlobalVariables.MainInstance = Me



		' Load Variables
		connstr = ReadValue("System", "SQLconnstr", IniPath)

		'Load Ui
		usr_lbl.Text = $"{GlobalVariables.Userlvl}: {GlobalVariables.UserName}"
		Panel3.BackColor = Color.FromArgb(47, 72, 88)
		Panel5.BackColor = Color.FromArgb(47, 72, 88)
		DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(47, 72, 88)
		DataGridView1.EnableHeadersVisualStyles = False

	End Sub





#Region "Pallet Inserting"

	' Check If MasterContainer Already Exist
	Private Function checkMasterContainerExistence(ByRef Input)
		Dim conn As New SqlConnection(connstr)
		Try
			conn.Open()
			If conn.State = ConnectionState.Open Then
				Dim Sqlcmd As New SqlCommand
				Sqlcmd.Connection = conn
				Sqlcmd.CommandText = "SELECT [Master Container ID], [Master Container Name],[Completed]
										FROM [CRICUT].[CUPID].[ContainerMaster]
										WHERE [Master Container Name] = '" & Input.ToString().Trim() & "'
										UNION
										SELECT CS.[Master Container ID], CS.[Master Container Name], CM.[Completed]
										FROM [CRICUT].[CUPID].[ContainerShipping] CS
										INNER JOIN [CRICUT].[CUPID].[ContainerMaster] CM
										ON CS.[Master Container ID] = CM.[Master Container ID]
										WHERE CS.[Master Container Name] = '" & Input.ToString().Trim() & "'"
				Dim ds = Sqlcmd.ExecuteReader()
				If ds.HasRows Then
					ds.Read()
					GlobalVariables.MasterContainerID = ds.GetValue(ds.GetOrdinal("Master Container ID"))
					GlobalVariables.ContainerName = ds.GetValue(ds.GetOrdinal("Master Container Name"))
					GlobalVariables.MasterContainerCompleted = ds.GetValue(ds.GetOrdinal("Completed"))

					ListBox1.Items.Clear()
					ListBox1.Items.Add($"ContainerID : {GlobalVariables.MasterContainerID}")
					ListBox1.Items.Add($"ContainerName : {GlobalVariables.ContainerName}")
					'MessageBox.Show(GlobalVariables.MasterContainerID.ToString())
					edit_btn.Visible = True
					Return True
				Else
					edit_btn.Visible = False
					Return False
				End If
			End If
		Catch ex As Exception
			ListBox1.Items.Clear()
			ListBox1.Items.Add(ex.Message)
			conn.Close()
		Finally
			conn.Close()
		End Try

	End Function

	Private Function newMasterItem()
		Try
			Dim ProceedStatus = False
			Dim serialNumber = masterBarcode_txtbx.Text


			' Check in Db to See if is Completed
			If splitMasterBarcodeInput(serialNumber) Then
				If CheckOrderMasterStatusComplete() Then
					If Not CheckDuplicateMasterBarcodeItem() Then
						ProceedStatus = True
					Else
						ProceedStatus = False
					End If
				Else
					If AddWoPallettoDbWoStatus() Then
						If Not CheckDuplicateMasterBarcodeItem() Then
							ProceedStatus = True
						Else
							ProceedStatus = False
						End If
					Else
						ListBox1.Items.Clear()
						ListBox1.Items.Add("MasterBarcode Is Incomplete")
					End If
				End If
			Else
				ProceedStatus = False
				'MessageBox.Show("Invalid Input")
			End If


			' If its scanning and palletizing is Complete Then Proceed
			If ProceedStatus Then
				Dim masterItem = New BarcodeItem()
				masterItem.BarcodeImage = createBarcodeImage(serialNumber)
				masterItem.BarcodeText = serialNumber
				masterItem.PalletNo = GlobalVariables.palletcounter

				' Create a new instance of your custom UserControl
				Dim listItem As New ListItem()
				listItem.itemid = masterItem.BarcodeText
				listItem.BarcodeImage = masterItem.BarcodeImage
				listItem.PalletCount = GlobalVariables.palletcounter

				Dim MBI As New MasterBarcodeItem()
				MBI.WorkOrderID = WorkOrderID
				MBI.WorkOrder = WorkOrder.Trim()
				MBI.PoNumber = PoNumber.Trim()
				MBI.SubGroup = SubGroup.Trim()
				MBI.PalletNo = PalletNo.Trim()
				MBI.Shift = Shift.Trim()


				AddItemtoDbContainer(WorkOrderID.ToString(), WorkOrder.ToString(), SubGroup.ToString(), PalletNo.ToString(), Shift.ToString())


				' Add item to Datagridview
				DataGridView1.Rows.Add(masterItem.PalletNo, masterItem.BarcodeText)


				' Determine whether to switch the flow direction
				If FlowLayoutPanel1.Controls.Count > 0 AndAlso FlowLayoutPanel1.Controls(0).Bottom + listItem.Height > FlowLayoutPanel1.Height Then
					FlowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight
				End If


				' Add the UserControl to the FlowLayoutPanel
				FlowLayoutPanel1.Controls.Add(listItem)

				'Add the item the the barcode list And MasterBarcodeItemList
				GlobalVariables.MasterList.Add(masterItem)
				GlobalVariables.MasterBarcodeItemList.Add(MBI)

				'Add Pallet Counter by 1 once adding the item
				If FlowLayoutPanel1.Controls.Count > GlobalVariables.palletcounter Then
					GlobalVariables.palletcounter += 1
				End If
				ItemCounter_lbl.Text = $"Items: {GlobalVariables.palletcounter}"

				If containerStatus_lbl.Text.Contains("New") And FlowLayoutPanel1.Controls.Count > 0 And (GlobalVariables.MasterBarcodeItemList.Count > 0 Or GlobalVariables.MasterList.Count > 0) Then
					containerStatus_lbl.Text = "In Progress"
					containerStatus_lbl.ForeColor = Color.Green
				End If

				'If all goes well Clear textbox
				masterBarcode_txtbx.Clear()
				masterBarcode_txtbx.Text = ""
			End If

		Catch ex As Exception
			'MessageBox.Show(ex.Message)
		End Try
	End Function

	' Split the input into [Work Order],[Po Number],[Sub Group],[Pallet No],[Shift]
	Public Function splitMasterBarcodeInput(ByRef Input)
		Try
			Dim strSplit() As String = Input.Split(",")
			If strSplit.Length >= 5 Then
				WorkOrder = strSplit(0).Trim()
				PoNumber = strSplit(1).Trim()
				SubGroup = strSplit(2).Trim()
				PalletNo = strSplit(3).Trim()
				Shift = strSplit(4).Trim()
				Return True
			Else
				ListBox1.Items.Clear()
				ListBox1.Items.Add("Invalid MasterBarcode")
				Return False
			End If
		Catch ex As Exception
			Return False
		End Try
	End Function

	'Check Completion of Pallet in [WorkOrderMaster] and [WorkOrder]
	Private Function checkIfMasterBarcodeIsCompleted()
		Dim Conn = New SqlConnection(connstr)
		Try
			Conn.Open()
			If Conn.State = ConnectionState.Open Then
				Dim SQLcmd As New SqlCommand
				SQLcmd.Connection = Conn
				SQLcmd.CommandText = "SELECT Top 100
										wm.[Work Order]
										,wm.[Sub Group]
										,wo.[Pallet No]
										,wo.[Shift]
										,wo.[Serial No]
										,wm.[Work Order ID]
										,wm.[Completed]

										FROM [CRICUT].[CUPID].[WorkOrderMaster] wm
										INNER JOIN [CRICUT].[CUPID].[WorkOrder] wo
										ON wm.[Work Order ID] = wo.[Work Order ID]
										Where wm.[Completed] = '1' 
										AND wm.[Work Order] = '" & WorkOrder & "'
										AND wm.[Sub Group] = '" & SubGroup & "'
										AND wo.[Pallet No] = '" & PalletNo & "'
										AND wo.[Shift] = '" & Shift & "'"

				Dim ds = SQLcmd.ExecuteReader
				If ds.HasRows Then
					ds.Read()
					WorkOrderID = ds.GetValue(ds.GetOrdinal("Work Order ID"))
					Return True
					Conn.Close()
				Else
					Return False
					Conn.Close()
				End If
			End If
		Catch ex As Exception
			'MessageBox.Show(ex.Message)
			Conn.Close()
			Return False
		End Try
	End Function

	'Check Completion of Pallet in [WorkOrderStatus]
	Private Function CheckOrderMasterStatusComplete()
		Dim conn As New SqlConnection(connstr)
		Try
			conn.Open()
			If conn.State = ConnectionState.Open Then
				Dim SQLcmd As New SqlCommand
				SQLcmd.Connection = conn
				SQLcmd.CommandText = $"SELECT DISTINCT
										wos.[Work Order ID],wos.[Work Order],wom.[Po Number],wos.[Sub Group],[Pallet No],[Shift],[PalletScanCompleted],[PalletizingCompleted]
										FROM [CRICUT].[CUPID].[WorkOrderStatus] wos
										INNER JOIN [CRICUT].[CUPID].[WorkOrderMaster] wom ON wos.[Work Order ID] = wom.[Work Order ID]
										WHERE wos.[Work Order] = '" & WorkOrder.Trim() & "'
										AND wos.[Sub Group] = '" & SubGroup.Trim() & "'
										AND wos.[Pallet No] = '" & PalletNo.Trim() & "'
										AND [PalletizingCompleted] = 1"
				Dim ds = SQLcmd.ExecuteReader()
				If ds.HasRows Then
					ds.Read()
					WorkOrderID = ds.GetValue(ds.GetOrdinal("Work Order ID"))
					conn.Close()
					Return True
				Else
					'MessageBox.Show($"{WorkOrder},{SubGroup},{PalletNo},{Shift}")
					Return False
					conn.Close()
				End If
			End If
		Catch ex As Exception
			'MessageBox.Show(ex.Message)
			conn.Close()
			Return False
		End Try
	End Function

	Private Function AddWoPallettoDbWoStatus()
		Dim conn As New SqlConnection(connstr)
		Try
			conn.Open()
			If conn.State = ConnectionState.Open Then
				Dim check_query = "SELECT DISTINCT 
										  wo.[Work Order ID]
										  ,wom.[Work Order]
										  ,wom.[Sub Group]
										  ,wop.[Pallet No]
										  ,wo.[Shift]
									  FROM [CRICUT].[CUPID].[WorkOrder] wo
									  INNER JOIN [CRICUT].[CUPID].[WorkOrderPalletizing] wop ON wo.[Work Order ID] = wop.[Work Order ID]
									  INNER JOIN [CRICUT].[CUPID].[WorkOrderMaster] wom ON wo.[Work Order ID] = wom.[Work Order ID]
									  WHERE wom.[Work Order] = '" & WorkOrder.Trim() & "'
									  AND wom.[Sub Group] = '" & SubGroup.Trim() & "'
									  AND wop.[Pallet No] = '" & PalletNo.Trim() & "'"
				Using check_cmd As New SqlCommand(check_query, conn)
					Dim ds = check_cmd.ExecuteReader()
					If Not ds.HasRows Then
						Return False
					End If
					ds.Close()
				End Using

				'(31/10/2023) added by Paul
				Dim insert_query As String = "MERGE INTO [CRICUT].[CUPID].[WorkOrderStatus] AS Target
												USING (VALUES (
													'" & WorkOrderID.ToString().Trim() & "',
													'" & WorkOrder.Trim() & "',
													'" & SubGroup.Trim() & "',
													'" & PalletNo.Trim() & "',
													'" & Shift.Trim() & "',
													'1',
													'1',
													GETDATE(),
													'0'
												)) AS Source ([Work Order ID], [Work Order], [Sub Group], [Pallet No], [Shift], [PalletScanCompleted], [PalletizingCompleted], [Modified Date], [Delete])
												ON Target.[Work Order ID] = Source.[Work Order ID] AND Target.[Pallet No] = Source.[Pallet No]
												WHEN MATCHED THEN
													UPDATE SET [PalletScanCompleted] = '1', [PalletizingCompleted] = '1', [Modified Date] = GETDATE()
												WHEN NOT MATCHED THEN
													INSERT ([Work Order ID], [Work Order], [Sub Group], [Pallet No], [Shift], [PalletScanCompleted], [PalletizingCompleted], [Modified Date], [Delete])
													VALUES (Source.[Work Order ID], Source.[Work Order], Source.[Sub Group], Source.[Pallet No], Source.[Shift], Source.[PalletScanCompleted], Source.[PalletizingCompleted], Source.[Modified Date], Source.[Delete]);"

				Using Insert_cmd As New SqlCommand(insert_query, conn)
					Dim status = Insert_cmd.ExecuteNonQuery()
					If status > 0 Then
						Return True
					Else
						Return False
					End If
				End Using

			End If
		Catch ex As Exception
			conn?.Close()
			Return False
		Finally
			conn?.Close()
		End Try
    End Function


	'Check If there is a duplicate Existence
	Private Function CheckDuplicateMasterBarcodeItem()
		Try

			For Each item In GlobalVariables.MasterBarcodeItemList
				If item.WorkOrderID = WorkOrderID And item.WorkOrder = WorkOrder And
					item.SubGroup = SubGroup And item.PalletNo = PalletNo And
					item.Shift = Shift Then
					ListBox1.Items.Clear()
					ListBox1.Items.Add("MasterBarcode Already in this Container")
					Return True
				End If
			Next

			Dim conn As New SqlConnection(connstr)
			conn.Open()
			Try
				If conn.State = ConnectionState.Open Then
					Dim query = "SELECT [Master Container Name],[Work Order ID],[Work Order],
								  [Sub Group],[Pallet No],[Shift]
								  FROM [CRICUT].[CUPID].[ContainerShipping]
								  WHERE [Work Order ID] = '" & WorkOrderID.ToString() & "' AND [Work Order] = '" & WorkOrder & "'
								  AND [Sub Group] = '" & SubGroup & "' AND [Pallet No] = '" & PalletNo & "' AND [Shift] = '" & Shift & "'"
					Using sqlcmd As New SqlCommand(query, conn)
						Dim ds = sqlcmd.ExecuteReader()
						If ds.HasRows Then
							While ds.Read
								Dim cname = ""
								Try
									cname = ds.Item("Master Container Name")
								Catch ex As Exception
								End Try
								ListBox1.Items.Clear()
								ListBox1.Items.Add("Master Barcode Already Used in :")
								ListBox1.Items.Add($"Container : {cname}")
								Return True
							End While
						End If
					End Using
				End If
			Catch ex As Exception
				conn?.Close()
			Finally
				conn?.Close()
			End Try
			Return False
		Catch ex As Exception
			Return True
		End Try
	End Function


	Private Function AddItemtoDbContainer(ByVal WID, ByVal WO, ByVal SG, ByVal PN, ByVal SFT) As Boolean
		Dim conn As New SqlConnection(connstr)
		conn.Open()
		Try
			If conn.State = ConnectionState.Open Then
				' Check if the item exists in the database
				Dim checkQuery As String = "SELECT COUNT(*) FROM [CRICUT].[CUPID].[ContainerShipping] 
											WHERE [Master Container ID] = @MCID
											AND [Master Container Name] = @MCN
											AND [Work Order ID] = @WID 
											AND [Work Order] = @WO 
											AND [Sub Group] = @SG 
											AND [Pallet No] = @PN 
											AND [Shift] = @SFT"

				Dim cmdCheck As New SqlCommand(checkQuery, conn)
				cmdCheck.Parameters.AddWithValue("@MCID", GlobalVariables.MasterContainerID)
				cmdCheck.Parameters.AddWithValue("@MCN", GlobalVariables.ContainerName.Trim())
				cmdCheck.Parameters.AddWithValue("@WID", WID)
				cmdCheck.Parameters.AddWithValue("@WO", WO)
				cmdCheck.Parameters.AddWithValue("@SG", SG)
				cmdCheck.Parameters.AddWithValue("@PN", PN)
				cmdCheck.Parameters.AddWithValue("@SFT", SFT)

				Dim rowCount As Integer = CInt(cmdCheck.ExecuteScalar())

				' If the item doesn't exist, insert it
				If rowCount = 0 Then
					Dim Sqlcmd As New SqlCommand
					Sqlcmd.Connection = conn
					Sqlcmd.CommandText = "INSERT INTO [CRICUT].[CUPID].[ContainerShipping]
						([Loading ID]
							  ,[Master Container ID]
							  ,[Master Container Name]
							  ,[Work Order ID]
							  ,[Work Order]
							  ,[Sub Group]
							  ,[Pallet No]
							  ,[Shift]
							  ,[UserID]
							  ,[Date]
							  ,[IsDeleted])
						VALUES (NEWID(), '" & GlobalVariables.MasterContainerID.ToString() & "', 
											'" & GlobalVariables.ContainerName.Trim() & "' , '" & WID & "', 
											'" & WO & "' ,'" & SG & "', 
											'" & PN & "','" & SFT & "', '" & GlobalVariables.UserID & "', 
											'" & DateTime.Now & "', 0)"

					Sqlcmd.ExecuteNonQuery()
					Return True
				Else
					' Item already exists in the database
					ListBox1.Items.Clear()
					ListBox1.Items.Add("Item already exists in the database.")
					Return False
				End If
			End If
		Catch ex As Exception
			ListBox1.Items.Clear()
			ListBox1.Items.Add(ex.Message)
			Return False
		Finally
			conn?.Close()
		End Try
	End Function


	Public Function UpdateMasterContainerStatus(ByVal NewEntry As Boolean, ByVal CompleteStatus As Boolean)
		Dim conn As New SqlConnection(connstr)
		Try
			conn.Open()
			If conn.State = ConnectionState.Open Then

				If NewEntry Then
					Dim NewEntryQuery = "INSERT INTO [CRICUT].[CUPID].[ContainerMaster]
										([Master Container ID], [Master Container Name], [Completed], [UserID], [Date], [IsDeleted])
										SELECT
											'" & GlobalVariables.MasterContainerID.ToString() & "',
											'" & GlobalVariables.ContainerName.Trim() & "',
											0,
											'" & GlobalVariables.UserID & "',
											GETDATE(),
											0
										WHERE NOT EXISTS (
											SELECT 1
											FROM [CRICUT].[CUPID].[ContainerMaster]
											WHERE [Master Container ID] = '" & GlobalVariables.MasterContainerID.ToString() & "'
											OR [Master Container Name] = '" & GlobalVariables.ContainerName.Trim() & "'
										);"
					Dim SQLcmd As New SqlCommand(NewEntryQuery, conn)
					SQLcmd.ExecuteNonQuery()
				End If

				If CompleteStatus Then
					Dim CompleteQuery As String = "UPDATE [CRICUT].[CUPID].[ContainerMaster]
										SET [Completed] = 1,
											[Date] = GETDATE()
										WHERE [Master Container ID] = '" & GlobalVariables.MasterContainerID.ToString() & "'
										AND [Master Container Name] = '" & GlobalVariables.ContainerName.Trim() & "';

										IF @@ROWCOUNT = 0
										BEGIN
											INSERT INTO [CRICUT].[CUPID].[ContainerMaster]
											([Master Container ID], [Master Container Name], [Completed], [UserID], [Date], [IsDeleted])
											VALUES
											('" & GlobalVariables.MasterContainerID.ToString() & "', '" & GlobalVariables.ContainerName.Trim() & "', 1, '" & GlobalVariables.UserID & "', GETDATE(), 0);
										END"
					Dim SQLcmd As New SqlCommand(CompleteQuery, conn)
					SQLcmd.ExecuteNonQuery()
				End If
				Return True
			End If
		Catch ex As Exception
			conn?.Close()
			Return False
		Finally
			conn?.Close()
		End Try
	End Function

	' Final Insert All Values to [CUPID].[ContainerShipping]
	Private Sub insertToDB()

		For Each item As MasterBarcodeItem In GlobalVariables.MasterBarcodeItemList
			Dim Conn = New SqlConnection(connstr)
			Try
				Conn.Open()
				If Conn.State = ConnectionState.Open Then
					Dim cmd As New SqlCommand
					cmd.Connection = Conn
					cmd.CommandText = "Insert INTO [CRICUT].[CUPID].[ContainerShipping]
						([Loading ID]
							  ,[Master Container ID]
							  ,[Master Container Name]
							  ,[Work Order ID]
							  ,[Work Order]
							  ,[Sub Group]
							  ,[Pallet No]
							  ,[Shift]
							  ,[UserID]
							  ,[Date]
							  ,[IsDeleted])
						VALUES (NEWID(), '" & GlobalVariables.MasterContainerID.ToString() & "', 
											'" & GlobalVariables.ContainerName.Trim() & "' , '" & item.WorkOrderID.ToString() & "', 
											'" & item.WorkOrder & "' ,'" & item.SubGroup & "', 
											'" & item.PalletNo & "','" & item.Shift & "', '" & GlobalVariables.UserID & "', 
											'" & DateTime.Now & "', 0)"
					cmd.ExecuteNonQuery()
				End If

			Catch ex As Exception
				Conn.Close()
				MessageBox.Show(ex.Message)
			End Try
		Next
	End Sub


	Public Function RemoveFromListsByCriteria(ByVal workOrder As String, ByVal subGroup As String, ByVal palletNo As Integer, ByVal shift As String) As Boolean
		Try
			' Find the index of the item to remove in both lists
			Dim indexToRemove As Integer = -1

			For i As Integer = 0 To GlobalVariables.MasterList.Count - 1
				Dim barcodeItem As BarcodeItem = GlobalVariables.MasterList(i)
				Dim masterBarcodeItem As MasterBarcodeItem = GlobalVariables.MasterBarcodeItemList(i)

				' Check if the criteria matches
				If barcodeItem.BarcodeText = $"{workOrder},{PoNumber},{subGroup},{palletNo},{shift}" Then
					indexToRemove = i
					Exit For
				End If
			Next

			' Remove the item from both lists if found
			If indexToRemove <> -1 Then
				GlobalVariables.MasterList.RemoveAt(indexToRemove)
				GlobalVariables.MasterBarcodeItemList.RemoveAt(indexToRemove)
				Return True ' Item removed successfully
			Else
				Return False ' Item not found
			End If
		Catch ex As Exception
			' Handle exceptions if needed
			Return False
		End Try
	End Function

	Public Function RemoveFromDB(ByVal SerialNoInput)
		Try
			If splitMasterBarcodeInput(SerialNoInput) Then
				If RemoveFromListsByCriteria(WorkOrder, SubGroup, PalletNo, Shift) Then
					GlobalVariables.palletcounter -= 1
					ItemCounter_lbl.Text = GlobalVariables.palletcounter

					Dim conn As New SqlConnection(connstr)

					Try
						conn.Open()

						If conn.State = ConnectionState.Open Then
							Dim sqlcmd As New SqlCommand()
							sqlcmd.Connection = conn
							sqlcmd.CommandText = "DELETE FROM [CRICUT].[CUPID].[ContainerShipping]
												   WHERE [Master Container ID] = '" & GlobalVariables.MasterContainerID.ToString().Trim() & "'
												   AND [Work Order] = '" & WorkOrder & "'
												   AND [Sub Group] = '" & SubGroup & "'
												   AND [Pallet No] = '" & PalletNo & "'
												   AND [Shift] = '" & Shift & "';
													
													DELETE FROM [CRICUT].[CUPID].[ContainerSplit]
													WHERE [Master Container ID] = '" & GlobalVariables.MasterContainerID.ToString().Trim() & "'
													AND [Work Order] = '" & WorkOrder & "'
													AND [Sub Group] = '" & SubGroup & "'
													AND [Pallet No] = '" & PalletNo & "'
													AND [Shift] = '" & Shift & "';"
							Dim rowsAffected As Integer = sqlcmd.ExecuteNonQuery()
							If rowsAffected > 0 Then
								Return True ' Rows deleted successfully
							Else
								Return False ' No rows matching the criteria were found
							End If
						End If
					Catch ex As Exception
						ListBox1.Items.Clear()
						ListBox1.Items.Add(ex.Message)
						Return False
					Finally
						conn?.Close()
					End Try

				End If
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
	End Function
#End Region




#Region "Generate Qr and Barcode"

	'Generates Barcode Image
	Private Function createBarcodeImage(ByVal input)
		Try
			Dim barcode = New BarcodeWriter()
			barcode.Format = BarcodeFormat.CODE_128
			Dim bimg = barcode.Write(input)
			Return bimg
		Catch ex As Exception
			Return Nothing
		End Try
	End Function

	' Generates QrImage
	Private Function createQrImage(ByVal input)
		Try

			Dim qrGen As New QRCodeGenerator()
			Dim qrdata = qrGen.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q)
			Dim qrCode As New QRCode(qrdata)
			Dim qrImg = qrCode.GetGraphic(6)
			Return qrImg

		Catch ex As Exception
			Return Nothing
		End Try
	End Function

#End Region

#Region "Generate Docs (pqf, excel, etc..)"


	' Generates All Documents
	Private Sub generateAllDocs_btn_Click(sender As Object, e As EventArgs)

	End Sub

	' Function to Generate a PDF
	Private Function CreatePdf()
		Try
			Dim resultfolder As String = Path.Combine(Application.StartupPath, "Results")
			Dim outputPath As String = Path.Combine(resultfolder, $"{containerNo_txtbx.Text}.pdf")

			If Not Directory.Exists(resultfolder) Then
				Directory.CreateDirectory(resultfolder)
			ElseIf File.Exists(outputPath) Then
				Dim res As DialogResult = MessageBox.Show("This PDF already exists. Do you want to overwrite it?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

				If res = DialogResult.Yes Then
					File.Delete(outputPath)
				Else
					Return Nothing
				End If
			End If

			Dim document As New PdfDocument()
			Dim page As PdfPage = document.AddPage()
			Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
			Dim pdfWidth As Double = page.Width.Point
			Dim pdfHeight As Double = page.Height.Point

			' Set up font and size for header and text
			Dim headerFont As XFont = New XFont("Bahnschrift Condensed", 24, XFontStyle.Bold)
			Dim containerNoFont As XFont = New XFont("Bahnschrift Semilight Condensed", 18, XFontStyle.Regular)
			Dim font As XFont = New XFont("Bahnschrift Semilight Condensed", 11, XFontStyle.Regular)
			Dim barcodeTextFont As XFont = New XFont("Bahnschrift Semilight Condensed", 10, XFontStyle.Regular)

			' Position and spacing for QR codes and text
			Dim xPosition As Double = 70
			Dim yPosition As Double = 80
			Dim spacing As Double = 130 '150
			Dim rowspacing As Double = 10

			Dim headertext As String = $"Shipping Container Manifest"
			Dim headerSize As XSize = gfx.MeasureString(headertext, headerFont)
			Dim headerXPosition As Double = (pdfWidth - headerSize.Width) / 2
			Dim HeaderYPosition As Double = 35

			Dim headerImage As Image = My.Resources.cricutlogo_3
			Dim headerImageXPosition As Double = headerXPosition - (headerImage.Width + 10) ' Adjust the spacing as needed
			' Draw the header image

			Dim logostream As New MemoryStream()
			headerImage.Save(logostream, System.Drawing.Imaging.ImageFormat.Png)
			Dim headerXImage As XImage = XImage.FromStream(logostream)
			gfx.DrawImage(headerXImage, headerImageXPosition + 23, HeaderYPosition - 37)
			logostream.Close()

			gfx.DrawString(headertext, headerFont, XBrushes.Black, headerXPosition, HeaderYPosition)
			yPosition += 20 '35 ' Move down after the header

			Dim containerNoText As String = $"[{containerNo_txtbx.Text}]"
			Dim containerSize As XSize = gfx.MeasureString(containerNoText, font)
			Dim containerXposition As Double = (pdfWidth - containerSize.Width) / 2
			gfx.DrawString(containerNoText, containerNoFont, XBrushes.Black, xPosition, yPosition - 16)


			Dim totalPallets = GlobalVariables.MasterList.Count

			Dim palletCountText As String = $"[Pallets: {totalPallets.ToString()}]"
			Dim palletSize As XSize = gfx.MeasureString(palletCountText, font)
			Dim palletXposition As Double = (pdfWidth - palletSize.Width) / 2
			gfx.DrawString(palletCountText, containerNoFont, XBrushes.Black, palletXposition + 135, yPosition - 16)


			' Iterate through the items in MasterList and organize in rows
			Dim itemsPerRow As Integer = 3 ' Number of items per row
			Dim itemsInCurrentRow As Integer = 0

			For Each item As BarcodeItem In GlobalVariables.MasterList
				' Create a QR code image
				Dim qrCodeImage As Image = createQrImage(item.BarcodeText)
				Dim qrCodeStream As New MemoryStream()
				qrCodeImage.Save(qrCodeStream, System.Drawing.Imaging.ImageFormat.Png)
				Dim qrCodeXImage As XImage = XImage.FromStream(qrCodeStream)

				' Draw a bordered box for the QR code and text
				Dim boxWidth As Double = 140
				Dim boxHeight As Double = 130

				' Calculate the position for the centered text
				Dim textXPosition As Double = xPosition + (boxWidth - gfx.MeasureString(item.BarcodeText, font).Width) / 2

				' Check if the item exceeds the current page height
				If yPosition + boxHeight > pdfHeight Then
					' Page is full, add a new page
					page = document.AddPage()
					gfx = XGraphics.FromPdfPage(page)
					pdfWidth = page.Width.Point
					pdfHeight = page.Height.Point
					xPosition = 70
					yPosition = 80

				End If

				' Draw the border box
				gfx.DrawRectangle(XPens.Black, xPosition, yPosition, boxWidth, boxHeight - 5)

				' Draw the QR code image and text inside the box
				'gfx.DrawString($"Pallet: {item.PalletNo}", font, XBrushes.Black, textXPosition + 2, yPosition + 14)
				gfx.DrawImage(qrCodeXImage, xPosition + 20, yPosition + 5, 100, 100)
				'gfx.DrawString(item.BarcodeText, barcodeTextFont, XBrushes.Black, textXPosition + 5, yPosition + 105)


				If splitMasterBarcodeInput(item.BarcodeText) Then
					Dim topText = $"{WorkOrder},{PoNumber}"
					Dim botText = $"{SubGroup},{PalletNo},{Shift}"


					Dim topTextPos As Double = xPosition + (boxWidth - gfx.MeasureString(topText, font).Width) / 2
					Dim botTextPos As Double = xPosition + (boxWidth - gfx.MeasureString(botText, font).Width) / 2


					gfx.DrawString(topText, barcodeTextFont, XBrushes.Black, topTextPos + 5, yPosition + 105)
					gfx.DrawString(botText, barcodeTextFont, XBrushes.Black, botTextPos + 5, yPosition + 115)

				End If

				' Move to the next column
				xPosition += boxWidth + 20 ' Adjust as needed
				itemsInCurrentRow += 1

				' If the current row is full, move to the next row
				If itemsInCurrentRow >= itemsPerRow Then
					xPosition = 70
					yPosition += boxHeight + rowspacing
					itemsInCurrentRow = 0
				End If
			Next

			' Save the PDF document
			document.Save(outputPath)

			' Check if the PDF file exists
			If File.Exists(outputPath) Then
				' Open the PDF file using the default PDF viewer
				Process.Start(outputPath)
			Else
				MessageBox.Show("The PDF file does not exist.")
			End If

			'MessageBox.Show("PDF generated successfully.")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
	End Function

	' Button Click Event to generate A PDF
	Private Sub createPDF_btn_Click(sender As Object, e As EventArgs) Handles createPDF_btn.Click
		Try
			If Not ISContainerNull Then
				insertToDB()
				CreatePdf()
			Else
				MessageBox.Show("Please Key In The Container Name")
			End If


		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
	End Sub

#End Region


	Private Function LoadExistingContainerItems()
		Dim conn As New SqlConnection(connstr)
		Try
			conn.Open()
			If conn.State = ConnectionState.Open Then
				Dim sqlcmd As New SqlCommand()
				sqlcmd.Connection = conn
				sqlcmd.CommandText = "SELECT DISTINCT 
											 cs.[Master Container ID]
											,cs.[Master Container Name]
											,cs.[Work Order ID]
											,cs.[Work Order]
											,wom.[Po Number]
											,cs.[Sub Group]
											,cs.[Pallet No]
											,cs.[Shift]
											,cs.[Split]
										FROM [CRICUT].[CUPID].[ContainerShipping] cs
										INNER JOIN [CRICUT].[CUPID].[WorkOrderMaster] wom ON cs.[Work Order ID] = wom.[Work Order ID]
										WHERE cs.[Master Container Name] = '" & GlobalVariables.ContainerName.Trim() & "'
										AND cs.[Master Container ID] = '" & GlobalVariables.MasterContainerID.ToString() & "'"

				Dim reader As SqlDataReader = sqlcmd.ExecuteReader()


				While reader.Read()

					If reader.IsDBNull(reader.GetOrdinal("Po Number")) Then
						PoNumber = "NULL"
					Else
						PoNumber = reader.GetValue(reader.GetOrdinal("Po Number"))
					End If

					If reader.IsDBNull(reader.GetOrdinal("Split")) Then
						Pallet_Split = False
					Else
						Pallet_Split = reader.GetValue(reader.GetOrdinal("Split"))
					End If


					WorkOrder = reader("Work Order").ToString().Trim()
					SubGroup = reader("Sub Group").ToString().Trim()
					PalletNo = reader("Pallet No").ToString().Trim()
					Shift = reader("Shift").ToString().Trim()
					Dim SerialNumber = $"{WorkOrder},{PoNumber},{SubGroup},{PalletNo},{Shift}"

					Dim barcodeItem = New BarcodeItem()
					barcodeItem.BarcodeImage = createBarcodeImage(SerialNumber)
					barcodeItem.BarcodeText = SerialNumber
					barcodeItem.PalletNo = GlobalVariables.palletcounter


					' Create instances of your custom classes and populate them with data from the database
					Dim listitem As New ListItem()
					listitem.isSplit = Pallet_Split
					listitem.itemid = barcodeItem.BarcodeText
					listitem.BarcodeImage = barcodeItem.BarcodeImage
					listitem.PalletCount = GlobalVariables.palletcounter

					Dim masterItem As New MasterBarcodeItem()
					masterItem.WorkOrderID = reader("Work Order ID")
					masterItem.WorkOrder = WorkOrder
					masterItem.PoNumber = PoNumber
					masterItem.SubGroup = SubGroup
					masterItem.PalletNo = PalletNo
					masterItem.Shift = Shift

					' Add item to Datagridview
					DataGridView1.Rows.Add(barcodeItem.PalletNo, barcodeItem.BarcodeText)

					' Add the UserControl to the FlowLayoutPanel
					FlowLayoutPanel1.Controls.Add(listitem)

					' Add the item to the barcode list and MasterBarcodeItemList
					GlobalVariables.MasterList.Add(barcodeItem)
					GlobalVariables.MasterBarcodeItemList.Add(masterItem)

					'Add Pallet Counter by 1 once adding the item
					GlobalVariables.palletcounter += 1
					ItemCounter_lbl.Text = $"Items: {GlobalVariables.palletcounter - 1}"
				End While
				reader.Close()
			End If
		Catch ex As Exception
			' Handle exceptions
		Finally
			conn?.Close()
		End Try
	End Function

	Private Function clearCache()
		Try
			GlobalVariables.MasterList.Clear()
			GlobalVariables.MasterBarcodeItemList.Clear()
			GlobalVariables.MasterContainerCompleted = False
			GlobalVariables.MasterContainerID = New Guid()
			GlobalVariables.ContainerName = ""
			GlobalVariables.palletcounter = 1
			If FlowLayoutPanel1.Controls.Count > 0 Then
				FlowLayoutPanel1.Controls.Clear()
			End If
			If DataGridView1.RowCount > 0 Then
				DataGridView1.Rows.Clear()
			End If
			ListBox1.Items.Clear()

			Return True
		Catch ex As Exception
			Return False
		End Try
	End Function

	Private Function getNewMasterContainerID()
		Dim conn As New SqlConnection(connstr)
		Dim IsDuplicate = True
		Try
			conn.Open()
			If conn.State = ConnectionState.Open Then
				While IsDuplicate = True
					GlobalVariables.MasterContainerID = Guid.NewGuid()
					Dim query = "SELECT [Master Container ID]
							FROM [CRICUT].[CUPID].[ContainerMaster]
							WHERE [Master Container ID] = '" & GlobalVariables.MasterContainerID.ToString().Trim() & "'"
					Using cmd As New SqlCommand(query, conn)
						Dim count As Integer = CInt(cmd.ExecuteScalar())
						If count = 0 Then
							IsDuplicate = False
							Exit While
						End If
					End Using
					conn?.Close()
				End While
			End If
		Catch ex As Exception
			conn?.Close()
		Finally
			conn?.Close()
		End Try
	End Function

#Region "InputBox Controls"
	' Set Container
	Private Sub addContainerNo_btn_Click(sender As Object, e As EventArgs) Handles addContainerNo_btn.Click
		Try

			clearCache()
			Dim inputString = containerNo_txtbx.Text
			GlobalVariables.CID_Existance = False
			If checkMasterContainerExistence(inputString.Trim()) Then
				GlobalVariables.CID_Existance = True
			End If

			If Not inputString = "" AndAlso Not inputString = Nothing Then
				GlobalVariables.ContainerName = inputString.Trim()

				If Not GlobalVariables.CID_Existance Then
					getNewMasterContainerID()
					'GlobalVariables.MasterContainerID = Guid.NewGuid()
					container_lbl.Text = $"{GlobalVariables.ContainerName}"
					containerStatus_lbl.Text = $"New Container"
					containerStatus_lbl.ForeColor = Color.DodgerBlue
					edit_btn.Visible = False
				Else

					container_lbl.Text = $"{GlobalVariables.ContainerName}"

					If GlobalVariables.MasterContainerCompleted Then
						containerStatus_lbl.Text = $"Completed"
						containerStatus_lbl.ForeColor = Color.Red
						edit_btn.Visible = True
						GlobalVariables.AllowContainerEdit = False
					Else
						containerStatus_lbl.Text = $"In Progress"
						containerStatus_lbl.ForeColor = Color.Green
					End If
					LoadExistingContainerItems()
				End If

				ISContainerNull = False
			Else
				container_lbl.Text = "No Container Defined"
				GlobalVariables.ContainerName = Nothing
				GlobalVariables.MasterContainerID = Nothing
				GlobalVariables.palletcounter = 0

				ISContainerNull = True
			End If
		Catch ex As Exception
		Finally
			'GlobalVariables.AllowContainerEdit = False
		End Try
	End Sub

	' Clear Container Textbox
	Private Sub clrContainerNoTxtbx_btn_Click(sender As Object, e As EventArgs) Handles clrContainerNoTxtbx_btn.Click
		Try
			containerNo_txtbx.Text = Nothing
			containerNo_txtbx.Clear()
			containerNo_txtbx.Focus()
		Catch ex As Exception
		End Try
	End Sub

	' Trigger Enter Key for Container Number
	Private Sub containerNo_txtbx_KeyDown(sender As Object, e As KeyEventArgs)
		If e.KeyValue = Keys.Enter Then
			addContainerNo_btn_Click(Nothing, e)
		End If
	End Sub

	' Reset All Entries
	Private Sub mainReset_btn_Click(sender As Object, e As EventArgs) Handles mainReset_btn.Click
		Try
			clearCache()
			masterBarcode_txtbx.Text = ""
			containerNo_txtbx.Text = ""
			GlobalVariables.ContainerName = Nothing
			GlobalVariables.palletcounter = 0
			ItemCounter_lbl.Text = $"Items: {GlobalVariables.palletcounter}"
			GlobalVariables.MasterList.Clear()
			DataGridView1.Rows.Clear()
			DataGridView1.Refresh()
			container_lbl.Text = "No Container Defined"
			containerStatus_lbl.Text = ""

			For i As Integer = FlowLayoutPanel1.Controls.Count - 1 To 0 Step -1
				Dim control As Control = FlowLayoutPanel1.Controls(i)
				FlowLayoutPanel1.Controls.Remove(control)
				control.Dispose() ' Optional: Dispose of the control to release resources
			Next
		Catch ex As Exception
		End Try
	End Sub


	'Adds item to the List of Barcode Items
	Private Sub addMasterBarcode_btn_Click(sender As Object, e As EventArgs) Handles addMasterBarcode_btn.Click
		Try

			Dim State = True

			If GlobalVariables.MasterContainerCompleted Then
				If Not GlobalVariables.AllowContainerEdit Then
					State = False
				End If
			End If

			If State Then
				newMasterItem()
				UpdateMasterContainerStatus(True, False)
				'addContainerNo_btn_Click(sender, Nothing)
			Else
				ListBox1.Items.Clear()
				ListBox1.Items.Add(">>> Error Found <<<")
				ListBox1.Items.Add("")
				ListBox1.Items.Add("Unable to Add Item")
				ListBox1.Items.Add("Please Enable Admin Rights")
				edit_btn_Click(sender, e)
			End If


		Catch ex As Exception
			ListBox1.Items.Clear()
			ListBox1.Items.Add(">>> Error Found <<<")
			ListBox1.Items.Add("")
			ListBox1.Items.Add(ex.Message)
		End Try
	End Sub

	' KeyDown Enter.Key to entry the item to the List of Barcode Items
	Private Sub masterBarcode_txtbx_KeyDown(sender As Object, e As KeyEventArgs) Handles masterBarcode_txtbx.KeyDown
		Try
			If e.KeyCode = Keys.Enter Then
				'newMasterItem()
				addMasterBarcode_btn_Click(e, Nothing)
			End If
		Catch ex As Exception
		End Try
	End Sub

	' Clear MasterBarcodeTextbox
	Private Sub clrMasterBarcodeTxtbx_btn_Click(sender As Object, e As EventArgs) Handles clrMasterBarcodeTxtbx_btn.Click
		Try
			masterBarcode_txtbx.Text = ""
			masterBarcode_txtbx.Clear()
			masterBarcode_txtbx.Focus()
		Catch ex As Exception
		End Try
	End Sub

#End Region

	Public Sub resetPalletAmounts(ByVal Input)
		Try
			For Each item As ListItem In FlowLayoutPanel1.Controls
				If item.itemid = Input Then
					FlowLayoutPanel1.Controls.Remove(item)
				End If
			Next

			' Use LINQ to find the rows that match the condition
			Dim rowsToRemove = From row As DataGridViewRow In DataGridView1.Rows
							   Where row.Cells("SerialNo").Value.ToString() = Input
							   Select row

			' Remove the matching rows
			For Each row As DataGridViewRow In rowsToRemove.ToList()
				DataGridView1.Rows.Remove(row)
			Next

			Dim i = 1
			For Each row As DataGridViewRow In DataGridView1.Rows
				row.Cells("Pallet").Value = i
				i += 1
			Next

			Dim j = 1
			For Each item As ListItem In FlowLayoutPanel1.Controls
				item.PalletCount = j
				j += 1
			Next
			GlobalVariables.palletcounter = i - 1
			ItemCounter_lbl.Text = $"Items: {GlobalVariables.palletcounter}"
		Catch ex As Exception
			'MessageBox.Show(ex.Message)
		End Try
	End Sub

	Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		Try
			GlobalVariables.LoginFrmInstance.Dispose()
		Catch ex As Exception
		End Try
	End Sub


	Private Sub execute_btn_Click(sender As Object, e As EventArgs) Handles execute_btn.Click
		Try


			Dim userChoice As DialogResult = MessageBox.Show("Please confirm that you have completed the container insertion process. " & vbCrLf &
															 "This action is final and requires supervisor approval for any future edits." & vbCrLf &
															 "Are you sure you want to proceed?",
															 "Confirmation: Container Insertion Completion",
															   MessageBoxButtons.YesNo,
															   MessageBoxIcon.Question)



			Dim passedItems As New List(Of String)()
			Dim failedItems As New List(Of String)()

			For Each item In GlobalVariables.MasterBarcodeItemList
				If AddItemtoDbContainer(item.WorkOrderID, item.WorkOrder, item.SubGroup, item.PalletNo, item.Shift) Then
					passedItems.Add($"{item.WorkOrder},{item.SubGroup},{item.PalletNo},{item.Shift} : Loaded")
				Else
					failedItems.Add($"{item.WorkOrder},{item.SubGroup},{item.PalletNo},{item.Shift} : Already Exist")
				End If
			Next

			' Clear the listbox and display passed items
			ListBox1.Items.Clear()
			ListBox1.Items.Add($"Container: {GlobalVariables.ContainerName}")
			ListBox1.Items.Add("New Items:")
			For Each passedItem In passedItems
				ListBox1.Items.Add(passedItem)
			Next
			ListBox1.Items.Add("")

			' Display failed items
			ListBox1.Items.Add("Existing Items:")
			For Each failedItem In failedItems
				ListBox1.Items.Add(failedItem)
			Next

			If UpdateMasterContainerStatus(False, True) Then
				CreatePdf()
			End If

			addContainerNo_btn_Click(sender, e)


		Catch ex As Exception
		End Try
	End Sub

	Private Sub print_btn_Click(sender As Object, e As EventArgs) Handles print_btn.Click
		Try
			CreatePdf()
		Catch ex As Exception
		End Try
	End Sub


	Private Sub containerNo_txtbx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles containerNo_txtbx.KeyPress
		Try
			'addContainerNo_btn_Click(e, Nothing)
		Catch ex As Exception
			ListBox1.Items.Clear()
			ListBox1.Items.Add(ex.Message)
		End Try
	End Sub

#Region "Button Hover Effects"
	Private Sub print_btn_MouseHover(sender As Object, e As EventArgs) Handles print_btn.MouseHover
		print_btn.Image = My.Resources.print
		print_btn.ImageAlign = ContentAlignment.MiddleCenter
		print_btn.Text = ""
	End Sub

	Private Sub print_btn_MouseLeave(sender As Object, e As EventArgs) Handles print_btn.MouseLeave
		print_btn.Image = My.Resources.print_32
		print_btn.ImageAlign = ContentAlignment.MiddleLeft
		print_btn.Text = "Print"
	End Sub

	Private Sub execute_btn_MouseHover(sender As Object, e As EventArgs) Handles execute_btn.MouseHover
		execute_btn.Image = My.Resources.Shipping_32_gif
		execute_btn.ImageAlign = ContentAlignment.MiddleCenter
		execute_btn.Text = ""
	End Sub

	Private Sub execute_btn_MouseLeave(sender As Object, e As EventArgs) Handles execute_btn.MouseLeave
		execute_btn.Image = My.Resources.Shipping_32
		execute_btn.ImageAlign = ContentAlignment.MiddleLeft
		execute_btn.Text = "Complete"
	End Sub

	Private Sub edit_btn_MouseHover(sender As Object, e As EventArgs) Handles edit_btn.MouseHover
		edit_btn.Image = My.Resources.edit_32_gif
		edit_btn.ImageAlign = ContentAlignment.MiddleCenter
		edit_btn.Text = ""
	End Sub

	Private Sub edit_btn_MouseLeave(sender As Object, e As EventArgs) Handles edit_btn.MouseLeave
		edit_btn.Image = My.Resources.icons8_edit_32
		edit_btn.ImageAlign = ContentAlignment.MiddleLeft
		edit_btn.Text = "Edit"
	End Sub

#End Region

	Private Sub edit_btn_Click(sender As Object, e As EventArgs) Handles edit_btn.Click
		Try

			Dim adminPrompt As New adminAccessPrompt
			adminPrompt.ShowDialog()

			If GlobalVariables.AllowContainerEdit Then
				ListBox1.Items.Clear()
				ListBox1.Items.Add("Admin Rights to Edit")
				addContainerNo_btn_Click(sender, e)
			Else
				ListBox1.Items.Clear()
				ListBox1.Items.Add("You have no rights to Edit")
				ListBox1.Items.Add("This Container")
			End If
		Catch ex As Exception
		End Try
	End Sub


	Private Function UpdateCompleteStatus()
		Dim PalletRowCount = 0
		Dim WorkOrderRowCount = 0
		Dim conn As New SqlConnection(connstr)
		Try
			conn.Open()
			If conn.State = ConnectionState.Open Then

				' Gets the Total WorkOrder Rows that are related to the WorkOrderID
				' This query is checking all not filtered to Pallet No
				Dim query As String = "SELECT COUNT(*) 
										FROM [CRICUT].[CUPID].[WorkOrder] wo
										INNER JOIN [CRICUT].[CUPID].[WorkOrderMaster] wom ON wo.[Work Order ID] = wom.[Work Order ID]
										WHERE wo.[Work Order ID] = '" & WorkOrderID.ToString() & "'
										AND wo.[Shift] = '" & Shift & "' AND wom.[Sub Group] = '" & SubGroup & "'"
				Using cmd As New SqlCommand(query, conn)
					' Use ExecuteScalar to get the count as an object and convert it to Integer
					Dim rowCount As Object = cmd.ExecuteScalar()
					If rowCount IsNot Nothing AndAlso IsNumeric(rowCount) Then
						WorkOrderRowCount = CInt(rowCount)
					Else
						Return False
					End If
				End Using

				'If Row Count is 0 Dont proceed to update anything
				If Not WorkOrderRowCount > 0 Then
					Return False
				End If

				' Update The Row Count Value to the latest Value [WorkOrderRowCount]
				Try
					' Update [Count] value in [WorkOrderMaster] table
					Dim updateQuery As String = "UPDATE [CRICUT].[CUPID].[WorkOrderMaster] 
												 SET [Count] = " & WorkOrderRowCount & ",
													 [Modified Date] = GETDATE()
												 WHERE [Work Order ID] = '" & WorkOrderID.ToString() & "'"
					Using updateCmd As New SqlCommand(updateQuery, conn)
						updateCmd.ExecuteNonQuery()
					End Using
				Catch ex As Exception
					Return False
				End Try


				' This Count Query gets the Pallet No Row Counts to that particulat Work Order ID
				Try
					' Select the Count of Pallet rows in WorkOrder table
					Dim CountQuery As String = "SELECT COUNT(*) 
												FROM [CRICUT].[CUPID].[WorkOrder] wo
												INNER JOIN [CRICUT].[CUPID].[WorkOrderMaster] wom ON wo.[Work Order ID] = wom.[Work Order ID]
												WHERE wo.[Work Order ID] = '" & WorkOrderID.ToString() & "' AND wo.[Pallet No] = '" & PalletNo & "'
												AND wo.[Shift] = '" & Shift & "' AND wom.[Sub Group] = '" & SubGroup & "'"
					Using cmd As New SqlCommand(CountQuery, conn)
						' Use ExecuteScalar to get the count as an object and convert it to Integer
						Dim rowCount As Object = cmd.ExecuteScalar()
						If rowCount IsNot Nothing AndAlso IsNumeric(rowCount) Then
							PalletRowCount = CInt(rowCount)
						Else
							Return False
						End If
					End Using
				Catch ex As Exception
					Return False
				End Try


				' If the [Pallet No] row count is More than the [Quantity] Return PalletResult = 1(indicating true)
				Dim Palletresult = 0
				Try
					' Check if [Count] is more or same [Total Order Count]
					Dim checkQuery As String = "SELECT CASE WHEN [Quantity] <= '" & PalletRowCount & "' THEN 1 ELSE 0 END AS Result 
												FROM [CRICUT].[CUPID].[WorkOrderMaster] 
												WHERE [Work Order ID] = '" & WorkOrderID.ToString() & "'"
					Using QueryCountstatus As New SqlCommand(checkQuery, conn)
						Palletresult = CInt(QueryCountstatus.ExecuteScalar())
					End Using
				Catch ex As Exception
					Return False
				End Try


				' Updates the Row Count
				Try
					If Palletresult = 1 Then
						' If [Quantity] <= PalletRowCount, update [Completed] to 1
						Dim updateCountStatus As String = "UPDATE ws
																SET ws.[PalletScanCompleted] = 1,
																	ws.[PalletizingCompleted] = 1,
																	ws.[Modified Date] = GETDATE()
																FROM [CRICUT].[CUPID].[WorkOrderStatus] ws
																INNER JOIN [CRICUT].[CUPID].[WorkOrderMaster] wm ON ws.[Work Order ID] = wm.[Work Order ID]
																WHERE ws.[Work Order ID] = '" & WorkOrderID.ToString() & "'
																AND ws.[Work Order] = '" & WorkOrder & "'
																AND ws.[Sub Group] = '" & SubGroup & "'
																AND ws.[Pallet No] ='" & PalletNo & "'
																AND ws.[Shift] = '" & Shift & "'"

						Using updateCmd As New SqlCommand(updateCountStatus, conn)
							updateCmd.ExecuteNonQuery()
						End Using
					End If
				Catch ex As Exception
					Return False
				End Try
				Return True
			End If
		Catch ex As Exception
			conn?.Close()
			Return False
		Finally
			conn?.Close()
		End Try
	End Function

	Private Sub Save_Btn_Click(sender As Object, e As EventArgs) Handles Save_Btn.Click
		Try

			If GlobalVariables.ContainerName = "" Or containerNo_txtbx.Text = "" Then
				ListBox1.Items.Clear()
				ListBox1.Items.Add("Container Not Definied")
				Exit Sub
			Else
				If FlowLayoutPanel1.Controls.Count < 0 Or GlobalVariables.MasterBarcodeItemList.Count < 0 Or GlobalVariables.MasterList.Count < 0 Then
					ListBox1.Items.Add("No Items to save to container")
					Exit Sub
				End If
			End If



			Dim result As DialogResult = MessageBox.Show("Container Information has been saved successfully !!" & vbCrLf &
												   "Do you want to generate the Shipping Manifest for this container?",
												   "Generate Manifest",
												   MessageBoxButtons.YesNo,
												   MessageBoxIcon.Question)

			If result = DialogResult.Yes Then
				' The user clicked "Yes," so generate the manifest
				CreatePdf()
			End If
		Catch ex As Exception
		End Try
	End Sub

	'This will split pallet to multiple container
	Private Sub splitPallet_btn_Click(sender As Object, e As EventArgs) Handles splitPallet_btn.Click
		Try
			Dim sc As New splitPallet_Form
			sc.ShowDialog()
		Catch ex As Exception
		End Try
	End Sub

	'Refresh the main form after updating new values from splitPallet
	Public Function refreshMain()
		Try
			addContainerNo_btn_Click(Nothing, Nothing)
		Catch ex As Exception
		End Try
	End Function


End Class
