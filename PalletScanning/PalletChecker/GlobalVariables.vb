Imports System.Data.SqlClient

Public Class GlobalVariables

    Public Shared SqlConnectionAddress = ReadValue("System", "SQLconnstr", IniPath)
    Public Shared AdminAccess As Boolean = False
    Public Shared LoginInstance As frmLogin = Nothing


    Public Function AutoDetermineSqlConnection()
        Try
            Dim i = 0

            Dim connstr = ReadValue("System", "SQLconnstr", IniPath)
            Dim conn As New SqlConnection(connstr)
            Try
                conn.Open()
                If conn.State = ConnectionState.Open Then
                    SqlConnectionAddress = connstr
                End If
            Catch ex As Exception
            End Try

        Catch ex As Exception
        End Try
    End Function

End Class
