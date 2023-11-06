Imports System.Data.SqlClient
Imports System.Windows.Controls

Public Class listItem_SerialList



#Region "Variables"

    Dim wo = ""
    Dim Po = ""
    Dim SKU = ""
    Dim PltNo = ""
    Dim Sft = ""


    'Connection string 
    Dim connstr = ""
    Public incomingBarcode As String = ""

#End Region







    'this form load button
    Private Sub listItem_SerialList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connstr = ReadValue("System", "SQLconnstr", IniPath)
        Catch ex As Exception
        End Try
    End Sub


    'this form close button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub


#Region "Functions"




    Private Function splitBarcode(ByVal Input As String)
        Try
            Dim strSplit() As String = Input.Split(",")
            If strSplit.Length >= 5 Then
                wo = strSplit(0).Trim()
                Po = strSplit(1).Trim()
                SKU = strSplit(2).Trim()
                PltNo = strSplit(3).Trim()
                Sft = strSplit(4).Trim()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function loadgrid()
        Dim conn As New SqlConnection()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then

            End If
        Catch ex As Exception
        End Try
    End Function

#End Region


End Class