Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class QCIn


    Dim connstr = ReadValue("System", "SQLconnstr", IniPath)
    Dim LogID As Guid
    Dim OLD_WID As Guid
    Dim OLD_WO As String
    Dim SerialNo As String = ""
    Dim WorkOrderRowCount = 0
    Public slotsAvailable = 0
    Dim slotsCounter = 0
    'Public WID As Guid


    ' load Event
    Private Sub QCInvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connstr = ReadValue("System", "SQLconnstr", IniPath)
            slotsCounter = slotsAvailable
            remainingSlot_lbl.Text = slotsCounter
            Username.Text = GlobalVariables.UserName
            showAvailableSerialNumbers()
        Catch ex As Exception
        End Try
    End Sub



#Region "Functions"

    Private Function showAvailableSerialNumbers()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim SQLcmd As New SqlCommand()
                SQLcmd.Connection = conn
                SQLcmd.CommandText = "SELECT [Serial No]
                                      FROM [CRICUT].[CUPID].[QCLog]
                                      WHERE [QCout] = 1"
                Dim ds = SQLcmd.ExecuteReader()
                If ds.HasRows Then
                    AvailableSerialNo_lstbx.Items.Clear()
                    AvailableSerialNo_lstbx.Items.Add("<< Available Serial No's >>")
                    AvailableSerialNo_lstbx.Items.Add("")
                    Dim tempStr = ""
                    While ds.Read()
                        tempStr = ds.GetString(0)
                        If Not AvailableSerialNo_lstbx.Items.Contains(tempStr) Then
                            AvailableSerialNo_lstbx.Items.Add(tempStr)
                        End If
                    End While
                    conn.Close()
                End If
            End If
        Catch ex As Exception
            conn?.Close()
        Finally
            conn?.Close()
        End Try
    End Function


    Public Function CheckExist()
        Dim Conn = New SqlConnection(connstr)
        Try
            Conn.Open()
            Dim SQLcmd = New SqlCommand
            SQLcmd.Connection = Conn
            SQLcmd.CommandText = "Select DISTINCT [Work Order ID],[Serial No]
                                    FROM [CRICUT].[CUPID].[WorkOrder] 
                                    WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "' AND [Serial No]='" & Serial.Text & "'"
            Dim ds = SQLcmd.ExecuteReader
            ds.Read()
            If ds.HasRows Then
                Return True
            Else
                Return False
            End If
            Conn.Close()
        Catch ex As Exception
            Conn?.Close()
            statuslbl.Text = ex.Message
            Return True
        Finally
            Conn?.Close()
        End Try
    End Function

    Private Function CheckState() As Boolean
        Dim Conn As New SqlConnection(connstr)
        Conn.Open()
        Try
            Dim SQLcmd As New SqlCommand
            SQLcmd.Connection = Conn
            SQLcmd.CommandText = "SELECT [QCIn], [QCout], [Work Order ID]
                     FROM [CRICUT].[CUPID].[QCLog] 
                     WHERE [Serial No] = '" & Serial.Text & "'"
            Dim reader As SqlDataReader = SQLcmd.ExecuteReader()

            If reader.Read() Then
                If Not reader.IsDBNull(reader.GetOrdinal("Work Order ID")) Then
                    OLD_WID = DirectCast(reader("Work Order ID"), Guid)
                Else
                    OLD_WID = Guid.Empty ' Assign a default value when it's DBNull
                End If

                Dim qcIn As Boolean = If(Not reader.IsDBNull(reader.GetOrdinal("QCIn")), reader.GetBoolean(reader.GetOrdinal("QCIn")), False)
                Dim qcOut As Boolean = If(Not reader.IsDBNull(reader.GetOrdinal("QCout")), reader.GetBoolean(reader.GetOrdinal("QCout")), False)

                If OLD_WID <> Guid.Empty AndAlso OLD_WID.ToString() <> GlobalVariables.WorkOrderID.ToString() Then
                    'statuslbl.Text = "Serial No, not from this Work Order"
                Else
                    'statuslbl.Text = "Serial No, is from this Work Order"
                End If

                If Not qcIn AndAlso qcOut Then
                    Return True ' Item is outside
                Else
                    Return False ' Item is not outside
                    statuslbl.Text = "Item Is Not Outside"
                End If
            Else
                'statuslbl.Text = "Serial Is Not Out or Don't Exist"
                Return False ' No matching records
            End If
        Catch ex As Exception
            statuslbl.Text = ex.Message
            Conn?.Close()
        Finally
            Conn?.Close()
        End Try
    End Function

    Private Function CheckQC()
        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        Dim SQLcmd = New SqlCommand
        SQLcmd.Connection = Conn
        SQLcmd.CommandText = "Select [Serial No]
                          FROM [CRICUT].[CUPID].[WorkOrder] WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "' AND [QCout]='True' AND [Serial No]='" & Serial.Text & "'"

        Dim ds = SQLcmd.ExecuteReader
        If ds.HasRows Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function LoadQCGrid()
        Try
            Dim Conn = New SqlConnection(connstr)
            Conn.Open()
            Dim SQLcmd = New SqlCommand
            Dim strsql = "Select 
                               [Serial No] As [Serial No], [Pallet No],
                                [OutUser] As [OutUser],
                                [OutDate] As [OutDate],
                                [InUser] As [InUser],
                                [InDate] As [InDate]
                      FROM [CRICUT].[CUPID].[QCLog] WHERE [QCin]='True' AND [Work Order ID]='" & GlobalVariables.WorkOrderID.ToString() & "' Order By [Pallet No]"

            Dim dt = New DataTable
            dt.Clear()
            Dim da = New SqlDataAdapter(strsql, Conn)
            da.Fill(dt)
            da.Dispose()
            DataGridView1.DataSource = dt
            DataGridView1.ClearSelection()
            Conn.Close()
        Catch ex As Exception

        End Try
    End Function

    Private Function QCin()
        Dim Conn = New SqlConnection(connstr)
        Try
            For Each item In ListBox1.Items

                SerialNo = item.ToString()
                Conn.Open()
                If Conn.State = ConnectionState.Open Then


                    'Dim Sqlcmd1 As New SqlCommand()
                    'Sqlcmd1.Connection = Conn
                    'SQLcmd1.CommandText = "INSERT INTO [CRICUT].[CUPID].[QCLog]
                    '                       ([LogID],[Work Order ID],[Work Order],[Serial No],[Sub Group],[Pallet No],[Shift]
                    '                       ,[QCin],[InDate],[InUser])
                    '                       VALUES
                    '                       (NEWID(),'" & GlobalVariables.WorkOrderID.ToString() & "','" & GlobalVariables.WorkOrder & "',
                    '                       '" & SerialNo & "','" & GlobalVariables.SubGroup & "',
                    '                       '" & GlobalVariables.PalletNo & "','" & GlobalVariables.Shift & "',
                    '                       1,GETDATE(),'" & GlobalVariables.UserName & "')"

                    'SQLcmd1.ExecuteNonQuery()

                    Dim Sqlcmd1 As New SqlCommand()
                    Sqlcmd1.Connection = Conn
                    Sqlcmd1.CommandText = "MERGE INTO [CRICUT].[CUPID].[QCLog] AS Target
                                            USING (VALUES (
                                                NEWID(),
                                                '" & GlobalVariables.WorkOrderID.ToString() & "',
                                                '" & GlobalVariables.WorkOrder & "',
                                                '" & SerialNo & "',
                                                '" & GlobalVariables.SubGroup & "',
                                                '" & GlobalVariables.PalletNo & "',
                                                '" & GlobalVariables.Shift & "',
                                                0,
                                                1,
                                                GETDATE(),
                                                '" & GlobalVariables.UserName & "'
                                            )) AS Source ([LogID], [Work Order ID], [Work Order], [Serial No], [Sub Group], [Pallet No], [Shift], [QCout], [QCin], [InDate], [InUser])
                                            ON Target.[Work Order ID] = Source.[Work Order ID] AND Target.[Serial No] = Source.[Serial No]
                                            WHEN MATCHED THEN
                                                UPDATE SET
                                                    Target.[Work Order] = Source.[Work Order],
                                                    Target.[Sub Group] = Source.[Sub Group],
                                                    Target.[Pallet No] = Source.[Pallet No],
                                                    Target.[Shift] = Source.[Shift],
                                                    Target.[QCout] = Source.[QCout],
                                                    Target.[QCin] = Source.[QCin],
                                                    Target.[InDate] = Source.[InDate],
                                                    Target.[InUser] = Source.[InUser]
                                            WHEN NOT MATCHED THEN
                                                INSERT (
                                                    [LogID],
                                                    [Work Order ID],
                                                    [Work Order],
                                                    [Serial No],
                                                    [Sub Group],
                                                    [Pallet No],
                                                    [Shift],
                                                    [QCout],
                                                    [QCin],
                                                    [InDate],
                                                    [InUser]
                                                )
                                                VALUES (
                                                    Source.[LogID],
                                                    Source.[Work Order ID],
                                                    Source.[Work Order],
                                                    Source.[Serial No],
                                                    Source.[Sub Group],
                                                    Source.[Pallet No],
                                                    Source.[Shift],
                                                    Source.[QCout],
                                                    Source.[QCin],
                                                    Source.[InDate],
                                                    Source.[InUser]
                                                );"

                    Sqlcmd1.ExecuteNonQuery()







                    Dim SQLcmd2 = New SqlCommand
                    SQLcmd2.Connection = Conn
                    SQLcmd2.CommandText = "INSERT INTO [CRICUT].[CUPID].[WorkOrder]
                                            ([Work Order ID],[Line],[Serial No],[Pallet No],[Shift],[Production Date])
                                            VALUES
                                            ('" & GlobalVariables.WorkOrderID.ToString() & "', '" & GlobalVariables.Line & "',
                                            '" & SerialNo & "', '" & GlobalVariables.PalletNo & "', '" & GlobalVariables.Shift & "',
                                             GETDATE())"
                    SQLcmd2.ExecuteNonQuery()


                    Dim SQLcmd3 = New SqlCommand
                    SQLcmd3.Connection = Conn
                    SQLcmd3.CommandText = "Update [Cricut].[CUPID].[WorkOrderMaster]
                                        SET [Count] =+ 1
                                        WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'"
                    SQLcmd3.ExecuteNonQuery()






                    Conn.Close()
                End If
            Next

            If ResetWorkOrderRowCount() Then
                If CheckAndUpdateCompletedStatus() Then
                    UpdatePalletScanCompleted()
                Else
                    statuslbl.Text = "Work Order Status Still Completed"
                End If
            End If


        Catch ex As Exception
            Conn?.Close()
            statuslbl.Text = ex.Message
            'MessageBox.Show(ex.Message)
        Finally
            Conn?.Close()
        End Try
    End Function

    Private Function ResetWorkOrderRowCount()
        Try
            Using connection As New SqlConnection(connstr)
                connection.Open()

                ' Select the Count of rows in WorkOrder table
                Dim query As String = "SELECT COUNT(*) 
                                   FROM [CRICUT].[CUPID].[WorkOrder]
                                   WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'"
                Using cmd As New SqlCommand(query, connection)
                    ' Use ExecuteScalar to get the count as an object and convert it to Integer
                    Dim rowCount As Object = cmd.ExecuteScalar()
                    If rowCount IsNot Nothing AndAlso IsNumeric(rowCount) Then
                        WorkOrderRowCount = CInt(rowCount)
                    Else
                        Return False
                    End If

                    ' Update [Count] value in [WorkOrderMaster] table
                    Dim updateQuery As String = "UPDATE [CRICUT].[CUPID].[WorkOrderMaster] 
                                            SET [Count] = " & WorkOrderRowCount & " 
                                            WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'"
                    Using updateCmd As New SqlCommand(updateQuery, connection)
                        updateCmd.ExecuteNonQuery()
                    End Using
                End Using

                connection?.Close()
                Return True
            End Using
        Catch ex As Exception
            statuslbl.Text = ex.Message
            'MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Function CheckAndUpdateCompletedStatus() As Boolean
        Try
            Using conn As New SqlConnection(connstr)
                conn.Open()

                ' Check if [Count] is more or same [Total Order Count]
                Dim checkQuery As String = "SELECT CASE WHEN [Count] >= [Total Order Count] THEN 1 ELSE 0 END AS Result 
                                            FROM [CRICUT].[CUPID].[WorkOrderMaster] WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'"

                Using checkCmd As New SqlCommand(checkQuery, conn)
                    Dim result As Integer = CInt(checkCmd.ExecuteScalar())

                    If result = 1 Then
                        ' If [Count] >= [Total Order Count], update [Completed] to 0
                        Dim updateQuery As String = "UPDATE [CRICUT].[CUPID].[WorkOrderMaster] 
                                                    SET [Completed] = 1 
                                                    WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'"
                        Using updateCmd As New SqlCommand(updateQuery, conn)
                            updateCmd.ExecuteNonQuery()
                        End Using
                        conn?.Close()
                        Return True
                    Else
                        Return False
                    End If
                    conn?.Close()
                End Using
            End Using
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            statuslbl.Text = ex.Message
            Return False
        End Try
    End Function

    Private Function UpdatePalletScanCompleted()
        Try
            Using conn As New SqlConnection(connstr)
                conn.Open()

                ' Update PalletScanCompleted to 1 (True)
                Dim updateQuery As String = "UPDATE [CRICUT].[CUPID].[WorkOrderStatus]
                                       SET [PalletScanCompleted] = 1
                                       WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'
                                       AND [Pallet No] = '" & GlobalVariables.PalletNo & "'"
                Using updateCmd As New SqlCommand(updateQuery, conn)
                    updateCmd.ExecuteNonQuery()
                End Using
                conn?.Close()
            End Using
            Return True
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            statuslbl.Text = ex.Message
            Return False
        End Try
    End Function

#End Region


    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Try
            DataGridView1.Columns.Item("Serial No").Width = 75
            DataGridView1.Columns.Item("Pallet No").Width = 75
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells("InUser").Value.ToString = "" Then
                    DataGridView1.Rows(i).Cells("Serial No").Style.BackColor = Color.PaleVioletRed
                    DataGridView1.Rows(i).Cells("Pallet No").Style.BackColor = Color.PaleVioletRed
                    DataGridView1.Rows(i).Cells("OutUser").Style.BackColor = Color.PaleVioletRed
                    DataGridView1.Rows(i).Cells("OutDate").Style.BackColor = Color.PaleVioletRed
                    DataGridView1.Rows(i).Cells("InUser").Style.BackColor = Color.PaleVioletRed
                    DataGridView1.Rows(i).Cells("InDate").Style.BackColor = Color.PaleVioletRed
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CurrentUserSelect_btn_Click(sender As Object, e As EventArgs) Handles CurrentUserSelect_btn.Click
        Try
            Username.Text = GlobalVariables.UserName
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Username_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Username.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                If Username.Text = "" Then
                    statuslbl.Text = "Username Field Missing"
                Else
                    statuslbl.Text = ""
                End If
                If ListBox1.Items.Count = 0 Then
                    statuslbl.Text = "Empty Serial Number"
                End If
                If statuslbl.Text <> "" Then
                    Exit Sub
                End If
                Dim res = MessageBox.Show("Confirm Add QC In?" & vbCrLf & "Username:" & Username.Text, "Confirm Operation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                If res = DialogResult.Yes Then
                    QCin()
                    LoadQCGrid()
                    Serial.Text = ""
                    ListBox1.Items.Clear()
                    Username.Text = ""
                    Serial.Select()

                Else
                    Exit Sub
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Serial_TextChanged(sender As Object, e As EventArgs) Handles Serial.TextChanged
        Try
            statuslbl.Text = ""
            If CheckExist() Then
                statuslbl.Text = "The Item Is Already In the Pallet"
                Exit Sub
            End If
            For Each item In ListBox1.Items
                If item = Serial.Text Then
                    statuslbl.Text = "Duplicate Serial Number"
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Serial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Serial.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                If Serial.Text = "" And ListBox1.Items.Count <> 0 Then
                    Username.Select()
                    Exit Sub
                ElseIf slotsCounter <= 0
                    statuslbl.Text = "Pallet Is Full. Can't Add more Items."
                Else
                    If CheckState() Then
                        'statuslbl.Text = "This Item is Already In"
                        If statuslbl.Text <> "" Then
                            Exit Sub
                        Else
                            If Serial.Text <> "" Then
                                ListBox1.Items.Add(Serial.Text)
                                slotsCounter -= 1
                                remainingSlot_lbl.Text = slotsCounter
                                Serial.Text = ""
                                Serial.Select()
                            End If
                        End If
                    Else
                        Exit Sub
                    End If


                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        Try
            If Username.Text = "" Then
                statuslbl.Text = "Missing Username Field"
            Else
                statuslbl.Text = ""
            End If
            If ListBox1.Items.Count = 0 Then
                statuslbl.Text = "Empty Serial Number"
            End If
            If statuslbl.Text <> "" Then
                Exit Sub
            End If
            QCin()
            LoadQCGrid()
            Serial.Text = ""
            ListBox1.Items.Clear()
            Username.Text = ""
            Serial.Select()

            'Dim res = MessageBox.Show("Confirm Add QC In?" & vbCrLf & "Username:" & Username.Text, "Confirm Operation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
            'If res = DialogResult.Yes Then

            '    'Me.Close()
            'Else
            '    Exit Sub
            'End If
        Catch ex As Exception
            statuslbl.Text = ex.Message()
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Username_TextChanged(sender As Object, e As EventArgs) Handles Username.TextChanged
        Try
            statuslbl.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub clear_btn_Click(sender As Object, e As EventArgs) Handles clear_btn.Click
        Try
            ListBox1.Items.Clear()
            slotsCounter = slotsAvailable
            remainingSlot_lbl.Text = slotsCounter
        Catch ex As Exception
            statuslbl.Text = ex.Message
        End Try
    End Sub

    Private Sub remove_btn_Click(sender As Object, e As EventArgs) Handles remove_btn.Click
        Try
            ListBox1.Items.Remove(ListBox1.SelectedItem.ToString())
            slotsCounter += 1
            remainingSlot_lbl.Text = slotsCounter
        Catch ex As Exception
            statuslbl.Text = ex.Message
        End Try
    End Sub

    Private Sub QCIn_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            GlobalVariables.MainFrm.LoadGrid()
        Catch ex As Exception
        End Try
    End Sub
End Class