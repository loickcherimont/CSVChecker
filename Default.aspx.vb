Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Data.SqlClient

Public Class _Default
    Inherits Page

    Private AnalysisHistoryS As AnalysisHistoryService
    Private AnalysisHistoryR As AnalysisHistoryRepository
    Private AnalysisS As AnalysisService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            updateTableHistory()
        End If
    End Sub

    Protected Sub AnalyzeBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        ErrorMessage.Text = String.Empty
        ErrorMessage.Visible = False
        SuccessMessage.Visible = False

        'Get the file from frontend / client
        AnalysisHistoryR = New AnalysisHistoryRepository()
        AnalysisHistoryS = New AnalysisHistoryService(AnalysisHistoryR)
        AnalysisS = New AnalysisService(AnalysisHistoryS)
        Dim newAnalysis As AnalysisHistory


        Try
            AnalysisS.VerifyIfFileProvided(CsvFileUpload)
            AnalysisS.VerifyIfFileIsCsv(CsvFileUpload)
            AnalysisS.VerifyIfCsvIsNotEmpty(CsvFileUpload)
            AnalysisS.VerifyIfCsvContainsTheExpectedHeader(CsvFileUpload)
            AnalysisS.VerifyIfCsvHasCorrectNumberOfColumns(CsvFileUpload)
        Catch ex As ArgumentException
            ErrorMessage.Text = ex.Message
            ErrorMessage.Visible = True
            updateTableHistory()
            Return
        End Try

        newAnalysis = AnalysisHistoryR.Save(
                New AnalysisHistory(CsvFileUpload.FileName, DateTime.Now, AnalysisStatus.COMPLIANT, "CSV analysé avec succès")
            )
        SuccessMessage.Text = newAnalysis.Details
        SuccessMessage.Visible = True
        updateTableHistory()
    End Sub

    Protected Sub updateTableHistory()
        AnalysisHistoryR = New AnalysisHistoryRepository()
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