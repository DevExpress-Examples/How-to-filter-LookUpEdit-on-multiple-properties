Imports DevExpress.Mvvm.DataAnnotations
Imports System
Imports System.Collections.ObjectModel

Namespace LookUpEditFilterExample.ViewModels
    <POCOViewModel> _
    Public Class MainViewModel
        Protected Sub New()
            Data = New ObservableCollection(Of Data)()
            Dim r As New Random()
            For i As Integer = 0 To 24
                Data.Add(New Data() With { _
                    .ID = i, _
                    .Name = "Name " & i, _
                    .Value = r.Next(0, 25) _
                })
            Next i
        End Sub

        Public Overridable Property Data() As ObservableCollection(Of Data)
    End Class

    Public Class Data
        Public Property ID() As Integer
        Public Property Name() As String
        Public Property Value() As Integer
    End Class
End Namespace