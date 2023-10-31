Imports System.Data.SqlClient

Public Class frmDeletedWorkOrderList

    Dim connstr = ""


    Private Sub frmDeletedWorkOrderList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connstr = ReadValue("System", "SQLconnstr", IniPath)
            LoadGrid()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub


    Private Function LoadGrid()
        Try
            Dim Conn = New SqlConnection(connstr)
            Conn.Open()
            Dim SQLcmd = New SqlCommand
            Dim strsql = "SELECT [Work Order ID]
                              ,[Work Order]
                              ,[Po Number]
                              ,[Sub Group]
                              ,[Part Name]
                              ,[Model]
                              ,[Line]
                              ,[Quantity]
                              ,[Count]
                              ,[Total Order Count]
                              ,[Description]
                              ,[Completed]
                              ,[Modified Date]
                          FROM [CRICUT].[CUPID].[DeletedWorkOrderMaster]
                          ORDER BY [Modified Date] DESC"
            Dim dt = New DataTable
            dt.Clear()
            Dim da = New SqlDataAdapter(strsql, Conn)
            da.Fill(dt)
            da.Dispose()
            DataGridView1.DataSource = dt
            DataGridView1.ClearSelection()
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function


End Class