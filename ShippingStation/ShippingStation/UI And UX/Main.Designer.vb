<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.masterBarcode_txtbx = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.containerNo_txtbx = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.left_pnl = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.splitPallet_btn = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.clrMasterBarcodeTxtbx_btn = New System.Windows.Forms.Button()
        Me.addMasterBarcode_btn = New System.Windows.Forms.Button()
        Me.clrContainerNoTxtbx_btn = New System.Windows.Forms.Button()
        Me.addContainerNo_btn = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.mainReset_btn = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.top_pnl = New System.Windows.Forms.Panel()
        Me.container_lbl = New System.Windows.Forms.Label()
        Me.containerStatus_lbl = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.right_pnl = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ItemCounter_lbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rightSideInner_pnl = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Pallet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerialNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mid_pnl = New System.Windows.Forms.Panel()
        Me.createPDF_btn = New System.Windows.Forms.Button()
        Me.generateAllDocs_btn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.usr_lbl = New System.Windows.Forms.Label()
        Me.print_btn = New System.Windows.Forms.Button()
        Me.execute_btn = New System.Windows.Forms.Button()
        Me.edit_btn = New System.Windows.Forms.Button()
        Me.Save_Btn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bottom_pnl = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.left_pnl.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.top_pnl.SuspendLayout()
        Me.right_pnl.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mid_pnl.SuspendLayout()
        Me.bottom_pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'masterBarcode_txtbx
        '
        Me.masterBarcode_txtbx.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masterBarcode_txtbx.Location = New System.Drawing.Point(26, 232)
        Me.masterBarcode_txtbx.Name = "masterBarcode_txtbx"
        Me.masterBarcode_txtbx.Size = New System.Drawing.Size(384, 42)
        Me.masterBarcode_txtbx.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 206)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Master Barcode (Multiple)"
        '
        'containerNo_txtbx
        '
        Me.containerNo_txtbx.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.containerNo_txtbx.Location = New System.Drawing.Point(26, 112)
        Me.containerNo_txtbx.Name = "containerNo_txtbx"
        Me.containerNo_txtbx.Size = New System.Drawing.Size(385, 42)
        Me.containerNo_txtbx.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 23)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Container No. (Once)"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 41)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(575, 576)
        Me.FlowLayoutPanel1.TabIndex = 6
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'left_pnl
        '
        Me.left_pnl.BackColor = System.Drawing.Color.Transparent
        Me.left_pnl.Controls.Add(Me.Panel4)
        Me.left_pnl.Dock = System.Windows.Forms.DockStyle.Left
        Me.left_pnl.Location = New System.Drawing.Point(0, 54)
        Me.left_pnl.Name = "left_pnl"
        Me.left_pnl.Size = New System.Drawing.Size(429, 617)
        Me.left_pnl.TabIndex = 8
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Controls.Add(Me.splitPallet_btn)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.clrMasterBarcodeTxtbx_btn)
        Me.Panel4.Controls.Add(Me.masterBarcode_txtbx)
        Me.Panel4.Controls.Add(Me.addMasterBarcode_btn)
        Me.Panel4.Controls.Add(Me.clrContainerNoTxtbx_btn)
        Me.Panel4.Controls.Add(Me.containerNo_txtbx)
        Me.Panel4.Controls.Add(Me.addContainerNo_btn)
        Me.Panel4.Controls.Add(Me.ListBox1)
        Me.Panel4.Controls.Add(Me.mainReset_btn)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(429, 617)
        Me.Panel4.TabIndex = 6
        '
        'splitPallet_btn
        '
        Me.splitPallet_btn.AutoSize = True
        Me.splitPallet_btn.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.splitPallet_btn.FlatAppearance.BorderSize = 0
        Me.splitPallet_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.splitPallet_btn.ForeColor = System.Drawing.Color.Black
        Me.splitPallet_btn.Location = New System.Drawing.Point(26, 280)
        Me.splitPallet_btn.Name = "splitPallet_btn"
        Me.splitPallet_btn.Size = New System.Drawing.Size(93, 41)
        Me.splitPallet_btn.TabIndex = 17
        Me.splitPallet_btn.Text = "Split Pallet"
        Me.splitPallet_btn.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 331)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 23)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Status Log"
        '
        'clrMasterBarcodeTxtbx_btn
        '
        Me.clrMasterBarcodeTxtbx_btn.AutoSize = True
        Me.clrMasterBarcodeTxtbx_btn.BackColor = System.Drawing.Color.DarkGray
        Me.clrMasterBarcodeTxtbx_btn.FlatAppearance.BorderSize = 0
        Me.clrMasterBarcodeTxtbx_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.clrMasterBarcodeTxtbx_btn.ForeColor = System.Drawing.Color.Black
        Me.clrMasterBarcodeTxtbx_btn.Location = New System.Drawing.Point(276, 280)
        Me.clrMasterBarcodeTxtbx_btn.Name = "clrMasterBarcodeTxtbx_btn"
        Me.clrMasterBarcodeTxtbx_btn.Size = New System.Drawing.Size(64, 41)
        Me.clrMasterBarcodeTxtbx_btn.TabIndex = 9
        Me.clrMasterBarcodeTxtbx_btn.Text = "Clear"
        Me.clrMasterBarcodeTxtbx_btn.UseVisualStyleBackColor = False
        '
        'addMasterBarcode_btn
        '
        Me.addMasterBarcode_btn.AutoSize = True
        Me.addMasterBarcode_btn.BackColor = System.Drawing.Color.LimeGreen
        Me.addMasterBarcode_btn.FlatAppearance.BorderSize = 0
        Me.addMasterBarcode_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.addMasterBarcode_btn.ForeColor = System.Drawing.Color.Black
        Me.addMasterBarcode_btn.Location = New System.Drawing.Point(346, 280)
        Me.addMasterBarcode_btn.Name = "addMasterBarcode_btn"
        Me.addMasterBarcode_btn.Size = New System.Drawing.Size(64, 41)
        Me.addMasterBarcode_btn.TabIndex = 6
        Me.addMasterBarcode_btn.Text = "Add"
        Me.addMasterBarcode_btn.UseVisualStyleBackColor = False
        '
        'clrContainerNoTxtbx_btn
        '
        Me.clrContainerNoTxtbx_btn.AutoSize = True
        Me.clrContainerNoTxtbx_btn.BackColor = System.Drawing.Color.DarkGray
        Me.clrContainerNoTxtbx_btn.FlatAppearance.BorderSize = 0
        Me.clrContainerNoTxtbx_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.clrContainerNoTxtbx_btn.ForeColor = System.Drawing.Color.Black
        Me.clrContainerNoTxtbx_btn.Location = New System.Drawing.Point(276, 160)
        Me.clrContainerNoTxtbx_btn.Name = "clrContainerNoTxtbx_btn"
        Me.clrContainerNoTxtbx_btn.Size = New System.Drawing.Size(64, 41)
        Me.clrContainerNoTxtbx_btn.TabIndex = 11
        Me.clrContainerNoTxtbx_btn.Text = "Clear"
        Me.clrContainerNoTxtbx_btn.UseVisualStyleBackColor = False
        '
        'addContainerNo_btn
        '
        Me.addContainerNo_btn.AutoSize = True
        Me.addContainerNo_btn.BackColor = System.Drawing.Color.CornflowerBlue
        Me.addContainerNo_btn.FlatAppearance.BorderSize = 0
        Me.addContainerNo_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.addContainerNo_btn.ForeColor = System.Drawing.Color.Black
        Me.addContainerNo_btn.Location = New System.Drawing.Point(346, 160)
        Me.addContainerNo_btn.Name = "addContainerNo_btn"
        Me.addContainerNo_btn.Size = New System.Drawing.Size(70, 41)
        Me.addContainerNo_btn.TabIndex = 10
        Me.addContainerNo_btn.Text = "Search"
        Me.addContainerNo_btn.UseVisualStyleBackColor = False
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.BackColor = System.Drawing.Color.Black
        Me.ListBox1.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Lime
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 19
        Me.ListBox1.Location = New System.Drawing.Point(26, 357)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(390, 213)
        Me.ListBox1.TabIndex = 14
        '
        'mainReset_btn
        '
        Me.mainReset_btn.BackColor = System.Drawing.Color.Transparent
        Me.mainReset_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mainReset_btn.Image = Global.ShippingStation.My.Resources.Resources.reset1_32
        Me.mainReset_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mainReset_btn.Location = New System.Drawing.Point(327, 47)
        Me.mainReset_btn.Name = "mainReset_btn"
        Me.mainReset_btn.Size = New System.Drawing.Size(86, 41)
        Me.mainReset_btn.TabIndex = 11
        Me.mainReset_btn.Text = "Reset"
        Me.mainReset_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mainReset_btn.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(429, 41)
        Me.Panel5.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 23)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "User Input"
        '
        'top_pnl
        '
        Me.top_pnl.BackColor = System.Drawing.Color.Transparent
        Me.top_pnl.Controls.Add(Me.container_lbl)
        Me.top_pnl.Controls.Add(Me.containerStatus_lbl)
        Me.top_pnl.Controls.Add(Me.Label7)
        Me.top_pnl.Controls.Add(Me.Label4)
        Me.top_pnl.Dock = System.Windows.Forms.DockStyle.Top
        Me.top_pnl.Location = New System.Drawing.Point(0, 0)
        Me.top_pnl.Name = "top_pnl"
        Me.top_pnl.Size = New System.Drawing.Size(1363, 54)
        Me.top_pnl.TabIndex = 9
        '
        'container_lbl
        '
        Me.container_lbl.AutoEllipsis = True
        Me.container_lbl.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.container_lbl.ForeColor = System.Drawing.Color.DodgerBlue
        Me.container_lbl.Location = New System.Drawing.Point(116, 13)
        Me.container_lbl.Name = "container_lbl"
        Me.container_lbl.Size = New System.Drawing.Size(274, 33)
        Me.container_lbl.TabIndex = 1
        Me.container_lbl.Text = "No Container Defined"
        Me.container_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'containerStatus_lbl
        '
        Me.containerStatus_lbl.AutoEllipsis = True
        Me.containerStatus_lbl.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.containerStatus_lbl.ForeColor = System.Drawing.Color.DodgerBlue
        Me.containerStatus_lbl.Location = New System.Drawing.Point(655, 13)
        Me.containerStatus_lbl.Name = "containerStatus_lbl"
        Me.containerStatus_lbl.Size = New System.Drawing.Size(233, 33)
        Me.containerStatus_lbl.TabIndex = 3
        Me.containerStatus_lbl.Text = "Existing"
        Me.containerStatus_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(580, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 29)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Status: "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 29)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Container:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'right_pnl
        '
        Me.right_pnl.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.right_pnl.Controls.Add(Me.FlowLayoutPanel1)
        Me.right_pnl.Controls.Add(Me.Panel3)
        Me.right_pnl.Controls.Add(Me.rightSideInner_pnl)
        Me.right_pnl.Dock = System.Windows.Forms.DockStyle.Right
        Me.right_pnl.Location = New System.Drawing.Point(773, 54)
        Me.right_pnl.Name = "right_pnl"
        Me.right_pnl.Size = New System.Drawing.Size(590, 617)
        Me.right_pnl.TabIndex = 10
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel3.Controls.Add(Me.ItemCounter_lbl)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(575, 41)
        Me.Panel3.TabIndex = 9
        '
        'ItemCounter_lbl
        '
        Me.ItemCounter_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ItemCounter_lbl.AutoSize = True
        Me.ItemCounter_lbl.ForeColor = System.Drawing.Color.Transparent
        Me.ItemCounter_lbl.Location = New System.Drawing.Point(448, 8)
        Me.ItemCounter_lbl.Name = "ItemCounter_lbl"
        Me.ItemCounter_lbl.Size = New System.Drawing.Size(18, 23)
        Me.ItemCounter_lbl.TabIndex = 9
        Me.ItemCounter_lbl.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(15, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(195, 23)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "FlowLayout Of the Containers"
        '
        'rightSideInner_pnl
        '
        Me.rightSideInner_pnl.BackColor = System.Drawing.Color.White
        Me.rightSideInner_pnl.Dock = System.Windows.Forms.DockStyle.Right
        Me.rightSideInner_pnl.Location = New System.Drawing.Point(575, 0)
        Me.rightSideInner_pnl.Name = "rightSideInner_pnl"
        Me.rightSideInner_pnl.Size = New System.Drawing.Size(15, 617)
        Me.rightSideInner_pnl.TabIndex = 3
        '
        'DataGridView1
        '
        Me.DataGridView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Aqua
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeight = 40
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pallet, Me.SerialNo})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(332, 617)
        Me.DataGridView1.TabIndex = 7
        '
        'Pallet
        '
        Me.Pallet.HeaderText = "Pallet"
        Me.Pallet.Name = "Pallet"
        '
        'SerialNo
        '
        Me.SerialNo.HeaderText = "Serial"
        Me.SerialNo.Name = "SerialNo"
        '
        'mid_pnl
        '
        Me.mid_pnl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mid_pnl.Controls.Add(Me.DataGridView1)
        Me.mid_pnl.Location = New System.Drawing.Point(435, 54)
        Me.mid_pnl.Name = "mid_pnl"
        Me.mid_pnl.Size = New System.Drawing.Size(332, 617)
        Me.mid_pnl.TabIndex = 11
        '
        'createPDF_btn
        '
        Me.createPDF_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createPDF_btn.BackColor = System.Drawing.Color.LightCoral
        Me.createPDF_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.createPDF_btn.ForeColor = System.Drawing.Color.White
        Me.createPDF_btn.Image = Global.ShippingStation.My.Resources.Resources.icons8_pdf_32
        Me.createPDF_btn.Location = New System.Drawing.Point(571, 35)
        Me.createPDF_btn.Name = "createPDF_btn"
        Me.createPDF_btn.Size = New System.Drawing.Size(43, 44)
        Me.createPDF_btn.TabIndex = 0
        Me.createPDF_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.createPDF_btn.UseVisualStyleBackColor = False
        Me.createPDF_btn.Visible = False
        '
        'generateAllDocs_btn
        '
        Me.generateAllDocs_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.generateAllDocs_btn.BackColor = System.Drawing.Color.Gray
        Me.generateAllDocs_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.generateAllDocs_btn.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generateAllDocs_btn.ForeColor = System.Drawing.Color.White
        Me.generateAllDocs_btn.Image = Global.ShippingStation.My.Resources.Resources.icons8_product_documents_32
        Me.generateAllDocs_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.generateAllDocs_btn.Location = New System.Drawing.Point(620, 35)
        Me.generateAllDocs_btn.Name = "generateAllDocs_btn"
        Me.generateAllDocs_btn.Size = New System.Drawing.Size(120, 44)
        Me.generateAllDocs_btn.TabIndex = 0
        Me.generateAllDocs_btn.Text = "All Docs"
        Me.generateAllDocs_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.generateAllDocs_btn.UseVisualStyleBackColor = False
        Me.generateAllDocs_btn.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.SeaGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = Global.ShippingStation.My.Resources.Resources.icons8_excel_32
        Me.Button1.Location = New System.Drawing.Point(522, 35)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 44)
        Me.Button1.TabIndex = 1
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.SteelBlue
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = Global.ShippingStation.My.Resources.Resources.icons8_word_32
        Me.Button2.Location = New System.Drawing.Point(473, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(43, 44)
        Me.Button2.TabIndex = 2
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'usr_lbl
        '
        Me.usr_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.usr_lbl.AutoSize = True
        Me.usr_lbl.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usr_lbl.Location = New System.Drawing.Point(5, 67)
        Me.usr_lbl.Name = "usr_lbl"
        Me.usr_lbl.Size = New System.Drawing.Size(63, 19)
        Me.usr_lbl.TabIndex = 7
        Me.usr_lbl.Text = "username"
        '
        'print_btn
        '
        Me.print_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.print_btn.Image = Global.ShippingStation.My.Resources.Resources.print_32
        Me.print_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.print_btn.Location = New System.Drawing.Point(1108, 43)
        Me.print_btn.Name = "print_btn"
        Me.print_btn.Size = New System.Drawing.Size(111, 40)
        Me.print_btn.TabIndex = 8
        Me.print_btn.Text = "Manifest"
        Me.print_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.print_btn.UseVisualStyleBackColor = True
        '
        'execute_btn
        '
        Me.execute_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.execute_btn.Image = Global.ShippingStation.My.Resources.Resources.Shipping_32
        Me.execute_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.execute_btn.Location = New System.Drawing.Point(1225, 43)
        Me.execute_btn.Name = "execute_btn"
        Me.execute_btn.Size = New System.Drawing.Size(126, 40)
        Me.execute_btn.TabIndex = 9
        Me.execute_btn.Text = "Complete"
        Me.execute_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.execute_btn.UseVisualStyleBackColor = True
        '
        'edit_btn
        '
        Me.edit_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edit_btn.Image = Global.ShippingStation.My.Resources.Resources.icons8_edit_32
        Me.edit_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.edit_btn.Location = New System.Drawing.Point(907, 43)
        Me.edit_btn.Name = "edit_btn"
        Me.edit_btn.Size = New System.Drawing.Size(94, 40)
        Me.edit_btn.TabIndex = 10
        Me.edit_btn.Text = "Edit"
        Me.edit_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.edit_btn.UseVisualStyleBackColor = True
        Me.edit_btn.Visible = False
        '
        'Save_Btn
        '
        Me.Save_Btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_Btn.Image = Global.ShippingStation.My.Resources.Resources.packing_32
        Me.Save_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save_Btn.Location = New System.Drawing.Point(1007, 43)
        Me.Save_Btn.Name = "Save_Btn"
        Me.Save_Btn.Size = New System.Drawing.Size(95, 40)
        Me.Save_Btn.TabIndex = 11
        Me.Save_Btn.Text = "Save"
        Me.Save_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Save_Btn.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Location = New System.Drawing.Point(985, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(26, 17)
        Me.Panel1.TabIndex = 5
        '
        'bottom_pnl
        '
        Me.bottom_pnl.BackColor = System.Drawing.Color.Transparent
        Me.bottom_pnl.Controls.Add(Me.Label9)
        Me.bottom_pnl.Controls.Add(Me.Save_Btn)
        Me.bottom_pnl.Controls.Add(Me.edit_btn)
        Me.bottom_pnl.Controls.Add(Me.execute_btn)
        Me.bottom_pnl.Controls.Add(Me.Panel2)
        Me.bottom_pnl.Controls.Add(Me.print_btn)
        Me.bottom_pnl.Controls.Add(Me.Panel1)
        Me.bottom_pnl.Controls.Add(Me.Label6)
        Me.bottom_pnl.Controls.Add(Me.usr_lbl)
        Me.bottom_pnl.Controls.Add(Me.Button2)
        Me.bottom_pnl.Controls.Add(Me.Button1)
        Me.bottom_pnl.Controls.Add(Me.generateAllDocs_btn)
        Me.bottom_pnl.Controls.Add(Me.createPDF_btn)
        Me.bottom_pnl.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottom_pnl.Location = New System.Drawing.Point(0, 671)
        Me.bottom_pnl.Name = "bottom_pnl"
        Me.bottom_pnl.Size = New System.Drawing.Size(1363, 91)
        Me.bottom_pnl.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(1140, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Split Container"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.GreenYellow
        Me.Panel2.Location = New System.Drawing.Point(1108, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(26, 17)
        Me.Panel2.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(1017, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Normal Pallet"
        '
        'Main
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1363, 762)
        Me.Controls.Add(Me.mid_pnl)
        Me.Controls.Add(Me.right_pnl)
        Me.Controls.Add(Me.left_pnl)
        Me.Controls.Add(Me.bottom_pnl)
        Me.Controls.Add(Me.top_pnl)
        Me.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Name = "Main"
        Me.Text = "Cricut Container Shipping"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.left_pnl.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.top_pnl.ResumeLayout(False)
        Me.top_pnl.PerformLayout()
        Me.right_pnl.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mid_pnl.ResumeLayout(False)
        Me.bottom_pnl.ResumeLayout(False)
        Me.bottom_pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents masterBarcode_txtbx As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents containerNo_txtbx As TextBox
    Friend WithEvents clrMasterBarcodeTxtbx_btn As Button
    Friend WithEvents addMasterBarcode_btn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents left_pnl As Panel
    Friend WithEvents top_pnl As Panel
    Friend WithEvents right_pnl As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents mainReset_btn As Button
    Friend WithEvents clrContainerNoTxtbx_btn As Button
    Friend WithEvents addContainerNo_btn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Pallet As DataGridViewTextBoxColumn
    Friend WithEvents SerialNo As DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As Panel
    Friend WithEvents mid_pnl As Panel
    Friend WithEvents container_lbl As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents rightSideInner_pnl As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents ItemCounter_lbl As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents containerStatus_lbl As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents splitPallet_btn As Button
    Friend WithEvents createPDF_btn As Button
    Friend WithEvents generateAllDocs_btn As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents usr_lbl As Label
    Friend WithEvents print_btn As Button
    Friend WithEvents execute_btn As Button
    Friend WithEvents edit_btn As Button
    Friend WithEvents Save_Btn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents bottom_pnl As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
End Class
