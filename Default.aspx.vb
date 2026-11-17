Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub AnalyzeBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Not CsvFileUpload.HasFile Then
            UploadedFileMessage.Text = "Please provide a file."
            Return
        End If

        If isNotCsvFile(CsvFileUpload) Then
            UploadedFileMessage.Text = "Only CSV file are allowed."
            Return
        End If

        If isCsvFileEmpty(CsvFileUpload) Then
            UploadedFileMessage.Text = "CSV file cannot be empty."
            Return
        End If

        UploadedFileMessage.Text = "File uploaded with success"

        'TODO: Implement business for complex validity of a CSV file
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
End Class