Imports System.Data.SqlClient
Imports System.Windows.Controls

Public Class splitPallet_Form


#Region "Variables"
    Private connstr = ""
    Dim WorkOrder As String = ""
    Dim PoNumber As String = ""
    Dim SubGroup As String = ""
    Dim PalletNo As String = ""
    Dim Shift As String = ""
#End Region


    Private Sub splitPallet_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connstr = ReadValue("System", "SQLconnstr", IniPath)
    End Sub



#Region "Buttons"


    Private Sub MasterBarcode_btn_Click(sender As Object, e As EventArgs) Handles MasterBarcode_btn.Click
        Try
            If masterBarcode_txtbx.Text IsNot Nothing Or masterBarcode_txtbx.Text = "" Then
                Dim input = masterBarcode_txtbx.Text.ToString()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MasterBarcode_Clr_Btn_Click(sender As Object, e As EventArgs) Handles MasterBarcode_Clr_Btn.Click
        Try

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

        Catch ex As Exception
        End Try
    End Sub

#End Region


#Region "Textbox Input"

    Private Sub serial_txtbx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles serial_txtbx.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Dim serial_input = serial_txtbx.Text.ToString()
                If Not checkDuplicate(serial_input) Then
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



End Class