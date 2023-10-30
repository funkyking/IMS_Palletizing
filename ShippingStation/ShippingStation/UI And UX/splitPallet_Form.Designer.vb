<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class splitPallet_Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(splitPallet_Form))
        Me.masterBarcode_txtbx = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SerialNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.serial_txtbx = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SerialAdd_btn = New System.Windows.Forms.Button()
        Me.clear_btn = New System.Windows.Forms.Button()
        Me.left_pnl = New System.Windows.Forms.Panel()
        Me.MasterBarcode_Clr_Btn = New System.Windows.Forms.Button()
        Me.MasterBarcode_btn = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.finish_btn = New System.Windows.Forms.Button()
        Me.status_lbl = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.left_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'masterBarcode_txtbx
        '
        Me.masterBarcode_txtbx.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masterBarcode_txtbx.Location = New System.Drawing.Point(7, 357)
        Me.masterBarcode_txtbx.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.masterBarcode_txtbx.Name = "masterBarcode_txtbx"
        Me.masterBarcode_txtbx.Size = New System.Drawing.Size(384, 42)
        Me.masterBarcode_txtbx.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 334)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 19)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Master Barcode"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SerialNo})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Location = New System.Drawing.Point(428, 48)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(384, 282)
        Me.DataGridView1.TabIndex = 10
        '
        'SerialNo
        '
        Me.SerialNo.HeaderText = "Serial Number"
        Me.SerialNo.Name = "SerialNo"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.RemoveToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(118, 48)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'serial_txtbx
        '
        Me.serial_txtbx.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serial_txtbx.Location = New System.Drawing.Point(427, 357)
        Me.serial_txtbx.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.serial_txtbx.Name = "serial_txtbx"
        Me.serial_txtbx.Size = New System.Drawing.Size(384, 42)
        Me.serial_txtbx.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(424, 334)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 19)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Serial No"
        '
        'SerialAdd_btn
        '
        Me.SerialAdd_btn.AutoSize = True
        Me.SerialAdd_btn.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SerialAdd_btn.FlatAppearance.BorderSize = 0
        Me.SerialAdd_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SerialAdd_btn.ForeColor = System.Drawing.Color.Black
        Me.SerialAdd_btn.Location = New System.Drawing.Point(427, 407)
        Me.SerialAdd_btn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SerialAdd_btn.Name = "SerialAdd_btn"
        Me.SerialAdd_btn.Size = New System.Drawing.Size(183, 60)
        Me.SerialAdd_btn.TabIndex = 14
        Me.SerialAdd_btn.Text = "Add"
        Me.SerialAdd_btn.UseVisualStyleBackColor = False
        '
        'clear_btn
        '
        Me.clear_btn.AutoSize = True
        Me.clear_btn.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.clear_btn.FlatAppearance.BorderSize = 0
        Me.clear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.clear_btn.ForeColor = System.Drawing.Color.Black
        Me.clear_btn.Location = New System.Drawing.Point(629, 407)
        Me.clear_btn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.clear_btn.Name = "clear_btn"
        Me.clear_btn.Size = New System.Drawing.Size(183, 60)
        Me.clear_btn.TabIndex = 15
        Me.clear_btn.Text = "Clear"
        Me.clear_btn.UseVisualStyleBackColor = False
        '
        'left_pnl
        '
        Me.left_pnl.Controls.Add(Me.ListBox1)
        Me.left_pnl.Controls.Add(Me.MasterBarcode_Clr_Btn)
        Me.left_pnl.Controls.Add(Me.Label2)
        Me.left_pnl.Controls.Add(Me.MasterBarcode_btn)
        Me.left_pnl.Controls.Add(Me.masterBarcode_txtbx)
        Me.left_pnl.Dock = System.Windows.Forms.DockStyle.Left
        Me.left_pnl.Location = New System.Drawing.Point(0, 0)
        Me.left_pnl.Name = "left_pnl"
        Me.left_pnl.Size = New System.Drawing.Size(404, 555)
        Me.left_pnl.TabIndex = 16
        '
        'MasterBarcode_Clr_Btn
        '
        Me.MasterBarcode_Clr_Btn.AutoSize = True
        Me.MasterBarcode_Clr_Btn.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.MasterBarcode_Clr_Btn.FlatAppearance.BorderSize = 0
        Me.MasterBarcode_Clr_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MasterBarcode_Clr_Btn.ForeColor = System.Drawing.Color.Black
        Me.MasterBarcode_Clr_Btn.Location = New System.Drawing.Point(209, 407)
        Me.MasterBarcode_Clr_Btn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MasterBarcode_Clr_Btn.Name = "MasterBarcode_Clr_Btn"
        Me.MasterBarcode_Clr_Btn.Size = New System.Drawing.Size(183, 60)
        Me.MasterBarcode_Clr_Btn.TabIndex = 18
        Me.MasterBarcode_Clr_Btn.Text = "Clear"
        Me.MasterBarcode_Clr_Btn.UseVisualStyleBackColor = False
        '
        'MasterBarcode_btn
        '
        Me.MasterBarcode_btn.AutoSize = True
        Me.MasterBarcode_btn.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MasterBarcode_btn.FlatAppearance.BorderSize = 0
        Me.MasterBarcode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MasterBarcode_btn.ForeColor = System.Drawing.Color.Black
        Me.MasterBarcode_btn.Location = New System.Drawing.Point(7, 407)
        Me.MasterBarcode_btn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MasterBarcode_btn.Name = "MasterBarcode_btn"
        Me.MasterBarcode_btn.Size = New System.Drawing.Size(183, 60)
        Me.MasterBarcode_btn.TabIndex = 17
        Me.MasterBarcode_btn.Text = "Insert"
        Me.MasterBarcode_btn.UseVisualStyleBackColor = False
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox1.ForeColor = System.Drawing.Color.Lime
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 19
        Me.ListBox1.Location = New System.Drawing.Point(13, 52)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(366, 270)
        Me.ListBox1.TabIndex = 19
        '
        'finish_btn
        '
        Me.finish_btn.Location = New System.Drawing.Point(428, 484)
        Me.finish_btn.Name = "finish_btn"
        Me.finish_btn.Size = New System.Drawing.Size(383, 59)
        Me.finish_btn.TabIndex = 17
        Me.finish_btn.Text = "Finish"
        Me.finish_btn.UseVisualStyleBackColor = True
        '
        'status_lbl
        '
        Me.status_lbl.AutoSize = True
        Me.status_lbl.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status_lbl.ForeColor = System.Drawing.Color.Red
        Me.status_lbl.Location = New System.Drawing.Point(427, 17)
        Me.status_lbl.Name = "status_lbl"
        Me.status_lbl.Size = New System.Drawing.Size(0, 19)
        Me.status_lbl.TabIndex = 18
        '
        'splitPallet_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 555)
        Me.Controls.Add(Me.status_lbl)
        Me.Controls.Add(Me.finish_btn)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.clear_btn)
        Me.Controls.Add(Me.left_pnl)
        Me.Controls.Add(Me.serial_txtbx)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SerialAdd_btn)
        Me.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "splitPallet_Form"
        Me.Text = "Split Pallet"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.left_pnl.ResumeLayout(False)
        Me.left_pnl.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents masterBarcode_txtbx As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents serial_txtbx As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SerialAdd_btn As Button
    Friend WithEvents SerialNo As DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents clear_btn As Button
    Friend WithEvents left_pnl As Panel
    Friend WithEvents MasterBarcode_Clr_Btn As Button
    Friend WithEvents MasterBarcode_btn As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents finish_btn As Button
    Friend WithEvents status_lbl As Label
End Class
