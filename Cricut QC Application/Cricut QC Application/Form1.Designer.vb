<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DeleteQcRecords_btn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.poNumber_txtbx = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.status_lbl = New System.Windows.Forms.Label()
        Me.masterBarcode_txtbx = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.subGroup_cmbx = New System.Windows.Forms.ComboBox()
        Me.search_btn = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.workOrder_cmbx = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.shift_cmbx = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pallet_cmbx = New System.Windows.Forms.ComboBox()
        Me.PrintReportBtn = New System.Windows.Forms.Button()
        Me.PrintOrderBtn = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnQCin = New System.Windows.Forms.Button()
        Me.btnQCout = New System.Windows.Forms.Button()
        Me.engineering_btn = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DeleteQcRecords_btn
        '
        Me.DeleteQcRecords_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteQcRecords_btn.BackColor = System.Drawing.Color.Firebrick
        Me.DeleteQcRecords_btn.FlatAppearance.BorderSize = 0
        Me.DeleteQcRecords_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeleteQcRecords_btn.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteQcRecords_btn.ForeColor = System.Drawing.SystemColors.InactiveBorder
        Me.DeleteQcRecords_btn.Location = New System.Drawing.Point(798, 48)
        Me.DeleteQcRecords_btn.Name = "DeleteQcRecords_btn"
        Me.DeleteQcRecords_btn.Size = New System.Drawing.Size(95, 30)
        Me.DeleteQcRecords_btn.TabIndex = 51
        Me.DeleteQcRecords_btn.Text = "Delete Records"
        Me.DeleteQcRecords_btn.UseVisualStyleBackColor = False
        Me.DeleteQcRecords_btn.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(419, 82)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(475, 508)
        Me.DataGridView1.TabIndex = 48
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.poNumber_txtbx)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.status_lbl)
        Me.GroupBox3.Controls.Add(Me.masterBarcode_txtbx)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.subGroup_cmbx)
        Me.GroupBox3.Controls.Add(Me.search_btn)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.workOrder_cmbx)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.shift_cmbx)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.pallet_cmbx)
        Me.GroupBox3.Controls.Add(Me.PrintReportBtn)
        Me.GroupBox3.Controls.Add(Me.PrintOrderBtn)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 75)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(386, 345)
        Me.GroupBox3.TabIndex = 72
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Work Order"
        '
        'poNumber_txtbx
        '
        Me.poNumber_txtbx.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.poNumber_txtbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.poNumber_txtbx.Location = New System.Drawing.Point(136, 152)
        Me.poNumber_txtbx.Name = "poNumber_txtbx"
        Me.poNumber_txtbx.ReadOnly = True
        Me.poNumber_txtbx.Size = New System.Drawing.Size(200, 26)
        Me.poNumber_txtbx.TabIndex = 78
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(86, 150)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 23)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Po No:"
        '
        'status_lbl
        '
        Me.status_lbl.AutoSize = True
        Me.status_lbl.ForeColor = System.Drawing.Color.Red
        Me.status_lbl.Location = New System.Drawing.Point(166, 42)
        Me.status_lbl.Name = "status_lbl"
        Me.status_lbl.Size = New System.Drawing.Size(0, 13)
        Me.status_lbl.TabIndex = 74
        '
        'masterBarcode_txtbx
        '
        Me.masterBarcode_txtbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masterBarcode_txtbx.Location = New System.Drawing.Point(136, 58)
        Me.masterBarcode_txtbx.Name = "masterBarcode_txtbx"
        Me.masterBarcode_txtbx.Size = New System.Drawing.Size(200, 29)
        Me.masterBarcode_txtbx.TabIndex = 73
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 61)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 23)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Master Barcode:"
        '
        'subGroup_cmbx
        '
        Me.subGroup_cmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.subGroup_cmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.subGroup_cmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.subGroup_cmbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subGroup_cmbx.FormattingEnabled = True
        Me.subGroup_cmbx.Location = New System.Drawing.Point(136, 182)
        Me.subGroup_cmbx.Margin = New System.Windows.Forms.Padding(2)
        Me.subGroup_cmbx.Name = "subGroup_cmbx"
        Me.subGroup_cmbx.Size = New System.Drawing.Size(200, 28)
        Me.subGroup_cmbx.TabIndex = 26
        '
        'search_btn
        '
        Me.search_btn.BackColor = System.Drawing.Color.Transparent
        Me.search_btn.BackgroundImage = Global.Cricut_QC_Application.My.Resources.Resources.icons8_search_black_32
        Me.search_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.search_btn.FlatAppearance.BorderSize = 0
        Me.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.search_btn.Font = New System.Drawing.Font("Bahnschrift Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.search_btn.ForeColor = System.Drawing.SystemColors.InactiveBorder
        Me.search_btn.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.search_btn.Location = New System.Drawing.Point(338, 65)
        Me.search_btn.Name = "search_btn"
        Me.search_btn.Size = New System.Drawing.Size(20, 22)
        Me.search_btn.TabIndex = 52
        Me.search_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.search_btn.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(54, 182)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 23)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Sub Group:"
        '
        'workOrder_cmbx
        '
        Me.workOrder_cmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.workOrder_cmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.workOrder_cmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.workOrder_cmbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workOrder_cmbx.FormattingEnabled = True
        Me.workOrder_cmbx.Location = New System.Drawing.Point(136, 118)
        Me.workOrder_cmbx.Margin = New System.Windows.Forms.Padding(2)
        Me.workOrder_cmbx.Name = "workOrder_cmbx"
        Me.workOrder_cmbx.Size = New System.Drawing.Size(200, 28)
        Me.workOrder_cmbx.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(82, 118)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 23)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Mo No:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(89, 251)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 23)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Shift:"
        '
        'shift_cmbx
        '
        Me.shift_cmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.shift_cmbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shift_cmbx.FormattingEnabled = True
        Me.shift_cmbx.Items.AddRange(New Object() {"DAY", "NIGHT"})
        Me.shift_cmbx.Location = New System.Drawing.Point(136, 246)
        Me.shift_cmbx.Margin = New System.Windows.Forms.Padding(2)
        Me.shift_cmbx.Name = "shift_cmbx"
        Me.shift_cmbx.Size = New System.Drawing.Size(200, 28)
        Me.shift_cmbx.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(64, 219)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 23)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Pallet No:"
        '
        'pallet_cmbx
        '
        Me.pallet_cmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.pallet_cmbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pallet_cmbx.FormattingEnabled = True
        Me.pallet_cmbx.Location = New System.Drawing.Point(136, 214)
        Me.pallet_cmbx.Margin = New System.Windows.Forms.Padding(2)
        Me.pallet_cmbx.Name = "pallet_cmbx"
        Me.pallet_cmbx.Size = New System.Drawing.Size(200, 28)
        Me.pallet_cmbx.TabIndex = 2
        '
        'PrintReportBtn
        '
        Me.PrintReportBtn.AutoSize = True
        Me.PrintReportBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintReportBtn.Location = New System.Drawing.Point(232, 292)
        Me.PrintReportBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.PrintReportBtn.Name = "PrintReportBtn"
        Me.PrintReportBtn.Size = New System.Drawing.Size(104, 36)
        Me.PrintReportBtn.TabIndex = 5
        Me.PrintReportBtn.Text = "Print Report"
        Me.PrintReportBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PrintReportBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.PrintReportBtn.UseVisualStyleBackColor = True
        '
        'PrintOrderBtn
        '
        Me.PrintOrderBtn.AutoSize = True
        Me.PrintOrderBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintOrderBtn.Location = New System.Drawing.Point(133, 292)
        Me.PrintOrderBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.PrintOrderBtn.Name = "PrintOrderBtn"
        Me.PrintOrderBtn.Size = New System.Drawing.Size(95, 36)
        Me.PrintOrderBtn.TabIndex = 4
        Me.PrintOrderBtn.Text = "Print Order"
        Me.PrintOrderBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PrintOrderBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.PrintOrderBtn.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label5.Location = New System.Drawing.Point(258, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "Barcode Input"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnQCin)
        Me.GroupBox1.Controls.Add(Me.btnQCout)
        Me.GroupBox1.Controls.Add(Me.engineering_btn)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 426)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(228, 164)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Actions"
        '
        'btnQCin
        '
        Me.btnQCin.AutoSize = True
        Me.btnQCin.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnQCin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQCin.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQCin.ForeColor = System.Drawing.Color.White
        Me.btnQCin.Image = Global.Cricut_QC_Application.My.Resources.Resources.icons8_fork_lift_32
        Me.btnQCin.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnQCin.Location = New System.Drawing.Point(21, 31)
        Me.btnQCin.Name = "btnQCin"
        Me.btnQCin.Size = New System.Drawing.Size(92, 50)
        Me.btnQCin.TabIndex = 70
        Me.btnQCin.Text = "QC In"
        Me.btnQCin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQCin.UseVisualStyleBackColor = False
        '
        'btnQCout
        '
        Me.btnQCout.AutoSize = True
        Me.btnQCout.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnQCout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQCout.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQCout.ForeColor = System.Drawing.Color.White
        Me.btnQCout.Image = Global.Cricut_QC_Application.My.Resources.Resources.icons8_truck_tail_lift_32
        Me.btnQCout.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnQCout.Location = New System.Drawing.Point(119, 31)
        Me.btnQCout.Name = "btnQCout"
        Me.btnQCout.Size = New System.Drawing.Size(96, 50)
        Me.btnQCout.TabIndex = 69
        Me.btnQCout.Text = "QC Out"
        Me.btnQCout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQCout.UseVisualStyleBackColor = False
        '
        'engineering_btn
        '
        Me.engineering_btn.AutoSize = True
        Me.engineering_btn.BackColor = System.Drawing.Color.SeaGreen
        Me.engineering_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.engineering_btn.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.engineering_btn.ForeColor = System.Drawing.Color.White
        Me.engineering_btn.Image = Global.Cricut_QC_Application.My.Resources.Resources.engineering_32
        Me.engineering_btn.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.engineering_btn.Location = New System.Drawing.Point(21, 87)
        Me.engineering_btn.Name = "engineering_btn"
        Me.engineering_btn.Size = New System.Drawing.Size(194, 50)
        Me.engineering_btn.TabIndex = 71
        Me.engineering_btn.Text = "Enginnering"
        Me.engineering_btn.UseVisualStyleBackColor = False
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox1.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Lime
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 19
        Me.ListBox1.Location = New System.Drawing.Point(246, 434)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(152, 156)
        Me.ListBox1.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift Condensed", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(11, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(290, 45)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Quality Control Centre"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 623)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DeleteQcRecords_btn)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quality Control Check"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DeleteQcRecords_btn As Button
    Friend WithEvents search_btn As Button
    Friend WithEvents btnQCout As Button
    Friend WithEvents btnQCin As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents subGroup_cmbx As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents workOrder_cmbx As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents shift_cmbx As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents pallet_cmbx As ComboBox
    Friend WithEvents PrintReportBtn As Button
    Friend WithEvents PrintOrderBtn As Button
    Friend WithEvents engineering_btn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents masterBarcode_txtbx As TextBox
    Friend WithEvents status_lbl As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents poNumber_txtbx As TextBox
End Class
