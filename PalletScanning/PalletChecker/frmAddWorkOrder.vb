Imports System.Data.SqlClient


Public Class frmAddWorkOrder
    Dim connstr = ReadValue("System", "SQLconnstr", IniPath)
    Dim WID As Guid
    Dim PID As Guid
    Dim MID As Guid
    Dim CID As Guid
    Dim LID As Guid
    Private Sub frmAddWorkOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WID = Guid.NewGuid
        WorkOrder.Text = ""
        SubGroup.Text = ""
        LineBox.Text = ""
        PartNo.Text = ""
        qty.Value = 0
        ModelNo.Text = ""
        totalOrderCount_Numeric.Value = 0
        count.Text = "0"
        ComboBox1.Text = "1"
        txtDescription.Text = ""
        LoadComboBox()

        SubGroup.Enabled = False
        LineBox.Enabled = False
        PartNo.Enabled = False
        ModelNo.Enabled = False
        count.Enabled = False
        ComboBox1.Enabled = False
        txtDescription.Enabled = False

        If Text.Contains("Update") Then
            GroupBox1.Text = "Update Work Order"
            UpdateBtn.Visible = True
            UpdateBtn.Location = SaveBtn.Location
            If workOrderShipping_State() Then
                WorkOrder.ReadOnly = True
            End If
            SaveBtn.Visible = False
            LoadSQL()
        Else
            GroupBox1.Text = "Add Work Order"
            UpdateBtn.Visible = False
            SaveBtn.Visible = True

        End If
    End Sub

    Private Function LoadSQL()
        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        Dim SQLcmd = New SqlCommand
        SQLcmd.Connection = Conn
        SQLcmd.CommandText = "Select 
                                  w.[Index]
                                  ,w.[Work Order]
                                  ,w.[Sub Group]
                                  ,p.[Part Name]
                                  ,m.[Model]
                                  , l.[Line]
                                  ,w.[Quantity]
                                  ,w.[Count]
                                  ,w.[Total Order Count]
                                  ,w.[Description]
                                  ,w.[Completed]
                                  ,w.[Modified Date]
                                  ,w.[ScanOption]
                                  ,w.[Delete]
                          FROM [CRICUT].[CUPID].[WorkOrderMaster] w
                           INNER JOIN [CRICUT].[CUPID].[PartMaster] p
                            ON w.[Part ID] = p.[Part ID]

                          INNER JOIN [CRICUT].[CUPID].[ModelMaster] m
                            ON w.[Model ID] = m.[Model ID]

 
                          INNER JOIN [CRICUT].[CUPID].[LineMaster] l
                            ON l.[LineID] = w.[LineID]
                        WHERE w.[Index] = '" & frmWorkOrderMaster.DataGridView1.CurrentRow.Cells("No").Value.ToString & "'AND W.[Delete]='False'"

        Dim ds = SQLcmd.ExecuteReader
        If ds.HasRows Then
            While ds.Read
                WorkOrder.Text = ds.Item("Work Order")
                SubGroup.Text = ds.Item("Sub Group").ToString
                PartNo.SelectedItem = ds.Item("Part Name")
                ModelNo.SelectedItem = ds.Item("Model")
                qty.Text = ds.Item("Quantity")
                count.Text = ds.Item("Count")
                totalOrderCount_Numeric.Value = ds.Item("Total Order Count")
                txtDescription.Text = ds.Item("Description")
                LineBox.Text = ds.Item("Line")
                ComboBox1.Text = ds.Item("ScanOption")

            End While
        End If
        Conn.Close()
    End Function

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If WorkOrder.Text = "" Or ModelNo.Text = "" Or LineBox.Text = "" Or PartNo.Text = "" Or qty.Value = 0 Or totalOrderCount_Numeric.Value = 0 Then
            statuslbl.Text = "Certain fields are missing"
        Else
            statuslbl.Text = ""
            If CheckDuplicateItem() = True Then
                Label8.Text = "Work Order Already Exist"

            ElseIf CheckDuplicateSub() Then
                Label8.Text = "SKU Already Exist"

                ' Removed by Paul (19/10/2023)
                'Else
                '    Label8.Text = ""
                '    'Exit Sub
            Else
                Label8.Text = ""
            End If
        End If


        'Added by Paul (19/10/2023)
        ' Label8.text also has to be emtpy then can proceed changes.
        If (statuslbl.Text <> "" Or Not statuslbl.Text.Contains("PO No.")) And Label8.Text <> "" Then
            Exit Sub
        End If
        GetModelID()
        GetPartID()
        CheckEmpty()
        CheckDuplicateID()
        GetLineID()

        Dim res = MessageBox.Show("Confirm Update Work Order?" & vbCrLf & "Work Order: " & WorkOrder.Text & vbCrLf & "Part:" & PartNo.Text & vbCrLf & "Quantity: " & qty.Value.ToString & vbCrLf & "Order: " & totalOrderCount_Numeric.Value.ToString & vbCrLf & "Scan Option: " & ComboBox1.Text, "Confirm Operation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
        If res = DialogResult.Yes Then
            InsertDataSQL()
        Else
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.Close()
    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        If WorkOrder.Text = "" Or PartNo.Text = "" Or ModelNo.Text = "" Or qty.Value = 0 Or totalOrderCount_Numeric.Value = 0 Then
            statuslbl.Text = "Certain fields are missing"
        Else
            statuslbl.Text = ""
            If CheckDuplicateItem() Then
                Label8.Text = "Work Order Already Exist"
            ElseIf CheckDuplicateSub() Then
                Label8.Text = "SKU Already Exist"
            Else
                Label8.Text = ""
            End If

            'Added by Paul (19/10/2023)
            If totalOrderCount_Numeric.Value < Integer.Parse(count.Text) Then
                statuslbl.Text = $"Carton total must equal or exceed the current value [{count.Text}]"
            End If

        End If

        'Added by Paul (19/10/2023)
        ' Label8.text also has to be emtpy then can proceed changes.
        If (statuslbl.Text <> "" Or Not statuslbl.Text.Contains("PO No.")) And Label8.Text <> "" Then
            Exit Sub
        End If
        GetModelID()
        GetPartID()
        CheckEmpty()
        GetLineID()

        Dim res = MessageBox.Show("Confirm Update Work Order?" & vbCrLf & "Work Order: " & WorkOrder.Text & vbCrLf & "Part: " & PartNo.Text & vbCrLf & "Quantity: " & qty.Value.ToString & vbCrLf & "Order: " & totalOrderCount_Numeric.Value.ToString & vbCrLf & "Scan Option: " & ComboBox1.Text, "Confirm Operation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
        If res = DialogResult.Yes Then
            UpdateDataSQL()
        Else
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Function CheckEmpty()
        If WorkOrder.Text = "" Or PartNo.Text = "" Or ModelNo.Text = "" Then

        End If
    End Function

    Private Function InsertDataSQL()
        Dim Conn = New SqlConnection(connstr)
        Try
            Conn.Open()

            'Make sure Po Number is NULL if there is no value
            If txtPO.Text = "" Or txtPO.Text = Nothing Then
                txtPO.Text = "NULL"
            End If

            If Conn.State = ConnectionState.Open Then
                Dim SQLcmd = New SqlCommand
                SQLcmd.Connection = Conn
                SQLcmd.CommandText = "INSERT INTO [CUPID].[WorkOrderMaster]
                                              ([Work Order ID],[Work Order],[Part ID],[Model ID],[LineID],[Quantity],[Count],[Total Order Count]
                                               ,[Description],[Completed],[Modified Date],[ScanOption],[Delete],[Sub Group],[CountPalletizing],[PO Number])
                                         VALUES
                                               ('" & WID.ToString & "'
                                               ,'" & WorkOrder.Text & "'
                                               ,'" & PID.ToString & "'
                                               ,'" & MID.ToString & "'
                                               , '" & LID.ToString & "'
                                               ,'" & qty.Value & "'
                                               ,'0'
                                               ,'" & totalOrderCount_Numeric.Value & "'
                                               ,'" & txtDescription.Text & "'
                                               ,'False'
                                               ,' " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'
                                               ,'" & ComboBox1.Text & "'
                                               ,'False'
                                               ,'" & SubGroup.Text & "'
                                               ,'0'
                                               ,'" & txtPO.Text & "')"

                SQLcmd.ExecuteNonQuery()
                Conn?.Close()
            End If
            Me.Close()
        Catch ex As Exception
            Conn?.Close()
        End Try
    End Function

    Private Function UpdateDataSQL()
        Dim Conn = New SqlConnection(connstr)
        Try
            Conn.Open()

            'Make sure Po Number is NULL if there is no value
            If txtPO.Text = "" Or txtPO.Text = Nothing Then
                txtPO.Text = "NULL"
            End If


            Dim workID = getWorkOrderID()


            If Conn.State = ConnectionState.Open Then


                'Update Work Order Master
                Dim WOM_Query = "UPDATE [CRICUT].[CUPID].[WorkOrderMaster]
                                    SET [Work Order] = '" & WorkOrder.Text & "',
                                        [PO Number] = '" & txtPO.Text & "',
                                        [Sub Group] = '" & SubGroup.Text & "',
                                        [Part ID] = '" & PID.ToString & "',
                                        [Model ID] = '" & MID.ToString & "',
                                        [LineID] = '" & LID.ToString & "',
                                        [Quantity] = '" & qty.Value & "',
                                        [Total Order Count] = '" & totalOrderCount_Numeric.Value & "',
                                        [Description] = '" & txtDescription.Text & "',
                                        [Modified Date] = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "',
                                        [ScanOption] = '" & ComboBox1.Text & "',
                                        [Delete] = 'False',
                                        [Completed] = CASE
                                            WHEN [Count] >= " & totalOrderCount_Numeric.Value & " THEN 1
                                            ELSE 0
                                        END
                                    WHERE [Index] = '" & frmWorkOrderMaster.DataGridView1.CurrentRow.Cells("No").Value.ToString & "'"

                Using WOM_cmd As New SqlCommand(WOM_Query, Conn)
                    WOM_cmd.ExecuteNonQuery()
                End Using



                'Update Work Order Status
                Dim WOS_Query = "UPDATE [CRICUT].[CUPID].[WorkOrderStatus]
                                   SET [Work Order] = '" & WorkOrder.Text & "'
                                      ,[Sub Group] = '" & SubGroup.Text & "'
                                      ,[Modified Date] = GETDATE()
                                 WHERE [Work Order ID] = '" & workID & "'"

                Using WOS_cmd As New SqlCommand(WOS_Query, Conn)
                    WOS_cmd.ExecuteNonQuery()
                End Using




                Conn?.Close()
            End If
            Me.Close()
        Catch ex As Exception
            Conn?.Close()
        End Try


    End Function

    Private Function CheckDuplicateItem() As Boolean
        statuslbl.Text = ""
        Dim cond As String = ""
        If Text.Contains("Update") Then
            cond = " Not [Index]='" & frmWorkOrderMaster.DataGridView1.CurrentRow.Cells("No").Value.ToString & "' AND"
        End If
        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        Dim SQLcmd = New SqlCommand
        SQLcmd.Connection = Conn
        SQLcmd.CommandText = "Select [Work Order]
                          FROM [CRICUT].[CUPID].[WorkOrderMaster] 
                          WHERE " & cond & "[Work Order] = '" & WorkOrder.Text & "' AND [Delete]='False'"

        Dim ds = SQLcmd.ExecuteReader
        If ds.HasRows Then
            While ds.Read
                statuslbl.Text = "Duplicate Item Found. Please Try Again. " & ds.Item("Work Order")

            End While
            Return True
        Else
            statuslbl.Text = ""
            Return False
        End If
    End Function

    Private Function CheckDuplicateID()
startingplace:
        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        Dim SQLcmd = New SqlCommand
        SQLcmd.Connection = Conn
        SQLcmd.CommandText = "Select [Work Order]
                          FROM [CRICUT].[CUPID].[WorkOrderMaster] WHERE [Work Order ID] = '" & WID.ToString & "'"

        Dim ds = SQLcmd.ExecuteReader
        If ds.HasRows Then
            WID = Guid.NewGuid
            Conn.Close()
            GoTo startingplace
        End If
        Conn.Close()

    End Function

    Private Sub WorkOrder_SelectedIndexChanged(sender As Object, e As EventArgs)
        CheckDuplicateItem()
    End Sub

    Private Sub PartNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PartNo.SelectedIndexChanged, PartNo.TextChanged
        GetPartID()
    End Sub

    Private Function GetPartID()
        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        If Conn.State = ConnectionState.Open Then
            Dim SQLcmd = New SqlCommand
            SQLcmd.Connection = Conn
            SQLcmd.CommandText = "SELECT [Part ID]
                              FROM [CRICUT].[CUPID].[PartMaster] WHERE [Part Name]='" & PartNo.Text & "' AND [Delete]='False'"
            Dim ds = SQLcmd.ExecuteReader
            If ds.HasRows Then
                While ds.Read
                    PID = ds.Item("Part ID")
                End While
            End If
        End If
    End Function

    Private Function GetModelID()
        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        If Conn.State = ConnectionState.Open Then
            Dim SQLcmd = New SqlCommand
            SQLcmd.Connection = Conn
            SQLcmd.CommandText = "SELECT [Model ID]
                              FROM [CRICUT].[CUPID].[ModelMaster] WHERE [Model]='" & ModelNo.Text & "' AND [Delete]='False'"
            Dim ds = SQLcmd.ExecuteReader
            If ds.HasRows Then
                While ds.Read
                    MID = ds.Item("Model ID")
                End While
            End If
        End If
    End Function



    Private Function GetLineID()
        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        If Conn.State = ConnectionState.Open Then
            Dim SQLcmd = New SqlCommand
            SQLcmd.Connection = Conn
            SQLcmd.CommandText = "SELECT [LineID]
                              FROM [CRICUT].[CUPID].[LineMaster] WHERE [Line]='" & LineBox.Text & "' AND [Delete]='False'"
            Dim ds = SQLcmd.ExecuteReader
            If ds.HasRows Then
                While ds.Read
                    LID = ds.Item("LineID")
                End While
            End If
        End If
    End Function

    Private Function LoadComboBox()
        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        If Conn.State = ConnectionState.Open Then
            Dim SQLcmd = New SqlCommand
            SQLcmd.Connection = Conn
            SQLcmd.CommandText = "SELECT [Part Name]
                              FROM [CRICUT].[CUPID].[PartMaster] WHERE [Delete]='False'"
            Dim ds = SQLcmd.ExecuteReader
            If ds.HasRows Then
                While ds.Read
                    PartNo.Items.Add(ds.Item("Part Name"))
                End While
            End If
            ds.Close()
            SQLcmd.CommandText = "SELECT [Model]
                              FROM [CRICUT].[CUPID].[ModelMaster] WHERE [Delete]='False'"
            ds = SQLcmd.ExecuteReader
            If ds.HasRows Then
                While ds.Read
                    ModelNo.Items.Add(ds.Item("Model"))
                End While
            End If
            ds.Close()
            SQLcmd.CommandText = "SELECT [Line]
                              FROM [CRICUT].[CUPID].[LineMaster] WHERE [Delete]='False'"
            ds = SQLcmd.ExecuteReader
            If ds.HasRows Then
                While ds.Read
                    LineBox.Items.Add(ds.Item("Line"))
                End While
            End If
            ds.Close()

        End If

        Conn.Close()
    End Function

    Private Sub ModelNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ModelNo.SelectedIndexChanged
        GetModelID()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim f1 = New frmHelp
        If Text.Contains("Update") Then
            f1.helptitle = "updateworkorder"

        Else
            f1.helptitle = "addworkorder"

        End If
        f1.Owner = Me
        f1.ShowDialog()
    End Sub

    Private Sub LineBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LineBox.SelectedIndexChanged
        GetLineID()
    End Sub

    Private Sub WorkOrder_TextChanged(sender As Object, e As EventArgs) Handles WorkOrder.TextChanged

        If Not CheckPO(WorkOrder.Text) = True Then
            txtPO.Text = ""
        Else
            statuslbl.Text = ""
            Label8.Text = ""
        End If


        If statuslbl.Text = "" Then
            Label8.Text = ""
        Else
            Label8.Text = "Check Details"
        End If



        SubGroup.Enabled = True
        LineBox.Enabled = True
        PartNo.Enabled = True
        ModelNo.Enabled = True
        count.Enabled = True
        ComboBox1.Enabled = True
        txtDescription.Enabled = True
    End Sub

    Private Function CheckPO(workorder As String)

        Try
            Dim res As Boolean
            Dim Conn = New SqlConnection(connstr)
            Conn.Open()
            If Conn.State = ConnectionState.Open Then
                Dim SQLcmd = New SqlCommand
                SQLcmd.Connection = Conn
                'SQLcmd.CommandText = "SELECT *
                'From [CRICUT].[CUPID].[WorkOrder] WHERE [Work Order ID]='" & WID.ToString & "'AND  [Serial No]='" & SerialNo & "' "

                'remove wm.[Work Order] = '" & cmbWorkOrderBox.Text & "'And wm.[Sub Group]='" & cmbSubGroup.Text & "' And


                SQLcmd.CommandText = "SELECT [Customer_PO_Number]
                        
                                      FROM [Cricut_MES].[dbo].[ProductionOrder]
                                      WHERE [Plant_Production_Order_ID] = '" & workorder & "'"

                'SQLcmd.CommandText = "SELECT w.[Pallet No],w.[Serial No],wm.[Work Order],wm.[Sub Group]

                '                          FROM [CRICUT].[CUPID].[WorkOrderMaster] wm
                '                          INNER JOIN [CRICUT].[CUPID].[WorkOrderPalletizing] w
                '                          ON wm.[Work Order ID]=w.[Work Order ID]
                '                          WHERE w.[Serial No] = '" & DataGridView1.Rows(i).Cells("Serial No").Value & "' AND [Pallet No] = '" & PalletBox.Text & "'"



                Dim ds = SQLcmd.ExecuteReader
                If ds.HasRows Then
                    res = True
                    While ds.Read
                        txtPO.Text = ds.Item("Customer_PO_Number")
                    End While
                Else
                    res = False
                    statuslbl.Text = ""
                    statuslbl.Text = "PO No. Not Exist"
                End If
            End If
            Conn.Close()

            Return res
        Catch ex As Exception
            Return False
        End Try


    End Function

    Private Function CheckDuplicateSub() As Boolean
        statuslbl.Text = ""
        Dim cond As String = ""
        If Text.Contains("Update") Then
            cond = " Not [Index]='" & frmWorkOrderMaster.DataGridView1.CurrentRow.Cells("No").Value.ToString & "' AND"
        End If
        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        Dim SQLcmd = New SqlCommand
        SQLcmd.Connection = Conn
        SQLcmd.CommandText = "Select [Work Order],[Sub Group]
                          FROM [CRICUT].[CUPID].[WorkOrderMaster] 
                          WHERE " & cond & "[Sub Group] = '" & SubGroup.Text & "' AND " & cond & "[Work Order] = '" & WorkOrder.Text & "' AND [Delete]='False'"

        Dim ds = SQLcmd.ExecuteReader
        If ds.HasRows Then
            While ds.Read
                statuslbl.Text = "Duplicate Item Found. Please Try Again. " & ds.Item("Sub Group")

            End While
            Return True
        Else
            statuslbl.Text = ""
            Return False
        End If
    End Function

    Private Sub WorkOrder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles WorkOrder.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            If CheckPO(WorkOrder.Text) = True Then
                SubGroup.Select()
                statuslbl.Text = ""
                Label8.Text = ""
            Else
                txtPO.Text = ""
            End If


        End If
    End Sub



    Private Function getWorkOrderID() As String
        Dim conn As New SqlConnection(connstr)
        Dim id As New Guid
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim i = frmWorkOrderMaster.DataGridView1.CurrentRow.Cells("No").Value.ToString
                Dim wo = frmWorkOrderMaster.DataGridView1.CurrentRow.Cells("Work Order").Value.ToString

                Dim query = "SELECT [Index],[Work Order ID]
                            FROM [CRICUT].[CUPID].[WorkOrderMaster]
                            WHERE [Index] = '" & i & "' or [Work Order] = '" & wo & "'"

                Using sqlcmd As New SqlCommand(query, conn)
                    Dim ds = sqlcmd.ExecuteReader()
                    If ds.HasRows Then
                        While ds.Read
                            id = ds.GetValue(ds.GetOrdinal("Work Order ID"))
                        End While
                    End If
                End Using
                conn.Close()
                Return id.ToString()
            End If
        Catch ex As Exception
            conn?.Close()
            Return ""
        End Try
    End Function

    Private Function workOrderShipping_State() As Boolean
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()


            Dim i = frmWorkOrderMaster.DataGridView1.CurrentRow.Cells("No").Value.ToString
            Dim wo = frmWorkOrderMaster.DataGridView1.CurrentRow.Cells("Work Order").Value.ToString

            If conn.State = ConnectionState.Open Then
                Dim GetID_Query = "SELECT WOM.[Index],WOM.[Work Order ID],WOM.[Work Order],WOM.[Sub Group]
                                    FROM [CRICUT].[CUPID].[WorkOrderMaster] WOM
                                    INNER JOIN [CRICUT].[CUPID].[ContainerShipping] CS ON WOM.[Work Order ID] = CS.[Word Order ID]
                                    WHERE WOM.[Index] = '" & i & "'
                                    OR WOM.[Work Order] = '" & wo & "'"

                Using GetID_cmd As New SqlCommand(GetID_Query, conn)
                    Dim ds = GetID_cmd.ExecuteReader()
                    If ds.HasRows Then
                        Return True
                    End If
                End Using
                conn.Close()
                Return False
            End If
        Catch ex As Exception
            conn?.Close()
            Return True
        Finally
            conn?.Close()
        End Try
    End Function



End Class