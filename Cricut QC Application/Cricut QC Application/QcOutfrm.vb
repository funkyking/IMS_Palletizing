Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class QcOutfrm


    Private connstr As String = ReadValue("System", "SQLconnstr", IniPath)
    Dim SerialNo = ""
    Dim WorkOrderRowCount = 0


    'Public WID As Guid
    'Dim PalletNo = ""
    'Dim Shift = ""


#Region "Functions"

    Private Function QCoutfunc()
        Try
            For Each item In ListBox1.Items
                SerialNo = item.ToString()

                ' Insert Serial To QClog Indicating Status
                If AddItemtoQClogDb() Then

                    ' Remove item from Work ORder
                    If removeItemfromWorkOrderDb() Then

                        ' -1 [Count] Value in Work Order Master
                        If decrementCountInDb() Then
                            Continue For
                        End If
                    End If
                End If
            Next

            ' Resets the Work Order Row Count to Tally with the PalletScanComplete Status and WorkOrderMaster [Count]
            ' This Makes Sure the the WorkOrder row count And WorkOrderMaster [Count] Values Tally
            If ResetWorkOrderRowCount() Then
            End If

            If CheckAndUpdateCompletedStatus() Then
                If UpdatePalletScanCompleted() Then
                    ListBox1.Items.Clear()
                    Me.Close()
                End If
            Else
                statuslbl.Text = "Work Order Status Still Completed"
            End If
        Catch ex As Exception
            statuslbl.Text = ex.Message
        End Try
    End Function

    Public Function CheckExist()
        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        Dim SQLcmd = New SqlCommand
        SQLcmd.Connection = Conn
        SQLcmd.CommandText = "Select [Serial No]
                          FROM [CRICUT].[CUPID].[WorkOrder] WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "' AND [Serial No]='" & Serial.Text & "'"

        Dim ds = SQLcmd.ExecuteReader
        If ds.HasRows Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function CheckDuplicate()
        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        Dim SQLcmd = New SqlCommand
        SQLcmd.Connection = Conn
        SQLcmd.CommandText = "Select [Serial No]
                          FROM [CRICUT].[CUPID].[QCLog] WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "' AND [Serial No]='" & Serial.Text & "' AND [QCout]='True'"

        Dim ds = SQLcmd.ExecuteReader
        If ds.HasRows Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function getSerialData()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim SQLcmd As New SqlCommand
                SQLcmd.Connection = conn
                SQLcmd.CommandText = "
                                    SELECT DISTINCT [Serial No], [Pallet No], [Shift]
                                    FROM [CRICUT].[CUPID].[WorkOrder]
                                    WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'
                                    AND [Serial No] = '" & SerialNo & "'"

                Dim reader = SQLcmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    'SerialNo = reader.GetString(0)
                    'PalletNo = reader.GetString(1)
                    'Shift = reader.GetString(2)
                    conn?.Close()
                    Return True
                End If
            End If
        Catch ex As Exception
            conn?.Close()
            Return False
        End Try
    End Function

    Private Function removeItemfromWorkOrderDb()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim sqlcmd As New SqlCommand
                sqlcmd.Connection = conn
                sqlcmd.CommandText = "Delete FROM [CRICUT].[CUPID].[WorkOrder]
                                        WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'
                                        AND [Serial No] = '" & SerialNo & "' 
                                        AND [Pallet No] = '" & GlobalVariables.PalletNo & "' AND [Shift] = '" & GlobalVariables.Shift & "'"
                sqlcmd.ExecuteNonQuery()
                Return True
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            statuslbl.Text = ex.Message
            conn?.Close()
        Finally
            conn?.Close()
        End Try
    End Function

    Private Function AddItemtoQClogDb()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim SQLcmd As New SqlCommand
                SQLcmd.Connection = conn
                SQLcmd.CommandText = "MERGE INTO [CRICUT].[CUPID].[QCLog] AS Target
                                        USING (VALUES
                                                ('" & GlobalVariables.WorkOrderID.ToString() & "', '" & SerialNo & "')
                                                ) AS Source ([Work Order ID], [Serial No])
                                        ON Target.[Work Order ID] = Source.[Work Order ID] AND Target.[Serial No] = Source.[Serial No]
                                        WHEN MATCHED THEN
                                            UPDATE SET
                                                [Work Order] = '" & GlobalVariables.WorkOrder & "',
                                                [Sub Group] = '" & GlobalVariables.SubGroup & "',
                                                [Pallet No] = '" & GlobalVariables.PalletNo & "',
                                                [Shift] = '" & GlobalVariables.Shift & "',
                                                [QCout] = 1,
                                                [QCout WID] = '" & GlobalVariables.WorkOrderID.ToString() & "',
                                                [OutDate] = GETDATE(),
                                                [OutUser] = '" & GlobalVariables.UserName & "',
                                                [QCin] = 0
                                        WHEN NOT MATCHED THEN
                                            INSERT ([LogID], [Work Order ID], [Work Order], [Serial No], [Sub Group], [Pallet No], [Shift], [QCout], [QCout WID],[OutDate], [OutUser])
                                            VALUES (NEWID(), '" & GlobalVariables.WorkOrderID.ToString() & "', '" & GlobalVariables.WorkOrder & "',
                                                    '" & SerialNo & "', '" & GlobalVariables.SubGroup & "',
                                                    '" & GlobalVariables.PalletNo & "', '" & GlobalVariables.Shift & "',
                                                    1, '" & GlobalVariables.WorkOrderID.ToString() & "', GETDATE(), '" & GlobalVariables.UserName & "');"

                SQLcmd.ExecuteNonQuery()
                conn?.Close()
                Return True
            End If
        Catch ex As Exception
            statuslbl.Text = ex.Message
            conn?.Close()
            Return False
        End Try
    End Function

    Private Function decrementCountInDb()
        Try
            Using conn As New SqlConnection(connstr)
                conn.Open()
                Dim sqlcmd As New SqlCommand
                sqlcmd.Connection = conn
                sqlcmd.CommandText = "UPDATE [CRICUT].[CUPID].[WorkOrderMaster]
                                         SET [Count] = [Count] - 1
                                         WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'"
                sqlcmd.ExecuteNonQuery()
                Return True
                conn?.Close()
            End Using
        Catch ex As Exception
            statuslbl.Text = ex.Message
            Return False
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

                ' Check if [Count] is less than [Total Order Count]
                Dim checkQuery As String = "SELECT CASE WHEN [Count] < [Total Order Count] THEN 1 ELSE 0 END AS Result 
                                            FROM [CRICUT].[CUPID].[WorkOrderMaster] WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'"

                Using checkCmd As New SqlCommand(checkQuery, conn)
                    Dim result As Integer = CInt(checkCmd.ExecuteScalar())

                    If result = 1 Then
                        ' If [Count] < [Total Order Count], update [Completed] to 0
                        Dim updateQuery As String = "UPDATE [CRICUT].[CUPID].[WorkOrderMaster] 
                                                    SET [Completed] = 0 
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

                ' Update PalletScanCompleted to 0 (false)
                Dim updateQuery As String = "UPDATE [CRICUT].[CUPID].[WorkOrderStatus]
                                       SET [PalletScanCompleted] = 0
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

    Private Sub QcOutfrm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Username.Text = GlobalVariables.UserName
        connstr = ReadValue("System", "SQLconnstr", IniPath)
    End Sub


    Private Sub cUser_btn_Click(sender As Object, e As EventArgs) Handles cUser_btn.Click
        Username.Text = GlobalVariables.UserName
    End Sub

    Private Sub Serial_TextChanged(sender As Object, e As EventArgs) Handles Serial.TextChanged
        Try
            If CheckExist() And Serial.Text <> "" Then
                statuslbl.Text = "Invalid Serial Number"
                Exit Sub
            Else
                statuslbl.Text = ""
            End If
            'If CheckDuplicate() And Serial.Text <> "" Then
            '    statuslbl.Text = "Item is already out"
            'End If
            For Each item In ListBox1.Items
                If item = Serial.Text Then
                    statuslbl.Text = "Duplicate Serial Number"
                End If
            Next
        Catch ex As Exception
            statuslbl.Text = ex.Message
        End Try
    End Sub

    Private Sub Serial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Serial.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                If Serial.Text = "" And ListBox1.Items.Count > 0 Then
                    Username.Select()
                Else
                    If statuslbl.Text <> "" Then
                        Exit Sub
                    Else
                        If Serial.Text <> "" Then
                            ListBox1.Items.Add(Serial.Text)
                            Serial.Text = ""
                            Serial.Select()
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        Try
            QCoutfunc()
        Catch ex As Exception
            'statuslbl.Text = ex.Message
        End Try
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub remove_btn_Click(sender As Object, e As EventArgs) Handles remove_btn.Click
        Try
            ListBox1.Items.Remove(ListBox1.SelectedItem.ToString())
        Catch ex As Exception
            statuslbl.Text = ex.Message
        End Try
    End Sub

    Private Sub clear_btn_Click(sender As Object, e As EventArgs) Handles clear_btn.Click
        Try
            ListBox1.Items.Clear()
        Catch ex As Exception
            statuslbl.Text = ex.Message
        End Try
    End Sub

    Private Sub QcOutfrm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            GlobalVariables.MainFrm.LoadGrid()
        Catch ex As Exception
        End Try
    End Sub
End Class