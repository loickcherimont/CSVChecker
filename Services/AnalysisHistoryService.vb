Public Class AnalysisHistoryService
    Public Property Repository As AnalysisHistoryRepository

    Public Sub New(ByVal Repository As AnalysisHistoryRepository)
        Me.Repository = Repository
    End Sub

    Public Function GetAll() As List(Of AnalysisHistory)
        Return Repository.FindAll()
    End Function

    Public Function Create(ByVal createAnalysisHistoryDTO As CreateAnalysisRequestDTO) As AnalysisHistory
        Dim newAnalysisHistory As New AnalysisHistory(
            createAnalysisHistoryDTO.Filename,
            createAnalysisHistoryDTO.AnalysisDate,
            createAnalysisHistoryDTO.Status,
            createAnalysisHistoryDTO.Details
        )
        Return Repository.Save(newAnalysisHistory)
    End Function
End Class
