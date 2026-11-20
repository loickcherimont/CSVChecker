Imports Npgsql

'Connect to database, this class provides a connection using the connection string via GetConnection method.
Public Class DatabaseConnection

    Public Property ConnectionString As String
    Public Sub New(ByVal Host As String, ByVal Port As Integer, ByVal Database As String, ByVal Username As String, ByVal Password As String)
        ConnectionString = $"Host={Host};Port={Port.ToString()};Database={Database};Username={Username};Password={Password}"
    End Sub

    Public Function GetConnection()
        Return New NpgsqlConnection(ConnectionString)
    End Function
End Class
