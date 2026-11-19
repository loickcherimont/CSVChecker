Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Data.SqlClient

Public Class _Default
    Inherits Page

    Private EXPECTED_HEADER() As String = {"Identifiant", "Equipement", "NumeroSerie", "Proprietaire", "DateAcquisition"}

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim PGUsername As String = Environment.GetEnvironmentVariable("PGUSERNAME")
        Dim PGPassword As String = Environment.GetEnvironmentVariable("PGPASSWORD")
        Dim newDataConnection As New DatabaseConnection("localhost", 5432, "csvchecker", PGUsername, PGPassword)
        DatabaseInfo.Text = newDataConnection.Status
        DatabaseInfo.Visible = True
    End Sub

    Protected Sub AnalyzeBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        ErrorMessage.Text = String.Empty
        ErrorMessage.Visible = False
        SuccessMessage.Visible = False

        If Not CsvFileUpload.HasFile Then
            ErrorMessage.Text = "Please provide a file."
            ErrorMessage.Visible = True
            Return
        End If

        If isNotCsvFile(CsvFileUpload) Then
            ErrorMessage.Text = "Only CSV file are allowed."
            ErrorMessage.Visible = True
            Return
        End If

        If isCsvFileEmpty(CsvFileUpload) Then
            ErrorMessage.Text = "CSV file cannot be empty."
            ErrorMessage.Visible = True
            Return
        End If

        If Not containsTheExpectedHeader(CsvFileUpload) Then
            ErrorMessage.Text = "The CSV file must contains the following header at the line 1: " & Join(EXPECTED_HEADER, ";")
            ErrorMessage.Visible = True
            Return
        End If

        If Not isOkForNumberOfColumns(CsvFileUpload) Then
            ErrorMessage.Text = "The number of columns in the CSV file is not correct."
            ErrorMessage.Visible = True
            Return
        End If

        SuccessMessage.Text = "File uploaded with success"
        SuccessMessage.Visible = True

    End Sub

    Protected Function isNotCsvFile(ByVal fileToUpload As FileUpload) As Boolean
        Dim extension As String = System.IO.Path.GetExtension(fileToUpload.FileName)
        Dim ALLOWED_EXTENSION As String = ".csv"
        Return Not String.Equals(extension, ALLOWED_EXTENSION, StringComparison.OrdinalIgnoreCase)
    End Function

    Protected Function isCsvFileEmpty(ByVal fileToUpload As FileUpload) As Boolean
        Dim fileSize As Long = fileToUpload.PostedFile.ContentLength
        Return fileSize = 0
    End Function

    Protected Function containsTheExpectedHeader(ByVal fileToUpload As FileUpload) As Boolean
        Using reader As New StreamReader(fileToUpload.FileContent)
            Dim firstLine As String = reader.ReadLine()
            Dim fileTitles() As String = Split(firstLine, ";")

            'Avoid comparison and out of the bound exception if filesTitles and EXPECTED_HEADER have different length
            If fileTitles.Length <> EXPECTED_HEADER.Length Then
                Return False
            End If

            For i = 0 To fileTitles.Length - 1
                If fileTitles(i) <> EXPECTED_HEADER(i) Then
                    Return False
                End If
            Next
        End Using
        Return True
    End Function
    Protected Function isOkForNumberOfColumns(ByVal fileToUpload As FileUpload) As Boolean
        Using reader As New StreamReader(fileToUpload.FileContent)
            Dim firstLine As String = reader.ReadLine()
            Dim referenceNumberOfColumns As Integer = Split(firstLine, ";").Length
            Dim currentLine As String = reader.ReadLine()

            'While there is are lines in file, do the checking on columns
            While currentLine IsNot Nothing

                If currentLine.Split(";").Length <> referenceNumberOfColumns Then
                    Return False
                End If
                currentLine = reader.ReadLine()
            End While
        End Using
        Return True
    End Function
End Class