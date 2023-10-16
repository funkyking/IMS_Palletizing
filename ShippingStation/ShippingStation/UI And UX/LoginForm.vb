Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class LoginForm
    Dim UID As String
    Dim userlvl As String
    Dim uname As String
    Dim visib As Boolean
    Dim logged As Boolean
    Dim connstr = ""

    ' Load Form
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connstr = ReadValue("System", "SQLconnstr", IniPath)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub username_KeyPress(sender As Object, e As KeyPressEventArgs) Handles username.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            pw.Select()
        End If
    End Sub

    Private Sub pw_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pw.KeyPress
        Try
            Button1_Click(sender, e)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Conn = New SqlConnection(connstr)
        Try
            logged = False

            Dim main = New Main

            Conn.Open()
            If Conn.State = ConnectionState.Open Then
                Dim SQLcmd = New SqlCommand
                SQLcmd.Connection = Conn
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
                                Me.Hide()
                                UID = ds.Item("User ID")
                                uname = ds.Item("User Name")
                                userlvl = ds.Item("User Level")
                                GlobalVariables.UserID = UID
                                GlobalVariables.Userlvl = userlvl
                                GlobalVariables.UserName = uname
                                GlobalVariables.LoginFrmInstance = Me
                                main.WindowState = FormWindowState.Maximized
                                main.ShowDialog()
                                pw.Text = ""
                                username.Text = ""
                                logged = True

                            End If
                        End If


                    End While
                End If
            End If
            If Not logged Then
                statuslbl.Text = "Invalid Username or Password"
            End If
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If visib = True Then
            pw.UseSystemPasswordChar = True
            visib = False
        Else
            pw.UseSystemPasswordChar = False
            visib = True
        End If
    End Sub

    Private Sub pw_TextChanged(sender As Object, e As EventArgs) Handles pw.TextChanged
        statuslbl.Text = ""
    End Sub

    Private Sub username_TextChanged(sender As Object, e As EventArgs) Handles username.TextChanged
        statuslbl.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub LoginForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            Me.Dispose()
        Catch ex As Exception
        End Try
    End Sub
End Class