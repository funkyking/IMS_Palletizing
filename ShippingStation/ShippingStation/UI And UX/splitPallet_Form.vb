Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Windows.Controls

Public Class splitPallet_Form


#Region "Variables"
    Dim loadingID = Guid.NewGuid
    Private connstr = ""
    Dim workOrderID As Guid
    Dim WorkOrder As String = ""
    Dim PoNumber As String = ""
    Dim SubGroup As String = ""
    Dim PalletNo As String = ""
    Dim Shift As String = ""
#End Region


    Private Sub splitPallet_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connstr = ReadValue("System", "SQLconnstr", IniPath)
        CheckDuplicateLoadingID()
    End Sub



#Region "Buttons"


    Private Sub MasterBarcode_btn_Click(sender As Object, e As EventArgs) Handles MasterBarcode_btn.Click
        Try
            If masterBarcode_txtbx.Text IsNot Nothing Or masterBarcode_txtbx.Text = "" Then
                Dim input = masterBarcode_txtbx.Text.ToString()
                splitMasterBarcodeInput(input)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MasterBarcode_Clr_Btn_Click(sender As Object, e As EventArgs) Handles MasterBarcode_Clr_Btn.Click
        Try
            ListBox1.Items.Clear()
            masterBarcode_txtbx.Text = ""
            masterBarcode_txtbx.Focus()
        Catch ex As Exception
        End Try
    End Sub

    'Add Serial Number textBox
    Private Sub SerialAdd_btn_Click(sender As Object, e As EventArgs) Handles SerialAdd_btn.Click
        Try
            If Not (serial_txtbx.Text = Nothing Or serial_txtbx.Text = "") Then
                Dim serial_input = serial_txtbx.Text.ToString()
                If Not checkDuplicate(serial_input) Then
                    status_lbl.Text = "Duplicate Serial No Found"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Clear Serial Input TextBox
    Private Sub clear_btn_Click(sender As Object, e As EventArgs) Handles clear_btn.Click
        Try
            serial_txtbx.Clear()
            serial_txtbx.Text = ""
            serial_txtbx.Focus()
        Catch ex As Exception
        End Try
    End Sub

    'Complete the Entire Splitting
    Private Sub finish_btn_Click(sender As Object, e As EventArgs) Handles finish_btn.Click
        Try
            InsertIntoContainerSplitDb()
            GlobalVariables.MainInstance.UpdateMasterContainerStatus(True, False)
            GlobalVariables.MainInstance.refreshMain()
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

#End Region


#Region "Textbox Input"

    Private Sub serial_txtbx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles serial_txtbx.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Dim input = serial_txtbx.Text.ToString()
                If Not checkDuplicate(input) Then
                    status_lbl.Text = "Duplicate Serial No Found"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region


#Region "Functions"

    Private Function splitMasterBarcodeInput(ByRef Input)
        Try
            Dim strSplit() As String = Input.Split(",")
            If strSplit.Length >= 5 Then
                WorkOrder = strSplit(0).Trim()
                PoNumber = strSplit(1).Trim()
                SubGroup = strSplit(2).Trim()
                PalletNo = strSplit(3).Trim()
                Shift = strSplit(4).Trim()

                ListBox1.Items.Clear()
                ListBox1.Items.Add("Current MasterBarcode")
                ListBox1.Items.Add("")
                ListBox1.Items.Add($"Work Order: {WorkOrder}")
                ListBox1.Items.Add($"PO Number : {PoNumber}")
                ListBox1.Items.Add($"Sub Group : {SubGroup}")
                ListBox1.Items.Add($"Pallet No : {PalletNo}")
                ListBox1.Items.Add($"Shift     : {Shift}")

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

    Private Function checkDuplicate(ByVal serialInput As String) As Boolean
        Dim conn As New SqlConnection(connstr)
        Try
            'check in database if serial number exist
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim query = "SELECT [Serial No]
                                FROM [CRICUT].[CUPID].[ContainerSplit]
                                WHERE [Serial No] = '" & serialInput & "'"
                Using cmd As New SqlCommand(query, conn)
                    Dim ds = cmd.ExecuteReader()
                    If ds.HasRows Then
                        MessageBox.Show($"{serialInput} already Exist in the database")
                        Return False
                    End If
                End Using
            End If


            'Check if DataGridView Has it
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = serialInput Then
                    MessageBox.Show($"{serialInput} already Exist in the table")
                    Return False
                End If
            Next

            DataGridView1.Rows.Add(serial_txtbx.Text.ToString())
            serial_txtbx.Clear()
            serial_txtbx.Text = ""
            serial_txtbx.Focus()
            Return True

        Catch ex As Exception
            conn.Close()
        Finally
            conn.Close()
        End Try
    End Function

    Private Function InsertIntoContainerSplitDb()
        Dim conn As New SqlConnection(connstr)
        Try
            GetWorkOrderID()
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim _SerialNumber As String = ""
                For Each row As DataGridViewRow In DataGridView1.Rows

                    If Not row.IsNewRow Then ' Check if it's not the new row
                        _SerialNumber = row.Cells(0).Value.ToString()
                    End If



                    Dim query = "INSERT INTO [CRICUT].[CUPID].[ContainerSplit]
                               ([Loading ID]
                               ,[Master Container ID]
                               ,[Serial No]
                               ,[Work Order ID]
                               ,[Work Order]
                               ,[Sub Group]
                               ,[Pallet No]
                               ,[Shift]
                               ,[UserID]
                               ,[Date])
                         VALUES
                               ('" & loadingID.ToString().Trim() & "'
                               ,'" & GlobalVariables.MasterContainerID.ToString().Trim() & "'
                               ,'" & _SerialNumber.Trim() & "'
                               ,'" & workOrderID.ToString().Trim() & "'
                               ,'" & WorkOrder & "'
                               ,'" & SubGroup & "'
                               ,'" & PalletNo & "'
                               ,'" & Shift & "'
                               ,'" & GlobalVariables.UserID.ToString() & "'
                               ,GETDATE())"
                    Using sqlcmd As New SqlCommand(query, conn)
                        sqlcmd.ExecuteNonQuery()
                    End Using
                Next

                'Insert to Container Shipping table
                InsertIntoContainerShipping()


            End If
        Catch ex As Exception
        End Try
    End Function

    Private Function InsertIntoContainerShipping()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim query = " INSERT INTO [CRICUT].[CUPID].[ContainerShipping]
                                           ([Loading ID],[Master Container ID],[Master Container Name],[Work Order ID],[Work Order],[Sub Group]
                                           ,[Pallet No],[Shift],[UserID],[Date],[IsDeleted],[Split])
                                     VALUES
                                           ('" & loadingID.ToString().Trim() & "'
                                           ,'" & GlobalVariables.MasterContainerID.ToString().Trim() & "'
                                           ,'" & GlobalVariables.ContainerName.Trim() & "'
                                           ,'" & workOrderID.ToString().Trim() & "'
                                           ,'" & WorkOrder & "'
                                           ,'" & SubGroup & "'
                                           ,'" & PalletNo & "'
                                           ,'" & Shift & "'
                                           ,'" & GlobalVariables.UserID.ToString() & "'
                                           ,GETDATE()
                                           ,'0'
                                           ,'1')"
                Using sqlcmd As New SqlCommand(query, conn)
                    sqlcmd.ExecuteNonQuery()
                End Using
                conn?.Close()
            End If
        Catch ex As Exception
            conn?.Close()
        End Try
    End Function

#End Region


#Region "Context Menu Strip for DataGridView"

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            Dim selectedCell As DataGridViewCell = DataGridView1.CurrentCell
            Clipboard.Clear()
            Clipboard.SetText(selectedCell.Value.ToString())
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            DataGridView1.Rows.RemoveAt(DataGridView1.CurrentCell.RowIndex)
        Catch ex As Exception
        End Try
    End Sub
#End Region

    Private Sub serial_txtbx_TextChanged(sender As Object, e As EventArgs) Handles serial_txtbx.TextChanged
        Try
            status_lbl.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    Private Function CheckDuplicateLoadingID()
        Try
startingplace:
            Dim Conn = New SqlConnection(connstr)
            Conn.Open()
            Dim SQLcmd = New SqlCommand
            SQLcmd.Connection = Conn
            SQLcmd.CommandText = "SELECT [Loading ID]
                                FROM [CRICUT].[CUPID].[ContainerShipping]
                                WHERE [Loading ID] = '" & loadingID.ToString() & "
                                UNION
                                SELECT [Loading ID]
                                FROM [CRICUT].[CUPID].[ContainerSplit]
                                WHERE [Loading ID] = '" & loadingID.ToString() & "';"
            Dim ds = SQLcmd.ExecuteReader
            If ds.HasRows Then
                loadingID = Guid.NewGuid
                Conn.Close()
                GoTo startingplace
            End If
            Conn.Close()
        Catch ex As Exception
        End Try
    End Function

    Private Function GetWorkOrderID() As Boolean
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
                    workOrderID = ds.GetValue(ds.GetOrdinal("Work Order ID"))
                    Conn.Close()
                Else
                    Return False
                    Conn.Close()
                End If
            End If
        Catch ex As Exception
            Conn.Close()
            Return True
        End Try
    End Function


End Class