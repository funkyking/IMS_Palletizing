Imports System.Data.SqlClient
Imports System.Net

Public Class LoginForm


#Region "Variables"

    'Variables
    Dim UID As String
    Dim userlvl As String
    Dim uname As String
    Dim visib As Boolean
    Dim logged As Boolean
    Dim connstr = ""

#End Region



    'Load Login Form
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            GlobalVariables.loginfrm = Me
            connstr = ReadValue("System", "SQLconnstr", IniPath)
        Catch ex As Exception
        End Try
    End Sub




#Region "Button Events"

    ' login Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            login()
        Catch ex As Exception
        End Try
    End Sub

    ' Password Visibility
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If visib = True Then
                Button3.BackgroundImage = My.Resources.invisible
                pw.UseSystemPasswordChar = True
                visib = False
            Else
                Button3.BackgroundImage = My.Resources.visible
                pw.UseSystemPasswordChar = False
                visib = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' Close the form
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
        End Try
    End Sub

#End Region



#Region "Key Trigger Events"

    ' Username Input Enter Key Pressed
    Private Sub username_KeyPress(sender As Object, e As KeyPressEventArgs) Handles username.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            pw.Select()
        End If
    End Sub

    ' Password Input Enter Key Pressed
    Private Sub pw_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pw.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Button1_Click(sender, e)
        End If
    End Sub

#End Region


#Region "Functions"
    Private Sub login()
        Dim conn As New SqlConnection(connstr)
        Try
            conn.Open()
            Dim frm1 As New Form1
            If conn.State = ConnectionState.Open Then
                Dim SQLcmd = New SqlCommand
                SQLcmd.Connection = conn
                SQLcmd.CommandText = "Select [User ID],
                            [User Name], 
                            [User Level],
                            [Password]
                FROM [CRICUT].[CUPID].[UserMaster] WHERE  [Delete]='False'"
                Dim ds = SQLcmd.ExecuteReader
                If ds.HasRows Then
                    While ds.Read
                        If ds.Item("User ID") = username.Text Or ds.Item("User Name") = username.Text Then
                            Dim temppw As String
                            temppw = ds.Item("Password")
                            If pw.Text = Decrypt(temppw) Then
                                UID = ds.Item("User ID")
                                uname = ds.Item("User Name")
                                userlvl = ds.Item("User Level")
                                GlobalVariables.UserID = UID
                                GlobalVariables.Userlvl = userlvl
                                GlobalVariables.UserName = uname
                                frm1.WindowState = FormWindowState.Maximized
                                frm1.ShowDialog()
                                pw.Text = ""
                                username.Text = ""
                                logged = True
                                Me.Hide()
                            End If
                        End If
                    End While
                End If
            End If
            If Not logged Then
                statuslbl.Text = "Invalid Username or Password"
            End If
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

#End Region




End Class