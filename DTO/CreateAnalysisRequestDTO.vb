Public Class CreateAnalysisRequestDTO
    Public Property Filename As String
    Public Property AnalysisDate As DateTime
    Public Property Status As AnalysisStatus
    Public Property Details As String

    Public Sub New(ByVal Filename As String,
                   ByVal AnalysisDate As DateTime,
                   ByVal Status As AnalysisStatus,
                   ByVal Details As String)

        Me.Filename = Filename
        Me.AnalysisDate = AnalysisDate
        Me.Status = Status
        Me.Details = Details

    End Sub
End Class
