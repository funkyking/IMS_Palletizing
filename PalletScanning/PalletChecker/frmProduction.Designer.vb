﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProduction
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PalletBox = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Shift = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbWorkOrderBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.scanstatuslbl = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtS1 = New System.Windows.Forms.TextBox()
        Me.Carton = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.qty = New System.Windows.Forms.Label()
        Me.Model = New System.Windows.Forms.Label()
        Me.Order = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.totalordercount = New System.Windows.Forms.Label()
        Me.statuslbl = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.count = New System.Windows.Forms.Label()
        Me.part = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.debug_btn = New System.Windows.Forms.ToolStripButton()
        Me.AddBtn = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LoosePallet_btn = New System.Windows.Forms.Button()
        Me.lblOption = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.MoCompleted_chkbx = New System.Windows.Forms.CheckBox()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbSubGroup = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PrintReportBtn = New System.Windows.Forms.Button()
        Me.PrintOrderBtn = New System.Windows.Forms.Button()
        Me.txtC2 = New System.Windows.Forms.TextBox()
        Me.txtS2 = New System.Windows.Forms.TextBox()
        Me.txtC3 = New System.Windows.Forms.TextBox()
        Me.txtS3 = New System.Windows.Forms.TextBox()
        Me.txtC4 = New System.Windows.Forms.TextBox()
        Me.txtS4 = New System.Windows.Forms.TextBox()
        Me.txtC5 = New System.Windows.Forms.TextBox()
        Me.txtS5 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.serialStatusLbl = New System.Windows.Forms.Label()
        Me.btnQCin = New System.Windows.Forms.Button()
        Me.btnQCcheck = New System.Windows.Forms.Button()
        Me.btnQCout = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.debug_chckbx = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.ScanBtn = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'PalletBox
        '
        Me.PalletBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PalletBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PalletBox.FormattingEnabled = True
        Me.PalletBox.Location = New System.Drawing.Point(101, 134)
        Me.PalletBox.Margin = New System.Windows.Forms.Padding(2)
        Me.PalletBox.Name = "PalletBox"
        Me.PalletBox.Size = New System.Drawing.Size(266, 28)
        Me.PalletBox.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 137)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 20)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Pallet No:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 26)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 20)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Part Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 86)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 20)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Quantity:"
        '
        'Shift
        '
        Me.Shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Shift.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Shift.FormattingEnabled = True
        Me.Shift.Items.AddRange(New Object() {"DAY", "NIGHT"})
        Me.Shift.Location = New System.Drawing.Point(101, 168)
        Me.Shift.Margin = New System.Windows.Forms.Padding(2)
        Me.Shift.Name = "Shift"
        Me.Shift.Size = New System.Drawing.Size(266, 28)
        Me.Shift.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 171)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Shift:"
        '
        'cmbWorkOrderBox
        '
        Me.cmbWorkOrderBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbWorkOrderBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbWorkOrderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWorkOrderBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbWorkOrderBox.FormattingEnabled = True
        Me.cmbWorkOrderBox.Location = New System.Drawing.Point(101, 40)
        Me.cmbWorkOrderBox.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbWorkOrderBox.Name = "cmbWorkOrderBox"
        Me.cmbWorkOrderBox.Size = New System.Drawing.Size(266, 28)
        Me.cmbWorkOrderBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 75)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "PO No:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 21)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(259, 38)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Start Production"
        '
        'scanstatuslbl
        '
        Me.scanstatuslbl.AutoSize = True
        Me.scanstatuslbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scanstatuslbl.Location = New System.Drawing.Point(182, 413)
        Me.scanstatuslbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.scanstatuslbl.Name = "scanstatuslbl"
        Me.scanstatuslbl.Size = New System.Drawing.Size(258, 26)
        Me.scanstatuslbl.TabIndex = 29
        Me.scanstatuslbl.Text = "Scanning In Progress... ()"
        '
        'Timer1
        '
        '
        'txtS1
        '
        Me.txtS1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtS1.Location = New System.Drawing.Point(12, 38)
        Me.txtS1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtS1.Name = "txtS1"
        Me.txtS1.Size = New System.Drawing.Size(264, 26)
        Me.txtS1.TabIndex = 8
        '
        'Carton
        '
        Me.Carton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Carton.Location = New System.Drawing.Point(316, 38)
        Me.Carton.Margin = New System.Windows.Forms.Padding(2)
        Me.Carton.Name = "Carton"
        Me.Carton.Size = New System.Drawing.Size(200, 26)
        Me.Carton.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 16)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 20)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Serial No:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(311, 16)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 20)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Carton:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.Location = New System.Drawing.Point(809, 86)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(205, 665)
        Me.DataGridView1.TabIndex = 33
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 48)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(61, 56)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Model:"
        '
        'qty
        '
        Me.qty.AutoSize = True
        Me.qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qty.Location = New System.Drawing.Point(262, 86)
        Me.qty.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.qty.Name = "qty"
        Me.qty.Size = New System.Drawing.Size(18, 20)
        Me.qty.TabIndex = 38
        Me.qty.Text = "0"
        '
        'Model
        '
        Me.Model.AutoSize = True
        Me.Model.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Model.Location = New System.Drawing.Point(131, 56)
        Me.Model.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Model.Name = "Model"
        Me.Model.Size = New System.Drawing.Size(52, 20)
        Me.Model.TabIndex = 39
        Me.Model.Text = "Model"
        '
        'Order
        '
        Me.Order.AutoSize = True
        Me.Order.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Order.Location = New System.Drawing.Point(262, 117)
        Me.Order.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Order.Name = "Order"
        Me.Order.Size = New System.Drawing.Size(18, 20)
        Me.Order.TabIndex = 41
        Me.Order.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(22, 117)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 20)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Total Order:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(207, 117)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(13, 20)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "/"
        '
        'totalordercount
        '
        Me.totalordercount.AutoSize = True
        Me.totalordercount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalordercount.Location = New System.Drawing.Point(131, 117)
        Me.totalordercount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.totalordercount.Name = "totalordercount"
        Me.totalordercount.Size = New System.Drawing.Size(18, 20)
        Me.totalordercount.TabIndex = 44
        Me.totalordercount.Text = "0"
        '
        'statuslbl
        '
        Me.statuslbl.AutoSize = True
        Me.statuslbl.ForeColor = System.Drawing.Color.Red
        Me.statuslbl.Location = New System.Drawing.Point(525, 397)
        Me.statuslbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.statuslbl.Name = "statuslbl"
        Me.statuslbl.Size = New System.Drawing.Size(145, 13)
        Me.statuslbl.TabIndex = 45
        Me.statuslbl.Text = "00000000000000000000000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(207, 86)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 20)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "/"
        '
        'count
        '
        Me.count.AutoSize = True
        Me.count.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.count.Location = New System.Drawing.Point(131, 86)
        Me.count.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.count.Name = "count"
        Me.count.Size = New System.Drawing.Size(18, 20)
        Me.count.TabIndex = 48
        Me.count.Text = "0"
        '
        'part
        '
        Me.part.AutoSize = True
        Me.part.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.part.Location = New System.Drawing.Point(131, 26)
        Me.part.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.part.Name = "part"
        Me.part.Size = New System.Drawing.Size(84, 20)
        Me.part.TabIndex = 49
        Me.part.Text = "Part Name"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.debug_btn})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(1026, 27)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.CartonPalletizing.My.Resources.Resources.help
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(56, 24)
        Me.ToolStripButton1.Text = "Help"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'debug_btn
        '
        Me.debug_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.debug_btn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.debug_btn.Name = "debug_btn"
        Me.debug_btn.Size = New System.Drawing.Size(23, 24)
        Me.debug_btn.Text = "Debug"
        Me.debug_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.debug_btn.Visible = False
        '
        'AddBtn
        '
        Me.AddBtn.AutoSize = True
        Me.AddBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddBtn.Location = New System.Drawing.Point(706, 461)
        Me.AddBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.AddBtn.Name = "AddBtn"
        Me.AddBtn.Size = New System.Drawing.Size(51, 30)
        Me.AddBtn.TabIndex = 10
        Me.AddBtn.Text = "Add"
        Me.AddBtn.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'lblLine
        '
        Me.lblLine.AutoSize = True
        Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.Location = New System.Drawing.Point(131, 148)
        Me.lblLine.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(39, 20)
        Me.lblLine.TabIndex = 54
        Me.lblLine.Text = "Line"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(74, 148)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 20)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "Line:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDescription)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblLine)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.qty)
        Me.GroupBox1.Controls.Add(Me.Model)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.part)
        Me.GroupBox1.Controls.Add(Me.Order)
        Me.GroupBox1.Controls.Add(Me.count)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.totalordercount)
        Me.GroupBox1.Location = New System.Drawing.Point(425, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 295)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lots Info"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(131, 176)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(46, 20)
        Me.lblDescription.TabIndex = 56
        Me.lblDescription.Text = "Desc"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(67, 176)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 20)
        Me.Label16.TabIndex = 55
        Me.Label16.Text = "Desc:"
        '
        'LoosePallet_btn
        '
        Me.LoosePallet_btn.AutoSize = True
        Me.LoosePallet_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoosePallet_btn.Image = Global.CartonPalletizing.My.Resources.Resources.print_28
        Me.LoosePallet_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoosePallet_btn.Location = New System.Drawing.Point(228, 245)
        Me.LoosePallet_btn.Margin = New System.Windows.Forms.Padding(2)
        Me.LoosePallet_btn.Name = "LoosePallet_btn"
        Me.LoosePallet_btn.Size = New System.Drawing.Size(139, 36)
        Me.LoosePallet_btn.TabIndex = 31
        Me.LoosePallet_btn.Text = "Pallet Report"
        Me.LoosePallet_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LoosePallet_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.LoosePallet_btn.UseVisualStyleBackColor = True
        '
        'lblOption
        '
        Me.lblOption.AutoSize = True
        Me.lblOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOption.Location = New System.Drawing.Point(656, 392)
        Me.lblOption.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblOption.Name = "lblOption"
        Me.lblOption.Size = New System.Drawing.Size(56, 20)
        Me.lblOption.TabIndex = 56
        Me.lblOption.Text = "Option"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.MoCompleted_chkbx)
        Me.GroupBox2.Controls.Add(Me.LoosePallet_btn)
        Me.GroupBox2.Controls.Add(Me.txtPO)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.cmbSubGroup)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.cmbWorkOrderBox)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Shift)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.PalletBox)
        Me.GroupBox2.Controls.Add(Me.PrintReportBtn)
        Me.GroupBox2.Controls.Add(Me.PrintOrderBtn)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(397, 295)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Work Order"
        '
        'MoCompleted_chkbx
        '
        Me.MoCompleted_chkbx.AutoSize = True
        Me.MoCompleted_chkbx.Location = New System.Drawing.Point(219, 19)
        Me.MoCompleted_chkbx.Name = "MoCompleted_chkbx"
        Me.MoCompleted_chkbx.Size = New System.Drawing.Size(148, 17)
        Me.MoCompleted_chkbx.TabIndex = 32
        Me.MoCompleted_chkbx.Text = "Display Completed Mo No"
        Me.MoCompleted_chkbx.UseVisualStyleBackColor = True
        '
        'txtPO
        '
        Me.txtPO.Enabled = False
        Me.txtPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPO.Location = New System.Drawing.Point(101, 72)
        Me.txtPO.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(266, 26)
        Me.txtPO.TabIndex = 30
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(22, 43)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 20)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "MO No:"
        '
        'cmbSubGroup
        '
        Me.cmbSubGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSubGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSubGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubGroup.FormattingEnabled = True
        Me.cmbSubGroup.Location = New System.Drawing.Point(101, 103)
        Me.cmbSubGroup.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbSubGroup.Name = "cmbSubGroup"
        Me.cmbSubGroup.Size = New System.Drawing.Size(266, 28)
        Me.cmbSubGroup.TabIndex = 26
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(38, 106)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 20)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "SKU:"
        '
        'PrintReportBtn
        '
        Me.PrintReportBtn.AutoSize = True
        Me.PrintReportBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintReportBtn.Image = Global.CartonPalletizing.My.Resources.Resources.excel_28
        Me.PrintReportBtn.Location = New System.Drawing.Point(228, 205)
        Me.PrintReportBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.PrintReportBtn.Name = "PrintReportBtn"
        Me.PrintReportBtn.Size = New System.Drawing.Size(139, 36)
        Me.PrintReportBtn.TabIndex = 5
        Me.PrintReportBtn.Text = "Full Report"
        Me.PrintReportBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PrintReportBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.PrintReportBtn.UseVisualStyleBackColor = True
        '
        'PrintOrderBtn
        '
        Me.PrintOrderBtn.AutoSize = True
        Me.PrintOrderBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintOrderBtn.Image = Global.CartonPalletizing.My.Resources.Resources.print_28
        Me.PrintOrderBtn.Location = New System.Drawing.Point(101, 205)
        Me.PrintOrderBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.PrintOrderBtn.Name = "PrintOrderBtn"
        Me.PrintOrderBtn.Size = New System.Drawing.Size(123, 76)
        Me.PrintOrderBtn.TabIndex = 4
        Me.PrintOrderBtn.Text = "Print Order"
        Me.PrintOrderBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.PrintOrderBtn.UseVisualStyleBackColor = True
        '
        'txtC2
        '
        Me.txtC2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtC2.Location = New System.Drawing.Point(316, 84)
        Me.txtC2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtC2.Name = "txtC2"
        Me.txtC2.Size = New System.Drawing.Size(200, 26)
        Me.txtC2.TabIndex = 58
        '
        'txtS2
        '
        Me.txtS2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtS2.Location = New System.Drawing.Point(12, 84)
        Me.txtS2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtS2.Name = "txtS2"
        Me.txtS2.Size = New System.Drawing.Size(264, 26)
        Me.txtS2.TabIndex = 57
        '
        'txtC3
        '
        Me.txtC3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtC3.Location = New System.Drawing.Point(316, 130)
        Me.txtC3.Margin = New System.Windows.Forms.Padding(2)
        Me.txtC3.Name = "txtC3"
        Me.txtC3.Size = New System.Drawing.Size(200, 26)
        Me.txtC3.TabIndex = 60
        '
        'txtS3
        '
        Me.txtS3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtS3.Location = New System.Drawing.Point(12, 130)
        Me.txtS3.Margin = New System.Windows.Forms.Padding(2)
        Me.txtS3.Name = "txtS3"
        Me.txtS3.Size = New System.Drawing.Size(264, 26)
        Me.txtS3.TabIndex = 59
        '
        'txtC4
        '
        Me.txtC4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtC4.Location = New System.Drawing.Point(316, 176)
        Me.txtC4.Margin = New System.Windows.Forms.Padding(2)
        Me.txtC4.Name = "txtC4"
        Me.txtC4.Size = New System.Drawing.Size(200, 26)
        Me.txtC4.TabIndex = 62
        '
        'txtS4
        '
        Me.txtS4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtS4.Location = New System.Drawing.Point(12, 176)
        Me.txtS4.Margin = New System.Windows.Forms.Padding(2)
        Me.txtS4.Name = "txtS4"
        Me.txtS4.Size = New System.Drawing.Size(264, 26)
        Me.txtS4.TabIndex = 61
        '
        'txtC5
        '
        Me.txtC5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtC5.Location = New System.Drawing.Point(316, 222)
        Me.txtC5.Margin = New System.Windows.Forms.Padding(2)
        Me.txtC5.Name = "txtC5"
        Me.txtC5.Size = New System.Drawing.Size(200, 26)
        Me.txtC5.TabIndex = 64
        '
        'txtS5
        '
        Me.txtS5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtS5.Location = New System.Drawing.Point(12, 222)
        Me.txtS5.Margin = New System.Windows.Forms.Padding(2)
        Me.txtS5.Name = "txtS5"
        Me.txtS5.Size = New System.Drawing.Size(264, 26)
        Me.txtS5.TabIndex = 63
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.serialStatusLbl)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtC5)
        Me.GroupBox3.Controls.Add(Me.txtS1)
        Me.GroupBox3.Controls.Add(Me.txtS5)
        Me.GroupBox3.Controls.Add(Me.Carton)
        Me.GroupBox3.Controls.Add(Me.txtC4)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtS4)
        Me.GroupBox3.Controls.Add(Me.txtC3)
        Me.GroupBox3.Controls.Add(Me.txtS2)
        Me.GroupBox3.Controls.Add(Me.txtS3)
        Me.GroupBox3.Controls.Add(Me.txtC2)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 486)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(545, 261)
        Me.GroupBox3.TabIndex = 65
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Insert Serial Number "
        '
        'serialStatusLbl
        '
        Me.serialStatusLbl.AutoSize = True
        Me.serialStatusLbl.Location = New System.Drawing.Point(95, 18)
        Me.serialStatusLbl.Name = "serialStatusLbl"
        Me.serialStatusLbl.Size = New System.Drawing.Size(15, 13)
        Me.serialStatusLbl.TabIndex = 69
        Me.serialStatusLbl.Text = "✓"
        '
        'btnQCin
        '
        Me.btnQCin.AutoSize = True
        Me.btnQCin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQCin.Location = New System.Drawing.Point(117, 28)
        Me.btnQCin.Name = "btnQCin"
        Me.btnQCin.Size = New System.Drawing.Size(70, 34)
        Me.btnQCin.TabIndex = 68
        Me.btnQCin.Text = "QC In"
        Me.btnQCin.UseVisualStyleBackColor = True
        '
        'btnQCcheck
        '
        Me.btnQCcheck.AutoSize = True
        Me.btnQCcheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQCcheck.Location = New System.Drawing.Point(26, 68)
        Me.btnQCcheck.Name = "btnQCcheck"
        Me.btnQCcheck.Size = New System.Drawing.Size(157, 34)
        Me.btnQCcheck.TabIndex = 67
        Me.btnQCcheck.Text = "View QC Record"
        Me.btnQCcheck.UseVisualStyleBackColor = True
        '
        'btnQCout
        '
        Me.btnQCout.AutoSize = True
        Me.btnQCout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQCout.Location = New System.Drawing.Point(26, 28)
        Me.btnQCout.Name = "btnQCout"
        Me.btnQCout.Size = New System.Drawing.Size(72, 34)
        Me.btnQCout.TabIndex = 66
        Me.btnQCout.Text = "QC Out"
        Me.btnQCout.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.debug_chckbx)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.btnQCout)
        Me.GroupBox4.Controls.Add(Me.btnQCcheck)
        Me.GroupBox4.Controls.Add(Me.btnQCin)
        Me.GroupBox4.Location = New System.Drawing.Point(574, 486)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(214, 261)
        Me.GroupBox4.TabIndex = 26
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Debug Section"
        Me.GroupBox4.Visible = False
        '
        'debug_chckbx
        '
        Me.debug_chckbx.AutoSize = True
        Me.debug_chckbx.Location = New System.Drawing.Point(62, 183)
        Me.debug_chckbx.Name = "debug_chckbx"
        Me.debug_chckbx.Size = New System.Drawing.Size(78, 17)
        Me.debug_chckbx.TabIndex = 71
        Me.debug_chckbx.Text = "Debugging"
        Me.debug_chckbx.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(26, 108)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 28)
        Me.Button1.TabIndex = 69
        Me.Button1.Text = "Excel Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(26, 142)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(161, 27)
        Me.Button2.TabIndex = 69
        Me.Button2.Text = "Count Report Print"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(809, 64)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(128, 20)
        Me.txtSearch.TabIndex = 66
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(943, 62)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(71, 22)
        Me.btnSearch.TabIndex = 67
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(286, 387)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 26)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Pallet ...()"
        '
        'lblError
        '
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(525, 453)
        Me.lblError.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(262, 29)
        Me.lblError.TabIndex = 68
        Me.lblError.Text = "00000000000000000000000"
        '
        'CancelBtn
        '
        Me.CancelBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelBtn.Image = Global.CartonPalletizing.My.Resources.Resources.cancel
        Me.CancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CancelBtn.Location = New System.Drawing.Point(290, 440)
        Me.CancelBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(124, 42)
        Me.CancelBtn.TabIndex = 7
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'ScanBtn
        '
        Me.ScanBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScanBtn.Image = Global.CartonPalletizing.My.Resources.Resources.scan1
        Me.ScanBtn.Location = New System.Drawing.Point(253, 401)
        Me.ScanBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.ScanBtn.Name = "ScanBtn"
        Me.ScanBtn.Size = New System.Drawing.Size(196, 50)
        Me.ScanBtn.TabIndex = 6
        Me.ScanBtn.Text = "Start Scanning"
        Me.ScanBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ScanBtn.UseVisualStyleBackColor = True
        '
        'frmProduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1026, 769)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.lblOption)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.statuslbl)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ScanBtn)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.scanstatuslbl)
        Me.Controls.Add(Me.AddBtn)
        Me.Controls.Add(Me.Label13)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmProduction"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PalletBox As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbWorkOrderBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ScanBtn As Button
    Friend WithEvents scanstatuslbl As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtS1 As TextBox
    Friend WithEvents Carton As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CancelBtn As Button
    Friend WithEvents Shift As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PrintOrderBtn As Button
    Friend WithEvents PrintReportBtn As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents qty As Label
    Friend WithEvents Model As Label
    Friend WithEvents Order As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents statuslbl As Label
    Friend WithEvents totalordercount As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents count As Label
    Friend WithEvents part As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents AddBtn As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents lblLine As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtC2 As TextBox
    Friend WithEvents txtS2 As TextBox
    Friend WithEvents txtC3 As TextBox
    Friend WithEvents txtS3 As TextBox
    Friend WithEvents txtC4 As TextBox
    Friend WithEvents txtS4 As TextBox
    Friend WithEvents txtC5 As TextBox
    Friend WithEvents txtS5 As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnQCout As Button
    Friend WithEvents btnQCcheck As Button
    Friend WithEvents btnQCin As Button
    Friend WithEvents lblOption As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblDescription As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbSubGroup As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents lblError As Label
    Friend WithEvents serialStatusLbl As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents txtPO As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents debug_btn As ToolStripButton
    Friend WithEvents LoosePallet_btn As Button
    Friend WithEvents debug_chckbx As CheckBox
    Friend WithEvents MoCompleted_chkbx As CheckBox
End Class
