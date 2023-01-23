Imports System.Data.OleDb
Module dbconnection
    Public cn As New OleDbConnection
    Public cmd As OleDbCommand
    Public sql As String
    Public dr As OleDbDataReader

    Public Sub connection()
        cn.Close()
        cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\OneDrive\Desktop\IP-Calculator\IP-Calculator\bin\Debug\vlsm.mdb"
        cn.Open()
    End Sub
End Module
