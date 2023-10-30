Public Class GlobalVariables

    'Login Form Instance
    Public Shared loginfrm As New LoginForm
    Public Shared MainFrm As New Form1


    'User Interface
    Public Shared Userlvl As String = ""
    Public Shared UserName As String = ""
    Public Shared UserID As String = ""


    Public Shared WorkOrderID As Guid
    Public Shared PoNumber As String = ""
    Public Shared WorkOrder As String = ""
    Public Shared SubGroup As String = ""
    Public Shared Line As String = ""
    Public Shared PalletNo As String = ""
    Public Shared Shift As String = ""
    Public Shared Completed As String = ""
    Public Shared Count As Integer
    Public Shared TotalOrderCount As Integer
    Public Shared Quantity As Integer

End Class
