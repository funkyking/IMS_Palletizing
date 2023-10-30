Public Class GlobalVariables
    Public Shared MainInstance As Main
    Public Shared MasterList As List(Of BarcodeItem) = New List(Of BarcodeItem)
    Public Shared MasterBarcodeItemList As List(Of MasterBarcodeItem) = New List(Of MasterBarcodeItem)
    Public Shared palletcounter As Integer = 1
    Public Shared ContainerName As String = Nothing
    Public Shared CID_Existance As Boolean = False
    Public Shared MasterContainerID As Guid
    Public Shared MasterContainerCompleted As Boolean = False
    Public Shared AllowContainerEdit As Boolean = False

    'User Interface
    Public Shared Userlvl As String = ""
    Public Shared UserName As String = ""
    Public Shared UserID As String = ""
    Public Shared LoginFrmInstance As LoginForm

End Class
