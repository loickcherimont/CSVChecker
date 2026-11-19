Imports Npgsql
Public Class DatabaseConnection

    Public Property Status As String
    Public Sub New(ByVal Host As String, ByVal Port As Integer, ByVal Database As String, ByVal Username As String, ByVal Password As String)
        Dim connectionString As String = $"Host={Host};Port={Port.ToString()};Database={Database};Username={Username};Password={Password}"
        Try
            Using connection As New NpgsqlConnection(connectionString)
                connection.Open()
                Status = "Connexion à la base de données réussie"
            End Using
        Catch ex As Exception
            Status = "Echec de connexion à la base de données: " & ex.Message
        End Try
    End Sub
End Class
