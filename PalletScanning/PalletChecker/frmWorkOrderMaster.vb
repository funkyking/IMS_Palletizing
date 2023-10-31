Imports System.Data.SqlClient
Imports System.IO



Public Class frmWorkOrderMaster
    Dim connstr = ReadValue("System", "SQLconnstr", IniPath)



    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim f1 = New frmAddWorkOrder
        f1.Text = "Add Work Order"
        f1.ShowDialog()
        LoadGrid()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click, DataGridView1.CellContentDoubleClick
        Dim f1 = New frmAddWorkOrder
        f1.Text = "Update Work Order"
        f1.ShowDialog()
        LoadGrid()
    End Sub

    Private Sub query_TextChanged(sender As Object, e As EventArgs) Handles query.TextChanged
        CheckQuery()
    End Sub

    Private Sub frmWorkOrderMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrid()
        If GlobalVariables.AdminAccess = True Then
            ToolStripButton3.Visible = True
        Else
            ToolStripButton3.Visible = False
        End If
    End Sub

    Private Function LoadGrid()
        Try
            Dim Conn = New SqlConnection(connstr)
            Conn.Open()
            Dim SQLcmd = New SqlCommand
            Dim strsql = "Select w.[Index] As [No],
                                w.[Work Order] As [Work Order],
                                w.[PO Number] As [PO Number],
                                w.[Sub Group] As [Sub Group],
                                p.[Part Name] As [Part Name],
                               m.[Model] As [Model],
                                l.[Line] As [Line],
                                w.[Quantity] As [Limit],
                                w.[Count] As [Count],
                                w.[Total Order Count] As [Total Order Count],
                                w.[Description] As [Description], 
                                w.[Completed] As [Completed],
                                w.[Modified Date] As [Modified Date]
    
                      FROM [CRICUT].[CUPID].[WorkOrderMaster] w
                      INNER JOIN [CRICUT].[CUPID].[PartMaster] p
                        ON p.[Part ID] = w.[Part ID]
                      INNER Join [CRICUT].[CUPID].[ModelMaster] m
                        On m.[Model ID] = w.[Model ID]
                      INNER JOIN [CRICUT].[CUPID].[LineMaster] l
                        On w.[LineID] = l.[LineID]
                        WHERE  w.[Delete]='False' ORDER BY [Work Order] ASC"
            Dim dt = New DataTable
            dt.Clear()
            Dim da = New SqlDataAdapter(strsql, Conn)
            da.Fill(dt)
            da.Dispose()
            DataGridView1.DataSource = dt
            DataGridView1.ClearSelection()

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Function CheckQuery()
        If query.Text = "" Then
            LoadGrid()
            Exit Function
        End If
        Try
            Dim Conn = New SqlConnection(connstr)
            Conn.Open()
            Dim SQLcmd = New SqlCommand
            Dim strsql = "Select w.[Index] As [No],
                                w.[Work Order] As [Work Order],
                                w.[PO Number] As [PO Number],
                                p.[Part Name] As [Part Name],
                                m.[Model] As [Model],
                                l.[Line] as [Line],
                                w.[Quantity] As [Limit],
                                w.[Count] As [Count],
                                w.[Total Order Count] As [Total Order Count],
                                w.[Description] As [Description], 
                                w.[Completed] As [Completed],
                                w.[Sub Group] As [Sub Group],
                                w.[Modified Date] As [Modified Date]
                      From [CRICUT].[CUPID].[WorkOrderMaster] w
                      INNER Join [CRICUT].[CUPID].[PartMaster] p
                        On p.[Part ID] = w.[Part ID]
                      INNER Join [CRICUT].[CUPID].[ModelMaster] m
                        On m.[Model ID] = w.[Model ID]
                      INNER JOIN [CRICUT].[CUPID].[LineMaster] l
                        On w.[LineID] = l.[LineID]

                        WHERE  w.[Delete] ='False' AND  (w.[Index] Like '%" & query.Text & "%' OR w.[Work Order] LIKE '%" & query.Text & "%' OR p.[Part Name] LIKE '%" & query.Text & "%' OR m.[Model]='" & query.Text & "')"

            Dim dt = New DataTable
            dt.Clear()
            Dim da = New SqlDataAdapter(strsql, Conn)
            da.Fill(dt)
            da.Dispose()
            DataGridView1.DataSource = dt
            DataGridView1.ClearSelection()
            'DataGridView1.RowTemplate.Height = 100

            Conn.Close()
        Catch ex As Exception

        End Try
    End Function



    Private Function WorkOrderReachedShipping() As Boolean
        Dim Conn = New SqlConnection(connstr)
        Dim wo = DataGridView1.CurrentRow.Cells("Work Order").Value.ToString
        Dim SKU = DataGridView1.CurrentRow.Cells("Sub Group").Value.ToString
        Conn.Open()
        Try
            If Conn.State = ConnectionState.Open Then
                Dim query = "SELECT [Work Order],[Sub Group]
                              FROM [CRICUT].[CUPID].[ContainerShipping]
                              WHERE [Work Order] = '" & wo.Trim() & "' AND [Sub Group] = '" & SKU.Trim() & "'"
                Using sqlcmd As New SqlCommand(query, Conn)
                    Dim ds = sqlcmd.ExecuteReader()
                    If ds.HasRows Then
                        Return True
                    End If
                End Using
            End If
        Catch ex As Exception
            Conn?.Close()
            Return False
        Finally
            Conn?.Close()
        End Try
    End Function

    Private Function DeleteWorkOrder() As Boolean

        Dim WID = getWorkOrderID()
        Dim WO = DataGridView1.CurrentRow.Cells("Work Order").Value.ToString
        Dim PoNo = DataGridView1.CurrentRow.Cells("PO Number").Value.ToString
        Dim SKU = DataGridView1.CurrentRow.Cells("Sub Group").Value.ToString
        Dim PartName = DataGridView1.CurrentRow.Cells("Part Name").Value.ToString
        Dim Model = DataGridView1.CurrentRow.Cells("Model").Value.ToString
        Dim Line = DataGridView1.CurrentRow.Cells("Line").Value.ToString
        Dim Quantity = DataGridView1.CurrentRow.Cells("Limit").Value.ToString
        Dim Count = DataGridView1.CurrentRow.Cells("Count").Value.ToString
        Dim TotalOrderCount = DataGridView1.CurrentRow.Cells("Total Order Count").Value.ToString
        Dim Description = DataGridView1.CurrentRow.Cells("Description").Value.ToString
        Dim Completed = DataGridView1.CurrentRow.Cells("Completed").Value.ToString
        Dim ModifiedDate = DataGridView1.CurrentRow.Cells("Modified Date").Value.ToString

        Dim Conn = New SqlConnection(connstr)
        Conn.Open()
        Try
            If Conn.State = ConnectionState.Open Then
                Dim query = "DELETE FROM [CRICUT].[CUPID].[WorkOrderMaster] WHERE [Work Order ID] = '" & WID.ToString().Trim() & "';
                            DELETE FROM [CRICUT].[CUPID].[WorkOrder] WHERE [Work Order ID] = '" & WID.ToString().Trim() & "';
                            DELETE FROM [CRICUT].[CUPID].[WorkOrderPalletizing] WHERE [Work Order ID] = '" & WID.ToString().Trim() & "';
                            DELETE FROM [CRICUT].[CUPID].[WorkOrderStatus] WHERE [Work Order ID] = '" & WID.ToString().Trim() & "';
                            DELETE FROM [CRICUT].[CUPID].[QCLog] WHERE [Work Order ID] = '" & WID.ToString().Trim() & "';
                            INSERT INTO [CRICUT].[CUPID].[DeletedWorkOrderMaster]
                                        ([Work Order ID],[Work Order],[Po Number],[Sub Group],[Part Name],[Model]
		                                ,[Line],[Quantity],[Count],[Total Order Count],[Description],[Completed],[Modified Date])
                                    VALUES
                                        ('" & WID.ToString().Trim() & "'
                                        ,'" & WO.Trim() & "'
                                        ,'" & PoNo.Trim() & "'
                                        ,'" & SKU.Trim() & "'
                                        ,'" & PartName.Trim() & "'
                                        ,'" & Model.Trim() & "'
                                        ,'" & Line.Trim() & "'
                                        ,'" & Quantity.Trim() & "'
                                        ,'" & Count.Trim() & "'
                                        ,'" & TotalOrderCount.Trim() & "'
                                        ,'" & Description.Trim() & "' 
                                        ,'" & Completed.Trim() & "'
                                        ,GETDATE());"
                Using cmd As New SqlCommand(query, Conn)
                    Dim rows = cmd.ExecuteNonQuery()
                    If rows > 0 Then
                        Return True
                    End If
                End Using
            End If
        Catch ex As Exception
            Conn?.Close()
            Return False
        Finally
            Conn?.Close()
        End Try
    End Function


    Private Function getWorkOrderID() As Guid
        Dim conn As New SqlConnection(connstr)
        Dim WorkID = New Guid
        Dim wo = DataGridView1.CurrentRow.Cells("Work Order").Value.ToString
        Dim SKU = DataGridView1.CurrentRow.Cells("Sub Group").Value.ToString
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim query = "SELECT DISTINCT [Work Order ID],[Work Order],[Sub Group]
                          FROM [CRICUT].[CUPID].[WorkOrderMaster]
                          WHERE [Work Order] = '" & wo.Trim() & "'
                          AND [Sub Group] = '" & SKU.Trim() & "'"
                Using cmd As New SqlCommand(query, conn)
                    Dim ds = cmd.ExecuteReader()
                    If ds.HasRows Then
                        While ds.Read
                            WorkID = ds.Item("Work Order ID")
                        End While
                    End If
                End Using
                conn.Close()
            End If
            Return WorkID
        Catch ex As Exception
            conn?.Close()
            Return WorkID
        End Try
    End Function



    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        Dim wo = DataGridView1.CurrentRow.Cells("Work Order").Value.ToString
        Dim SKU = DataGridView1.CurrentRow.Cells("Sub Group").Value.ToString

        If WorkOrderReachedShipping() Then
            MessageBox.Show($"This Work Order Has Reached Shipping Stage{vbCrLf}And is not Possible to Delete{vbCrLf}{vbCrLf}Work Order: {wo}{vbCrLf}SKU: {SKU}",
                            $"Unable to Delete Work Order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim res = MessageBox.Show($"Confirm Delete Work Order?{vbCrLf}{vbCrLf}Work Order: {wo}{vbCrLf}SKU: {SKU}", "Confirm Operation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
            If res = DialogResult.Yes Then
                If DeleteWorkOrder() Then
                    MessageBox.Show($"Successfully Deleted Work Order{vbCrLf}{vbCrLf}Work Order: {wo}{vbCrLf}SKU: {SKU}")
                    LoadGrid()
                End If
            End If
        End If



        'Dim res = MessageBox.Show("Confirm Delete Item?", "Confirm Operation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
        'If res = DialogResult.Yes Then
        '    Dim Conn = New SqlConnection(connstr)
        '    Conn.Open()
        '    If Conn.State = ConnectionState.Open Then
        '        Dim SQLcmd = New SqlCommand
        '        SQLcmd.Connection = Conn
        '        SQLcmd.CommandText = "UPDATE [CUPID].[WorkOrderMaster]
        '                           SET
        '                                [Delete] = 'True'
        '                              ,[Modified Date] =  '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'
        '                         WHERE [Index]='" & DataGridView1.CurrentRow.Cells("No").Value.ToString & "'"
        '        SQLcmd.ExecuteNonQuery()
        '        Conn.Close()
        '        LoadGrid()
        '    End If
        'Else
        '    Exit Sub
        'End If
    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

        DataGridView1.Columns.Item("No").Width = 40
        DataGridView1.Columns.Item("Modified Date").MinimumWidth = 120
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim f1 = New frmHelp
        f1.helptitle = "workordermas"
        f1.Owner = Me
        f1.ShowDialog()
    End Sub

    'Show a form of delete Work Orders
    Private Sub deleteHistory_tsb_Click(sender As Object, e As EventArgs) Handles deleteHistory_tsb.Click
        Try
            Dim f1 = New frmDeletedWorkOrderList
            f1.ShowDialog()
            LoadGrid()
        Catch ex As Exception
        End Try
    End Sub
End Class