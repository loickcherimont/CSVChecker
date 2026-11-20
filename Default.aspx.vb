Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Data.SqlClient

Public Class _Default
    Inherits Page

    Private EXPECTED_HEADER() As String = {"Identifiant", "Equipement", "NumeroSerie", "Proprietaire", "DateAcquisition"}
    Private AnalysisHistoryR As AnalysisHistoryRepository

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            AnalysisHistoryR = New AnalysisHistoryRepository()
            updateTableHistory()
        End If
    End Sub

    Protected Sub AnalyzeBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        AnalysisHistoryR = New AnalysisHistoryRepository()
        Dim newAnalysis As AnalysisHistory
        ErrorMessage.Text = String.Empty
        ErrorMessage.Visible = False
        SuccessMessage.Visible = False

        If Not CsvFileUpload.HasFile Then
            newAnalysis = AnalysisHistoryR.Save(
                New AnalysisHistory(CsvFileUpload.FileName, DateTime.Now, AnalysisStatus.NOT_COMPLIANT, "Aucun fichier n'est fourni")
            )
            ErrorMessage.Text = newAnalysis.Details
            ErrorMessage.Visible = True
            updateTableHistory()
            Return
        End If

        If isNotCsvFile(CsvFileUpload) Then
            newAnalysis = AnalysisHistoryR.Save(
                New AnalysisHistory(CsvFileUpload.FileName, DateTime.Now, AnalysisStatus.NOT_COMPLIANT, "Type de fichier non autorisé")
            )
            ErrorMessage.Text = newAnalysis.Details
            ErrorMessage.Visible = True
            updateTableHistory()
            Return
        End If

        If isCsvFileEmpty(CsvFileUpload) Then
            newAnalysis = AnalysisHistoryR.Save(
                New AnalysisHistory(CsvFileUpload.FileName, DateTime.Now, AnalysisStatus.NOT_COMPLIANT, "CSV fourni est vide")
            )
            ErrorMessage.Text = newAnalysis.Details
            ErrorMessage.Visible = True
            updateTableHistory()
            Return
        End If

        If Not containsTheExpectedHeader(CsvFileUpload) Then
            newAnalysis = AnalysisHistoryR.Save(
                New AnalysisHistory(CsvFileUpload.FileName, DateTime.Now, AnalysisStatus.NOT_COMPLIANT, "Fichier ne contient pas l'en-tête attendue")
            )
            ErrorMessage.Text = newAnalysis.Details
            ErrorMessage.Visible = True
            updateTableHistory()
            Return
        End If

        If Not isOkForNumberOfColumns(CsvFileUpload) Then
            newAnalysis = AnalysisHistoryR.Save(
                New AnalysisHistory(CsvFileUpload.FileName, DateTime.Now, AnalysisStatus.NOT_COMPLIANT, "Nombre de colonnes du fichier non conforme")
            )
            ErrorMessage.Text = newAnalysis.Details
            ErrorMessage.Visible = True
            updateTableHistory()
            Return
        End If

        newAnalysis = AnalysisHistoryR.Save(
                New AnalysisHistory(CsvFileUpload.FileName, DateTime.Now, AnalysisStatus.COMPLIANT, "CSV analysé avec succès")
            )
        SuccessMessage.Text = newAnalysis.Details
        SuccessMessage.Visible = True
        updateTableHistory()
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

    Protected Sub updateTableHistory()
        For Each analysisHistory In AnalysisHistoryR.FindAll()
            Dim row As New TableRow()

            Dim cellId As New TableCell()
            cellId.Text = analysisHistory.Id.ToString
            row.Cells.Add(cellId)

            Dim cellFileName As New TableCell()
            cellFileName.Text = analysisHistory.FileName
            row.Cells.Add(cellFileName)

            Dim cellAnalysisDate As New TableCell()
            cellAnalysisDate.Text = analysisHistory.AnalysisDate.ToString
            row.Cells.Add(cellAnalysisDate)

            Dim cellStatus As New TableCell()
            cellStatus.Text = analysisHistory.Status.ToString
            row.Cells.Add(cellStatus)

            Dim cellDetails As New TableCell()
            cellDetails.Text = analysisHistory.Details
            row.Cells.Add(cellDetails)

            TableHistory.Rows.Add(row)
        Next
    End Sub
End Class