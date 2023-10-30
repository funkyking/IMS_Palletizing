Imports System.Data.SqlClient

Public Class adminAccessPrompt

    Dim UID As String
    Dim userlvl As String
    Dim uname As String
    Dim visib As Boolean
    Dim logged As Boolean
    Dim connstr = ""


    Private Sub adminAccessPrompt_Load(sender As Object, e As EventArgs) Handles Me.Load
        connstr = ReadValue("System", "SQLconnstr", IniPath)
        username_txtbx.Select()
    End Sub

    Private Sub username_txtbx_TextChanged(sender As Object, e As EventArgs) Handles username_txtbx.TextChanged
        status_lbl.Text = ""
    End Sub

    Private Sub password_txtbx_TextChanged(sender As Object, e As EventArgs) Handles password_txtbx.TextChanged
        status_lbl.Text = ""
    End Sub

    Private Sub username_txtbx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles username_txtbx.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            password_txtbx.Select()
        End If
    End Sub

    Private Sub password_txtbx_KeyPress(sender As Object, e As KeyPressEventArgs) Handles password_txtbx.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            login_btn_Click(sender, e)
        End If
    End Sub

    Private Sub login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click
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
                        If ds.Item("User ID") = username_txtbx.Text Or ds.Item("User Name") = username_txtbx.Text Then
                            Dim temppw As String
                            temppw = ds.Item("Password")
                            If password_txtbx.Text = Decrypt(temppw) Then
                                Me.Hide()
                                UID = ds.Item("User ID")
                                uname = ds.Item("User Name")
                                userlvl = ds.Item("User Level")
                                password_txtbx.Text = ""
                                username_txtbx.Text = ""

                                If userlvl = "Admin" Then
                                    logged = True
                                Else
                                    logged = False
                                End If
                            End If
                        End If
                    End While
                End If
            End If
            Conn?.Close()
            If Not logged Then
                status_lbl.Text = "Invalid Username or Password (Access Denied)"
                username_txtbx.Text = ""
                password_txtbx.Text = ""
                GlobalVariables.AllowContainerEdit = False
            Else
                GlobalVariables.AllowContainerEdit = True
                Me.Close()
            End If
        Catch ex As Exception
            status_lbl.Text = ex.Message()
            Conn?.Close()
        Finally
            Conn?.Close()
            username_txtbx.Select()
        End Try
    End Sub

    Private Sub close_btn_Click(sender As Object, e As EventArgs) Handles close_btn.Click
        Me.Close()
    End Sub


End Class