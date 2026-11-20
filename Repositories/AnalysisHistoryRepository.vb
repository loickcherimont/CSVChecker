Imports System.ComponentModel.DataAnnotations
Imports System.Net.NetworkInformation
Imports System.Web.Services.Description
Imports Npgsql

Public Class AnalysisHistoryRepository

    Public Property DBConnection As DatabaseConnection
    Public Sub New()
        Dim PGUsername As String = Environment.GetEnvironmentVariable("PGUSERNAME")
        Dim PGPassword As String = Environment.GetEnvironmentVariable("PGPASSWORD")

        DBConnection = New DatabaseConnection("localhost", 5432, "csvchecker", PGUsername, PGPassword)
    End Sub

    Public Function Save(ByVal analysis As AnalysisHistory) As AnalysisHistory
        Using connection As NpgsqlConnection = DBConnection.GetConnection()
            connection.Open()
            'Cast the status from Analysis object to adapt to custom STATUS_TYPE from PostgreSQL
            Dim cmd = New NpgsqlCommand("INSERT INTO analysis_history(id, file_name, analysis_date, status, details) VALUES(@Id, @FileName, @AnalysisDate, CAST(@Status AS STATUS_TYPE), @Details)", connection)
            cmd.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Uuid).Value = analysis.Id
            cmd.Parameters.Add("@FileName", NpgsqlTypes.NpgsqlDbType.Varchar).Value = analysis.FileName
            cmd.Parameters.Add("@AnalysisDate", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = analysis.AnalysisDate
            cmd.Parameters.Add("@Status", NpgsqlTypes.NpgsqlDbType.Varchar).Value = analysis.Status.ToString()
            cmd.Parameters.Add("@Details", NpgsqlTypes.NpgsqlDbType.Text).Value = analysis.Details
            cmd.ExecuteNonQuery()
        End Using
        Return New AnalysisHistory(analysis.FileName, analysis.AnalysisDate, analysis.Status, analysis.Details)
    End Function

    Public Function FindAll() As List(Of AnalysisHistory)
        Dim analysisList As New List(Of AnalysisHistory)
        Using connection As NpgsqlConnection = DBConnection.GetConnection()
            connection.Open()
            'Prepare the query to execute
            Dim cmd = New NpgsqlCommand("SELECT * FROM analysis_history", connection)
            Dim rdr As NpgsqlDataReader = cmd.ExecuteReader()
            While rdr.Read()

                'Convert the string from db in AnalysisStatus Enum for the 4th column

                Dim analysis As New AnalysisHistory(rdr.GetGuid(0), rdr.GetString(1), rdr.GetDateTime(2), CType([Enum].Parse(GetType(AnalysisStatus), rdr.GetString(3)), AnalysisStatus), rdr.GetString(4))
                analysisList.Add(analysis)
            End While
        End Using
        Return analysisList
    End Function
End Class
