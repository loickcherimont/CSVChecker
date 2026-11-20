Public Enum AnalysisStatus
    COMPLIANT
    NOT_COMPLIANT
End Enum

Public Class AnalysisHistory
    Public Property Id As Integer
    Public Property FileName As String
    Public Property AnalysisDate As DateTime

    Public Property Status As AnalysisStatus

    Public Property Details As String

    Public Sub New(Id As Integer,
               FileName As String,
               AnalysisDate As DateTime,
               Status As AnalysisStatus,
               Details As String)

        Me.Id = Id
        Me.FileName = FileName
        Me.AnalysisDate = AnalysisDate
        Me.Status = Status
        Me.Details = Details

    End Sub

    Public Sub New(
           FileName As String,
           AnalysisDate As DateTime,
           Status As AnalysisStatus,
           Details As String)
        Me.FileName = FileName
        Me.AnalysisDate = AnalysisDate
        Me.Status = Status
        Me.Details = Details

    End Sub
End Class
