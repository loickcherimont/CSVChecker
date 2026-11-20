Imports System.IO

Public Class AnalysisService

    Private EXPECTED_HEADER() As String = {"Identifiant", "Equipement", "NumeroSerie", "Proprietaire", "DateAcquisition"}

    Private AnalysisHistoryS As AnalysisHistoryService

    Public Sub New(ByVal AnalysisHistoryS As AnalysisHistoryService)
        Me.AnalysisHistoryS = AnalysisHistoryS
    End Sub

    Public Sub VerifyIfFileProvided(ByVal file As FileUpload)
        If Not file.HasFile Then
            Dim createRequest As New CreateAnalysisRequestDTO(file.FileName, DateTime.Now, AnalysisStatus.NOT_COMPLIANT, "Aucun fichier n'a été fourni.")
            AnalysisHistoryS.Create(createRequest)
            Throw New ArgumentException(createRequest.Details)
        End If
    End Sub

    Public Sub VerifyIfFileIsCsv(ByVal file As FileUpload)
        Dim extension As String = System.IO.Path.GetExtension(file.FileName)
        Dim ALLOWED_EXTENSION As String = ".csv"
        If Not String.Equals(extension, ALLOWED_EXTENSION, StringComparison.OrdinalIgnoreCase) Then
            Dim createRequest As New CreateAnalysisRequestDTO(file.FileName, DateTime.Now, AnalysisStatus.NOT_COMPLIANT, "Le fichier fourni n'est pas un CSV.")
            AnalysisHistoryS.Create(createRequest)
            Throw New ArgumentException(createRequest.Details)
        End If
    End Sub

    Public Sub VerifyIfCsvIsNotEmpty(ByVal file As FileUpload)
        Dim fileSize As Long = file.PostedFile.ContentLength
        If fileSize = 0 Then
            Dim createRequest As New CreateAnalysisRequestDTO(file.FileName, DateTime.Now, AnalysisStatus.NOT_COMPLIANT, "Le CSV fourni est vide")
            AnalysisHistoryS.Create(createRequest)
            Throw New ArgumentException(createRequest.Details)
        End If
    End Sub
    Public Sub VerifyIfCsvContainsTheExpectedHeader(ByVal file As FileUpload)
        Using reader As New StreamReader(file.FileContent)
            Dim firstLine As String = reader.ReadLine()
            Dim fileTitles() As String = Split(firstLine, ";")

            'Avoid comparison and out of the bound exception if filesTitles and EXPECTED_HEADER have different length
            If fileTitles.Length <> EXPECTED_HEADER.Length Then
                Dim createRequest As New CreateAnalysisRequestDTO(file.FileName, DateTime.Now, AnalysisStatus.NOT_COMPLIANT, "Le CSV fourni ne contient pas l'en-tête attendue de la documentation.")
                AnalysisHistoryS.Create(createRequest)
                Throw New ArgumentException(createRequest.Details)
            End If

            For i = 0 To fileTitles.Length - 1
                If fileTitles(i) <> EXPECTED_HEADER(i) Then
                    Dim createRequest As New CreateAnalysisRequestDTO(file.FileName, DateTime.Now, AnalysisStatus.NOT_COMPLIANT, "Le CSV fourni ne contient pas l'en-tête attendue de la documentation.")
                    AnalysisHistoryS.Create(createRequest)
                    Throw New ArgumentException(createRequest.Details)
                End If
            Next
        End Using
    End Sub

    Public Sub VerifyIfCsvHasCorrectNumberOfColumns(ByVal file As FileUpload)

        Using reader As New StreamReader(file.FileContent)
            Dim firstLine As String = reader.ReadLine()
            Dim referenceNumberOfColumns As Integer = Split(firstLine, ";").Length
            Dim currentLine As String = reader.ReadLine()

            'While there is are lines in file, do the checking on columns
            While currentLine IsNot Nothing

                If currentLine.Split(";").Length <> referenceNumberOfColumns Then
                    Dim createRequest As New CreateAnalysisRequestDTO(file.FileName, DateTime.Now, AnalysisStatus.NOT_COMPLIANT, "Le nombre de colonne du CSV n'est pas cohérent.")
                    AnalysisHistoryS.Create(createRequest)
                    Throw New ArgumentException(createRequest.Details)
                End If
                currentLine = reader.ReadLine()
            End While
        End Using
    End Sub

End Class
