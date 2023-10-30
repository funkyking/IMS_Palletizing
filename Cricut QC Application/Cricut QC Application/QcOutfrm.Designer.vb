<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QcOutfrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QcOutfrm))
        Me.cUser_btn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Serial = New System.Windows.Forms.TextBox()
        Me.statuslbl = New System.Windows.Forms.Label()
        Me.Username = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.remove_btn = New System.Windows.Forms.Button()
        Me.clear_btn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cUser_btn
        '
        Me.cUser_btn.Location = New System.Drawing.Point(332, 227)
        Me.cUser_btn.Name = "cUser_btn"
        Me.cUser_btn.Size = New System.Drawing.Size(63, 34)
        Me.cUser_btn.TabIndex = 1
        Me.cUser_btn.Text = "Current User"
        Me.cUser_btn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.clear_btn)
        Me.GroupBox1.Controls.Add(Me.remove_btn)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Controls.Add(Me.cUser_btn)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Serial)
        Me.GroupBox1.Controls.Add(Me.statuslbl)
        Me.GroupBox1.Controls.Add(Me.Username)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(413, 292)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "QC Out"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(76, 71)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(252, 134)
        Me.ListBox1.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 36)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Serial No:"
        '
        'Serial
        '
        Me.Serial.Location = New System.Drawing.Point(76, 33)
        Me.Serial.Margin = New System.Windows.Forms.Padding(2)
        Me.Serial.Name = "Serial"
        Me.Serial.Size = New System.Drawing.Size(252, 20)
        Me.Serial.TabIndex = 57
        '
        'statuslbl
        '
        Me.statuslbl.AutoSize = True
        Me.statuslbl.ForeColor = System.Drawing.Color.Red
        Me.statuslbl.Location = New System.Drawing.Point(73, 264)
        Me.statuslbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.statuslbl.Name = "statuslbl"
        Me.statuslbl.Size = New System.Drawing.Size(0, 13)
        Me.statuslbl.TabIndex = 64
        '
        'Username
        '
        Me.Username.Location = New System.Drawing.Point(76, 229)
        Me.Username.Margin = New System.Windows.Forms.Padding(2)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(252, 20)
        Me.Username.TabIndex = 58
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(93, 293)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 63
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 232)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Username:"
        '
        'CancelBtn
        '
        Me.CancelBtn.Image = Global.Cricut_QC_Application.My.Resources.Resources.icons8_cancel_32
        Me.CancelBtn.Location = New System.Drawing.Point(14, 87)
        Me.CancelBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(104, 42)
        Me.CancelBtn.TabIndex = 61
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'SaveBtn
        '
        Me.SaveBtn.Image = Global.Cricut_QC_Application.My.Resources.Resources.icons8_save_32_1_
        Me.SaveBtn.Location = New System.Drawing.Point(14, 16)
        Me.SaveBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(104, 42)
        Me.SaveBtn.TabIndex = 60
        Me.SaveBtn.Text = "Out"
        Me.SaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SaveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'remove_btn
        '
        Me.remove_btn.Location = New System.Drawing.Point(335, 71)
        Me.remove_btn.Name = "remove_btn"
        Me.remove_btn.Size = New System.Drawing.Size(60, 41)
        Me.remove_btn.TabIndex = 66
        Me.remove_btn.Text = "Remove"
        Me.remove_btn.UseVisualStyleBackColor = True
        '
        'clear_btn
        '
        Me.clear_btn.Location = New System.Drawing.Point(335, 118)
        Me.clear_btn.Name = "clear_btn"
        Me.clear_btn.Size = New System.Drawing.Size(60, 41)
        Me.clear_btn.TabIndex = 67
        Me.clear_btn.Text = "Clear"
        Me.clear_btn.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SaveBtn)
        Me.Panel1.Controls.Add(Me.CancelBtn)
        Me.Panel1.Location = New System.Drawing.Point(431, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(135, 170)
        Me.Panel1.TabIndex = 68
        '
        'QcOutfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 328)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "QcOutfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quality Control Out"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cUser_btn As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Serial As TextBox
    Friend WithEvents statuslbl As Label
    Friend WithEvents Username As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CancelBtn As Button
    Friend WithEvents SaveBtn As Button
    Friend WithEvents clear_btn As Button
    Friend WithEvents remove_btn As Button
    Friend WithEvents Panel1 As Panel
End Class
