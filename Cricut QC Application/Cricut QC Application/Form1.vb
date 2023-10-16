Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class Form1



#Region "Variables"

    'Work Order ID
    Private WID As Guid
    Private _workOrder As String
    Private _poNo As String
    Private _subGroup As String
    Private _palletNo As String
    Private _shift As String
    Private _quantity As Integer
    Private _count As Integer
    Private _totalOrderCount As Integer
    Private _completed As String
    Private _currentUsedPalletQuantity As String
    Private WorkOrderRowCount = 0

    Dim connstr = ReadValue("System", "SQLconnstr", IniPath)

#End Region



#Region "Load and Exit Events"


    ' Load event
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'LoadGrid()
            PopulateWorkOrderCombobox()
            ConfigureComboboxes()
            GlobalVariables.MainFrm = Me
            'PopulatePoNumberCombobox()
        Catch ex As Exception
        End Try
    End Sub


    ' Exit events (Closes the login form as its the main form)
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            GlobalVariables.loginfrm.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ConfigureComboboxes()
        Try
            For Each combobox As ComboBox In Me.Controls.OfType(Of ComboBox)
                combobox.AutoCompleteMode = AutoCompleteMode.Suggest
                combobox.AutoCompleteSource = AutoCompleteSource.ListItems
                combobox.DropDownStyle = ComboBoxStyle.DropDown
            Next
        Catch ex As Exception

        End Try
    End Sub

#End Region


#Region "Functions"

    Public Function LoadGrid()
        Dim Conn = New SqlConnection(connstr)
        Try
            Dim strsql = "SELECT [Serial No], [Work Order], [Sub Group], [Pallet No], [Shift], [QCout],[OutDate], [OutUser], [QCin], [InDate], [InUser], [QCout WID]
                            FROM [CRICUT].[CUPID].[QCLog] qc
                            WHERE qc.[Work Order] = '" & _workOrder & "' AND qc.[Sub Group] = '" & _subGroup & "' AND qc.[Shift] = '" & _shift & "' AND qc.[Pallet No] = '" & _palletNo & "'
                            UNION
                            SELECT wo.[Serial No], wom.[Work Order], wom.[Sub Group], wo.[Pallet No], wo.[Shift], wo.[QCout], wo.[OutDate], wo.[OutUser], wo.[QCin], wo.[InDate], wo.[InUser], NULL AS [QCout WID]
                            FROM [CRICUT].[CUPID].[WorkOrder] wo
                            INNER JOIN [CRICUT].[CUPID].[WorkOrderMaster] wom ON wom.[Work Order ID] = wo.[Work Order ID]
                            WHERE wom.[Work Order] = '" & _workOrder & "' AND wom.[Sub Group] = '" & _subGroup & "' AND wo.[Shift] = '" & _shift & "' AND wo.[Pallet No] = '" & _palletNo & "'
                            AND NOT EXISTS (
                                SELECT 1
                                FROM [CRICUT].[CUPID].[QCLog] qc
                                WHERE qc.[Work Order] = '" & _workOrder & "' AND qc.[Sub Group] = '" & _subGroup & "' AND qc.[Shift] = '" & _shift & "' AND qc.[Pallet No] = '" & _palletNo & "'
                                AND qc.[Serial No] = wo.[Serial No]
                            )
                            ORDER BY [Sub Group]"

            Conn.Open()
            Threading.Thread.Sleep(300)
            Dim dt = New DataTable
            dt.Clear()
            Dim da = New SqlDataAdapter(strsql, Conn)
            da.Fill(dt)

            If Not dt.Rows.Count > 0 Then
                status_lbl.Text = "Incomplete Table"
                UpdateListBox("Incomplete Table", True, False)
            End If

            da.Dispose()
            DataGridView1.DataSource = dt
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            status_lbl.Text = ex.Message
            Conn?.Close()
        Finally
            Conn?.Close()
            'getWorkOrderID()
        End Try
    End Function

    Private Function splitMasterBarcodeInput(ByRef Input)
        Try
            Dim strSplit() As String = Input.Split(",")
            If strSplit.Length >= 5 Then
                _poNo = strSplit(0)
                _workOrder = strSplit(1)
                _subGroup = strSplit(2)
                _palletNo = strSplit(3)
                _shift = strSplit(4)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub PopulateWorkOrderCombobox()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim sqlcmd As New SqlCommand
                sqlcmd.Connection = conn
                sqlcmd.CommandText = "SELECT [Work Order], [Sub Group]
                                        FROM [CRICUT].[CUPID].[WorkOrderMaster]
                                        WHERE [Sub Group] != ''"
                Dim ds = sqlcmd.ExecuteReader()
                If ds.HasRows Then
                    workOrder_cmbx.Items.Clear()
                    Dim str = ""
                    While ds.Read()
                        str = ds.GetString(0)
                        If Not workOrder_cmbx.Items.Contains(str) Then
                            workOrder_cmbx.Items.Add(str)
                        End If
                    End While
                End If
                conn?.Close()
            End If
        Catch ex As Exception
            conn?.Close()
        Finally
            conn?.Close()
        End Try
    End Sub

    Private Function GetPoNumber()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim SQLcmd As New SqlCommand
                SQLcmd.Connection = conn
                SQLcmd.CommandText = "SELECT [Po Number],[Work Order ID]
                                    FROM [CRICUT].[CUPID].[WorkOrderMaster]
                                    Where [Work Order] = '" & _workOrder & "'
                                    AND [Sub Group] != ''"
                Dim ds = SQLcmd.ExecuteReader()
                If ds.HasRows Then
                    While ds.Read()
                        If ds.IsDBNull(ds.GetOrdinal("Po Number")) Then
                            _poNo = "NULL"
                        Else
                            _poNo = ds.GetValue(ds.GetOrdinal("Po Number"))
                        End If
                    End While
                    conn?.Close()
                    Return True
                Else
                    Return False
                End If

            End If
        Catch ex As Exception
            UpdateListBox(ex.Message, True, False)
            status_lbl.Text = ex.Message()
        Finally
            conn?.Close()
        End Try
    End Function

    Private Sub PopulateSubGroupCombobox()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim sqlcmd As New SqlCommand
                sqlcmd.Connection = conn
                sqlcmd.CommandText = "SELECT [Sub Group]
                                        FROM [CRICUT].[CUPID].[WorkOrderMaster]
                                        WHERE [Work Order] = '" & _workOrder & "'"
                Dim ds = sqlcmd.ExecuteReader()
                If ds.HasRows Then
                    subGroup_cmbx.Items.Clear()
                    Dim str = ""
                    While ds.Read()
                        str = ds.GetString(0)
                        If Not subGroup_cmbx.Items.Contains(str) Then
                            subGroup_cmbx.Items.Add(str)
                        End If
                    End While
                End If
                conn?.Close()
            End If
        Catch ex As Exception
            conn?.Close()
        Finally
            conn?.Close()
        End Try
    End Sub

    Private Sub PopulatePalletNoCombobox()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim sqlcmd As New SqlCommand
                sqlcmd.Connection = conn
                sqlcmd.CommandText = "SELECT DISTINCT wo.[Pallet No]
                                        FROM [CRICUT].[CUPID].[WorkOrderMaster] wom
                                        INNER JOIN [CRICUT].[CUPID].[WorkOrder] wo
                                        On wom.[Work Order ID] = wo.[Work Order ID] 
                                        WHERE [Work Order] = '" & _workOrder & "' AND [Sub Group] = '" & _subGroup & "'"

                Dim ds = sqlcmd.ExecuteReader()
                If ds.HasRows Then
                    pallet_cmbx.Items.Clear()
                    Dim str = ""
                    While ds.Read()
                        str = ds.GetString(0)
                        If Not pallet_cmbx.Items.Contains(str) Then
                            pallet_cmbx.Items.Add(str)
                        End If
                    End While
                End If
                conn?.Close()
            End If
        Catch ex As Exception
            conn?.Close()
        Finally
            conn?.Close()
        End Try
    End Sub

    Private Sub PopulateShiftCombobox()
        Try
            shift_cmbx.Items.Clear()
            shift_cmbx.Items.Add("DAY")
            shift_cmbx.Items.Add("NIGHT")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DeleteRecords()
        Try
            Dim res = MessageBox.Show("Comfirm Delete QC Record?" & vbCrLf & "Serial No: " & DataGridView1.CurrentRow.Cells("Serial No").Value.ToString, "Comfirm Operation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
            If res = DialogResult.Yes Then
                Dim Conn = New SqlConnection(connstr)
                Conn.Open()
                If Conn.State = ConnectionState.Open Then
                    Dim SQLcmd = New SqlCommand
                    SQLcmd.Connection = Conn
                    SQLcmd.CommandText = "UPDATE  [CRICUT].[CUPID].[WorkOrder]
                                             SET [QCout] = 'False',
                                                [OutUser]=NULL,
                                                [OutDate]=NULL,
                                                [QCin]='False',
                                                [InUser]=NULL,
                                                [InDate]=NULL
                                     WHERE [Serial No] = '" & DataGridView1.CurrentRow.Cells("Serial No").Value.ToString & "'"
                    SQLcmd.ExecuteNonQuery()
                    Conn.Close()
                End If
            End If
            LoadGrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Function getWorkOrderID()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then

                Dim SQLcmd As New SqlCommand()
                SQLcmd.Connection = conn
                SQLcmd.CommandText = "SELECT [Work Order ID], [Po Number],
                                      [Work Order],[Quantity],[Count],[Total Order Count],[Completed]
                                      FROM [CRICUT].[CUPID].[WorkOrderMaster]
                                      WHERE [Work Order] = '" & _workOrder & "'
                                      AND [Sub Group] = '" & _subGroup & "'"
                Dim ds = SQLcmd.ExecuteReader()
                If ds.HasRows Then
                    ds.Read()
                    'If Not ds.IsDBNull(ds.GetValue(ds.GetOrdinal("Po Number"))) Then
                    '    _poNo = ds.GetValue(ds.GetOrdinal("Po Number"))
                    'Else
                    '    _poNo = "NULL"
                    'End If
                    WID = ds.GetValue(ds.GetOrdinal("Work Order ID"))
                    _quantity = ds.GetValue(ds.GetOrdinal("Quantity"))
                    _count = ds.GetValue(ds.GetOrdinal("Count"))
                    _totalOrderCount = ds.GetValue(ds.GetOrdinal("Total Order Count"))
                    _completed = ds.GetValue(ds.GetOrdinal("Completed"))
                    conn?.Close()
                End If
            End If
        Catch ex As Exception
            status_lbl.Text = "Error Retrieving Work Order ID"
            UpdateListBox(status_lbl.Text, True, False)
            conn?.Close()
        Finally
            conn?.Close()
        End Try
    End Function

    Private Function checkWorkOrderStatusExistence()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim sqlcmd As New SqlCommand()
                sqlcmd.Connection = conn
                sqlcmd.CommandText = "SELECT Top 100 [Work Order ID]
                                      FROM [CRICUT].[CUPID].[WorkOrderStatus]
                                      WHERE [Work Order ID] = '" & WID.ToString() & "'
                                      AND [Work Order] = '" & _workOrder & "'
                                      AND [Pallet No] = '" & _palletNo & "'
                                      AND [Sub Group] = '" & _subGroup & "'
                                      AND [Shift] = '" & _shift & "'"

                Dim ds = sqlcmd.ExecuteReader()
                If ds.HasRows Then
                    conn?.Close()
                    Return True
                Else
                    conn?.Close()
                    Return False
                End If
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            status_lbl.Text = ex.Message
        End Try
    End Function

    ' [Input] text to display, [Clear] removes all items, [Status] true is green and false is RED
    Private Sub UpdateListBox(ByVal input As String, ByVal clear As Boolean, ByVal Status As Boolean)
        Try

            If Me.InvokeRequired Then
                If clear Then
                    Me.Invoke(New Action(Sub()
                                             ListBox1.Items.Clear()
                                         End Sub))
                End If
                Me.Invoke(New Action(Sub()
                                         ListBox1.Items.Add(input)
                                     End Sub))

                If Status Then
                    Me.Invoke(New Action(Sub()
                                             ListBox1.ForeColor = Color.Lime
                                         End Sub))
                Else
                    Me.Invoke(New Action(Sub()
                                             ListBox1.ForeColor = Color.Red
                                         End Sub))
                End If

            Else
                If clear Then
                    ListBox1.Items.Clear()
                End If
                ListBox1.Items.Add(input)

                If Status Then
                    ListBox1.ForeColor = Color.Lime
                Else
                    ListBox1.ForeColor = Color.Red
                End If

            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Function comboboxInputCheck()
        Try
            UpdateListBox("  <::..Current Selection..::>", True, True)
            UpdateListBox("", False, True)

            If poNumber_txtbx.Text IsNot Nothing Then
                UpdateListBox("PO Number: " + poNumber_txtbx.Text, False, True)
            Else
                UpdateListBox("PO Number: nothing", False, True)
            End If

            If workOrder_cmbx.SelectedItem IsNot Nothing Then
                UpdateListBox("Container: " + workOrder_cmbx.SelectedItem.ToString(), False, True)
            Else
                UpdateListBox("Container: nothing", False, True)
            End If

            If subGroup_cmbx.SelectedItem IsNot Nothing Then
                UpdateListBox("Sub Group: " + subGroup_cmbx.SelectedItem.ToString(), False, True)
            Else
                UpdateListBox("Sub Group: Nothing", False, True)
            End If

            If pallet_cmbx.SelectedItem IsNot Nothing Then
                UpdateListBox("Pallet No: " + pallet_cmbx.SelectedItem.ToString(), False, True)
            Else
                UpdateListBox("Pallet No: Nothing", False, True)
            End If

            If shift_cmbx.SelectedItem IsNot Nothing Then
                UpdateListBox("Shift: " + shift_cmbx.SelectedItem.ToString(), False, True)
            Else
                UpdateListBox("Shift: Nothing", False, True)
            End If
        Catch ex As Exception
        End Try
    End Function

    Private Function checkPalletQuantity()
        Try
            Dim Conn = New SqlConnection(connstr)
            Conn.Open()
            If Conn.State = ConnectionState.Open Then
                ' Select the Count of rows in WorkOrder table
                Dim query As String = "SELECT COUNT(*) 
                                   FROM [CRICUT].[CUPID].[WorkOrder]
                                   WHERE [Work Order ID] = '" & WID.ToString() & "'
                                   AND [Pallet No] = '" & _palletNo & "'"
                Using cmd As New SqlCommand(query, Conn)
                    ' Use ExecuteScalar to get the count as an object and convert it to Integer
                    Dim rowCount As Object = cmd.ExecuteScalar()
                    If rowCount IsNot Nothing AndAlso IsNumeric(rowCount) Then
                        _currentUsedPalletQuantity = CInt(rowCount)
                    Else
                        Return False
                    End If


                    If _currentUsedPalletQuantity < _quantity Then
                        status_lbl.Text = ""
                        UpdateListBox("<<<Pallet Available>>>", True, True)
                        UpdateListBox("Option: QCin & QCout", False, True)
                        UpdateListBox($"Used: {_currentUsedPalletQuantity}", False, True)
                        UpdateListBox($"Available: {_quantity}", False, True)
                        UpdateListBox($"Total Count: {_count}", False, True)
                        UpdateListBox($"Total Order Count: {_totalOrderCount}", False, True)
                        UpdateListBox($"Completed Status: {_completed}", False, True)

                        Return True
                    Else
                        status_lbl.Text = "Pallet Full"
                        UpdateListBox("<<<Pallet Full>>>", True, True)
                        UpdateListBox($"Option: QCout", False, True)
                        UpdateListBox($"Used: {_currentUsedPalletQuantity}", False, True)
                        UpdateListBox($"Available: {_quantity}", False, True)
                        UpdateListBox($"Total Count: {_count}", False, True)
                        UpdateListBox($"Total Order Count: {_totalOrderCount}", False, True)
                        UpdateListBox($"Completed Status: {_completed}", False, True)
                        Return False
                    End If
                    Conn?.Close()
                End Using
            End If
        Catch ex As Exception
        End Try
    End Function

    Private Sub AllocateGlobalVariables()
        Try
            GlobalVariables.WorkOrderID = WID
            GlobalVariables.WorkOrder = _workOrder
            GlobalVariables.SubGroup = _subGroup
            GlobalVariables.PalletNo = _palletNo
            GlobalVariables.Shift = _shift
            GlobalVariables.Quantity = _quantity
            GlobalVariables.Count = _count
            GlobalVariables.TotalOrderCount = _totalOrderCount
            GlobalVariables.Completed = _completed
        Catch ex As Exception
        End Try
    End Sub


    Private Function UpdateCompleteStatus()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                ' Select the Count of rows in WorkOrder table
                Dim query As String = "SELECT COUNT(*) 
                                   FROM [CRICUT].[CUPID].[WorkOrder]
                                   WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'
                                   AND [Shift] = '" & GlobalVariables.Shift & "'"
                Using cmd As New SqlCommand(query, conn)
                    ' Use ExecuteScalar to get the count as an object and convert it to Integer
                    Dim rowCount As Object = cmd.ExecuteScalar()
                    If rowCount IsNot Nothing AndAlso IsNumeric(rowCount) Then
                        WorkOrderRowCount = CInt(rowCount)
                    Else
                        Return False
                    End If
                End Using

                If Not WorkOrderRowCount > 0 Then
                    UpdateListBox("This Pallet Does", True, False)
                    UpdateListBox("Not Exist ", False, False)
                    Return False
                End If

                Try
                    ' Update [Count] value in [WorkOrderMaster] table
                    Dim updateQuery As String = "UPDATE [CRICUT].[CUPID].[WorkOrderMaster] 
                                            SET [Count] = " & WorkOrderRowCount & " 
                                            WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'"
                    Using updateCmd As New SqlCommand(updateQuery, conn)
                        updateCmd.ExecuteNonQuery()
                    End Using
                Catch ex As Exception
                    UpdateListBox(ex.Message, True, True)
                    Return False
                End Try


                Dim result = 0
                Try
                    ' Check if [Count] is more or same [Total Order Count]
                    Dim checkQuery As String = "SELECT CASE WHEN [Count] >= [Total Order Count] THEN 1 ELSE 0 END AS Result 
                                                FROM [CRICUT].[CUPID].[WorkOrderMaster] 
                                                WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'"
                    Using QueryCountstatus As New SqlCommand(checkQuery, conn)
                        result = CInt(QueryCountstatus.ExecuteScalar())
                    End Using
                Catch ex As Exception
                    UpdateListBox(ex.Message, True, True)
                    Return False
                End Try

                Try
                    If result = 1 Then
                        ' If [Count] >= [Total Order Count], update [Completed] to 0
                        Dim updateCountStatus As String = "UPDATE ws
                                                                SET ws.[PalletScanCompleted] = 1
                                                                FROM [CRICUT].[CUPID].[WorkOrderStatus] ws
                                                                INNER JOIN [CRICUT].[CUPID].[WorkOrderMaster] wm ON ws.[Work Order ID] = wm.[Work Order ID]
                                                                WHERE ws.[Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'
                                                                AND ws.[Pallet No] ='" & GlobalVariables.PalletNo & "'"
                        Using updateCmd As New SqlCommand(updateCountStatus, conn)
                            updateCmd.ExecuteNonQuery()
                        End Using

                        Dim UpdateCompletedStatus As String = "UPDATE [CRICUT].[CUPID].[WorkOrderMaster]
                                                                    SET [Completed] = 1
                                                                    WHERE [Work Order ID] = '" & GlobalVariables.WorkOrderID.ToString() & "'"
                        Using UpdateComplete As New SqlCommand(UpdateCompletedStatus, conn)
                            UpdateComplete.ExecuteNonQuery()
                            _completed = "True"
                        End Using
                    End If
                Catch ex As Exception
                    UpdateListBox(ex.Message, True, True)
                    Return False
                End Try

                Return True

            End If




        Catch ex As Exception
            status_lbl.Text = ex.Message
            conn?.Close()
            Return False
        Finally
            conn?.Close()
        End Try
    End Function

#End Region


#Region "Button Events"

    'DataGridview Cell Formatting
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Try
            DataGridView1.Columns.Item("Serial No").Width = 75
            DataGridView1.Columns.Item("Pallet No").Width = 75
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells("QCout").Value.ToString = "True" Then
                    For Each cell As DataGridViewCell In DataGridView1.Rows(i).Cells
                        cell.Style.BackColor = Color.PaleVioletRed
                        cell.Style.ForeColor = Color.White
                    Next
                End If
            Next

            For j As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(j).Cells("QCin").Value.ToString = "True" Then
                    For Each cell As DataGridViewCell In DataGridView1.Rows(j).Cells
                        cell.Style.BackColor = Color.Green
                        cell.Style.ForeColor = Color.White
                    Next
                End If
            Next


        Catch ex As Exception
        End Try
    End Sub

    ' Delete The 
    Private Sub DeleteQcRecords_btn_Click(sender As Object, e As EventArgs) Handles DeleteQcRecords_btn.Click
        Try
            DeleteRecords()
        Catch ex As Exception
        End Try
    End Sub


    Private Function AutoAssignComboboxIfAutoInput()
        Try
            poNumber_txtbx.Text = _poNo

            If workOrder_cmbx.Items.Contains(_workOrder) Then
                workOrder_cmbx.SelectedItem = _workOrder
            End If

            If subGroup_cmbx.Items.Contains(_subGroup) Then
                subGroup_cmbx.SelectedItem = _subGroup
            End If

            If pallet_cmbx.Items.Contains(_palletNo) Then
                pallet_cmbx.SelectedItem = _palletNo
            End If

            If shift_cmbx.Items.Contains(_shift) Then
                shift_cmbx.SelectedItem = _shift
            End If


        Catch ex As Exception
        End Try
    End Function

    ' Search Word Order ID
    Private Sub search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click
        Try
            If masterBarcode_txtbx.Text IsNot "" Then

                If splitMasterBarcodeInput(masterBarcode_txtbx.Text) Then
                    Threading.Thread.Sleep(100) 'Delay
                    'Await Task.Run(Sub() LoadGrid())
                    getWorkOrderID()
                    AllocateGlobalVariables()
                    UpdateCompleteStatus()
                    LoadGrid()
                    AutoAssignComboboxIfAutoInput()
                Else
                    status_lbl.Text = "Invalid Master Barcode Format"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' QC In Form
    Private Sub btnQCin_Click(sender As Object, e As EventArgs) Handles btnQCin.Click
        Try
            comboboxInputCheck()
            If WID.ToString() = "00000000-0000-0000-0000-000000000000" Then
                Dim str = "Incomplete MasterBarcode"
                status_lbl.Text = str
                UpdateListBox(str, True, False)
                Return
            End If

            'getWorkOrderID()
            'AllocateGlobalVariables()
            'If UpdateCompleteStatus() Then End If
            If checkPalletQuantity() Then
                If checkWorkOrderStatusExistence() Then
                    'AllocateGlobalVariables() 'Allocate Global Variables
                    Dim qcin As New QCIn
                    qcin.slotsAvailable = _quantity - _currentUsedPalletQuantity
                    qcin.ShowDialog()
                Else
                    status_lbl.Text = "Pallet Not Complete"
                End If
            Else
                status_lbl.Text = "Pallet Is Full"
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' QC out Form
    Private Sub btnQCout_Click(sender As Object, e As EventArgs) Handles btnQCout.Click
        Try
            comboboxInputCheck()
            If WID.ToString() = "00000000-0000-0000-0000-000000000000" Then
                Dim str = "Incomplete MasterBarcode"
                status_lbl.Text = str
                UpdateListBox(str, True, False)
                Return
            End If
            If checkWorkOrderStatusExistence() Then
                AllocateGlobalVariables() 'Allocate Global Variables

                Dim qcout As New QcOutfrm
                QcOutfrm.ShowDialog()
            Else
                status_lbl.Text = "Pallet Not Complete"
                UpdateListBox("Incomplete Pallet", True, False)
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region


#Region "Combobox Events"




    Private Sub workOrder_cmbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles workOrder_cmbx.SelectedIndexChanged
        Try
            masterBarcode_txtbx.Clear()
            WID = New Guid
            _workOrder = workOrder_cmbx.SelectedItem.ToString()
            If GetPoNumber() Then
                poNumber_txtbx.Text = _poNo
            End If
            subGroup_cmbx.Items.Clear()
            pallet_cmbx.Items.Clear()
            shift_cmbx.Items.Clear()
            PopulateSubGroupCombobox()
            subGroup_cmbx.Focus()
            comboboxInputCheck()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub subGroup_cmbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subGroup_cmbx.SelectedIndexChanged
        Try
            _subGroup = subGroup_cmbx.SelectedItem.ToString()
            pallet_cmbx.Items.Clear()
            shift_cmbx.Items.Clear()
            PopulatePalletNoCombobox()
            pallet_cmbx.Focus()
            comboboxInputCheck()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub pallet_cmbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pallet_cmbx.SelectedIndexChanged
        Try
            _palletNo = pallet_cmbx.SelectedItem.ToString()
            shift_cmbx.SelectedItem = Nothing
            shift_cmbx.Items.Clear()
            PopulateShiftCombobox()
            shift_cmbx.Focus()
            comboboxInputCheck()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub shift_cmbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles shift_cmbx.SelectedIndexChanged
        Try
            _shift = shift_cmbx.SelectedItem.ToString()
            masterBarcode_txtbx.Clear()
            masterBarcode_txtbx.Text = $"{_workOrder},{_poNo},{_subGroup},{_palletNo} ,{_shift}"

            getWorkOrderID()
            AllocateGlobalVariables()
            If UpdateCompleteStatus() Then
                LoadGrid()
                comboboxInputCheck()
                checkPalletQuantity()
            End If



        Catch ex As Exception
        End Try
    End Sub

    Private Sub masterBarcode_txtbx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles masterBarcode_txtbx.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                search_btn_Click(sender, e)
            End If
        Catch ex As Exception
            status_lbl.Text = ex.Message
        End Try
    End Sub

    Private Sub masterBarcode_txtbx_TextChanged(sender As Object, e As EventArgs) Handles masterBarcode_txtbx.TextChanged
        Try
            status_lbl.Text = ""
        Catch ex As Exception
            status_lbl.Text = ex.Message
        End Try
    End Sub

    Private Sub masterBarcode_txtbx_Click(sender As Object, e As EventArgs) Handles masterBarcode_txtbx.Click
        masterBarcode_txtbx.Clear()
        masterBarcode_txtbx.Focus()
    End Sub



#End Region




End Class
