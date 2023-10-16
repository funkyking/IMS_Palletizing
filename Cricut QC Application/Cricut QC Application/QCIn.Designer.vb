<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QCIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QCIn))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.UpdateBtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.remainingSlot_lbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.clear_btn = New System.Windows.Forms.Button()
        Me.remove_btn = New System.Windows.Forms.Button()
        Me.CurrentUserSelect_btn = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Serial = New System.Windows.Forms.TextBox()
        Me.statuslbl = New System.Windows.Forms.Label()
        Me.Username = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AvailableSerialNo_lstbx = New System.Windows.Forms.ListBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.UpdateBtn)
        Me.GroupBox2.Controls.Add(Me.CancelBtn)
        Me.GroupBox2.Location = New System.Drawing.Point(418, 211)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(174, 156)
        Me.GroupBox2.TabIndex = 72
        Me.GroupBox2.TabStop = False
        '
        'UpdateBtn
        '
        Me.UpdateBtn.Image = Global.Cricut_QC_Application.My.Resources.Resources.icons8_save_32_1_
        Me.UpdateBtn.Location = New System.Drawing.Point(16, 17)
        Me.UpdateBtn.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.UpdateBtn.Name = "UpdateBtn"
        Me.UpdateBtn.Size = New System.Drawing.Size(142, 58)
        Me.UpdateBtn.TabIndex = 67
        Me.UpdateBtn.Text = "Save (IN)"
        Me.UpdateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.UpdateBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UpdateBtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Image = Global.Cricut_QC_Application.My.Resources.Resources.icons8_cancel_32
        Me.CancelBtn.Location = New System.Drawing.Point(16, 80)
        Me.CancelBtn.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(142, 58)
        Me.CancelBtn.TabIndex = 61
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(18, 380)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(574, 199)
        Me.DataGridView1.TabIndex = 70
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.remainingSlot_lbl)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.clear_btn)
        Me.GroupBox1.Controls.Add(Me.remove_btn)
        Me.GroupBox1.Controls.Add(Me.Username)
        Me.GroupBox1.Controls.Add(Me.CurrentUserSelect_btn)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Serial)
        Me.GroupBox1.Controls.Add(Me.statuslbl)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 22)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(394, 345)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "QC In"
        '
        'remainingSlot_lbl
        '
        Me.remainingSlot_lbl.AutoSize = True
        Me.remainingSlot_lbl.Location = New System.Drawing.Point(267, 96)
        Me.remainingSlot_lbl.Name = "remainingSlot_lbl"
        Me.remainingSlot_lbl.Size = New System.Drawing.Size(0, 18)
        Me.remainingSlot_lbl.TabIndex = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(177, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 18)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Available Space:"
        '
        'clear_btn
        '
        Me.clear_btn.Location = New System.Drawing.Point(300, 163)
        Me.clear_btn.Name = "clear_btn"
        Me.clear_btn.Size = New System.Drawing.Size(82, 39)
        Me.clear_btn.TabIndex = 68
        Me.clear_btn.Text = "Clear"
        Me.clear_btn.UseVisualStyleBackColor = True
        '
        'remove_btn
        '
        Me.remove_btn.Location = New System.Drawing.Point(300, 118)
        Me.remove_btn.Name = "remove_btn"
        Me.remove_btn.Size = New System.Drawing.Size(82, 39)
        Me.remove_btn.TabIndex = 67
        Me.remove_btn.Text = "Remove"
        Me.remove_btn.UseVisualStyleBackColor = True
        '
        'CurrentUserSelect_btn
        '
        Me.CurrentUserSelect_btn.Location = New System.Drawing.Point(299, 31)
        Me.CurrentUserSelect_btn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CurrentUserSelect_btn.Name = "CurrentUserSelect_btn"
        Me.CurrentUserSelect_btn.Size = New System.Drawing.Size(83, 28)
        Me.CurrentUserSelect_btn.TabIndex = 66
        Me.CurrentUserSelect_btn.Text = "Current User"
        Me.CurrentUserSelect_btn.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 18
        Me.ListBox1.Location = New System.Drawing.Point(74, 118)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(220, 166)
        Me.ListBox1.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 65)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 18)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Serial No:"
        '
        'Serial
        '
        Me.Serial.Location = New System.Drawing.Point(65, 62)
        Me.Serial.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Serial.Name = "Serial"
        Me.Serial.Size = New System.Drawing.Size(229, 26)
        Me.Serial.TabIndex = 57
        '
        'statuslbl
        '
        Me.statuslbl.AutoSize = True
        Me.statuslbl.ForeColor = System.Drawing.Color.Red
        Me.statuslbl.Location = New System.Drawing.Point(72, 291)
        Me.statuslbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.statuslbl.Name = "statuslbl"
        Me.statuslbl.Size = New System.Drawing.Size(0, 18)
        Me.statuslbl.TabIndex = 64
        '
        'Username
        '
        Me.Username.Location = New System.Drawing.Point(65, 31)
        Me.Username.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(229, 26)
        Me.Username.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 33)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 18)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Username:"
        '
        'AvailableSerialNo_lstbx
        '
        Me.AvailableSerialNo_lstbx.BackColor = System.Drawing.Color.Black
        Me.AvailableSerialNo_lstbx.ForeColor = System.Drawing.Color.Lime
        Me.AvailableSerialNo_lstbx.FormattingEnabled = True
        Me.AvailableSerialNo_lstbx.ItemHeight = 18
        Me.AvailableSerialNo_lstbx.Location = New System.Drawing.Point(418, 31)
        Me.AvailableSerialNo_lstbx.Name = "AvailableSerialNo_lstbx"
        Me.AvailableSerialNo_lstbx.Size = New System.Drawing.Size(174, 184)
        Me.AvailableSerialNo_lstbx.TabIndex = 71
        '
        'QCIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 600)
        Me.Controls.Add(Me.AvailableSerialNo_lstbx)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "QCIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Quality Control In"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents UpdateBtn As Button
    Friend WithEvents CancelBtn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Serial As TextBox
    Friend WithEvents statuslbl As Label
    Friend WithEvents Username As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CurrentUserSelect_btn As Button
    Friend WithEvents clear_btn As Button
    Friend WithEvents remove_btn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents remainingSlot_lbl As Label
    Friend WithEvents AvailableSerialNo_lstbx As ListBox
End Class
