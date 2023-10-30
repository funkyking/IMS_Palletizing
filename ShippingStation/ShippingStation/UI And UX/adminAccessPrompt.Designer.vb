<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class adminAccessPrompt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(adminAccessPrompt))
        Me.password_txtbx = New System.Windows.Forms.TextBox()
        Me.login_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.username_txtbx = New System.Windows.Forms.TextBox()
        Me.status_lbl = New System.Windows.Forms.Label()
        Me.close_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'password_txtbx
        '
        Me.password_txtbx.Location = New System.Drawing.Point(60, 91)
        Me.password_txtbx.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.password_txtbx.Name = "password_txtbx"
        Me.password_txtbx.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.password_txtbx.Size = New System.Drawing.Size(212, 30)
        Me.password_txtbx.TabIndex = 0
        Me.password_txtbx.UseSystemPasswordChar = True
        '
        'login_btn
        '
        Me.login_btn.Location = New System.Drawing.Point(62, 140)
        Me.login_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.login_btn.Name = "login_btn"
        Me.login_btn.Size = New System.Drawing.Size(100, 46)
        Me.login_btn.TabIndex = 1
        Me.login_btn.Text = "Go"
        Me.login_btn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Pass :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "User :"
        '
        'username_txtbx
        '
        Me.username_txtbx.Location = New System.Drawing.Point(60, 35)
        Me.username_txtbx.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.username_txtbx.Name = "username_txtbx"
        Me.username_txtbx.Size = New System.Drawing.Size(212, 30)
        Me.username_txtbx.TabIndex = 3
        '
        'status_lbl
        '
        Me.status_lbl.AutoSize = True
        Me.status_lbl.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status_lbl.ForeColor = System.Drawing.Color.Firebrick
        Me.status_lbl.Location = New System.Drawing.Point(58, 19)
        Me.status_lbl.Name = "status_lbl"
        Me.status_lbl.Size = New System.Drawing.Size(0, 19)
        Me.status_lbl.TabIndex = 5
        '
        'close_btn
        '
        Me.close_btn.Location = New System.Drawing.Point(170, 140)
        Me.close_btn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.close_btn.Name = "close_btn"
        Me.close_btn.Size = New System.Drawing.Size(100, 46)
        Me.close_btn.TabIndex = 6
        Me.close_btn.Text = "Cancel"
        Me.close_btn.UseVisualStyleBackColor = True
        '
        'adminAccessPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 212)
        Me.Controls.Add(Me.close_btn)
        Me.Controls.Add(Me.status_lbl)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.username_txtbx)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.login_btn)
        Me.Controls.Add(Me.password_txtbx)
        Me.Font = New System.Drawing.Font("Bahnschrift SemiLight Condensed", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "adminAccessPrompt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Content (Admin Only)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents password_txtbx As TextBox
    Friend WithEvents login_btn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents username_txtbx As TextBox
    Friend WithEvents status_lbl As Label
    Friend WithEvents close_btn As Button
End Class
