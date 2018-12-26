Imports System.Windows.Controls
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpf.Editors.Helpers

Namespace LookUpEditFilterExample.Views
    Partial Public Class MainView
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub SubstituteDisplayFilter(sender As Object, e As SubstituteDisplayFilterEventArgs)
            If String.IsNullOrEmpty(e.DisplayText) Then Return
            Dim extraFilter = CriteriaOperator.Parse("Contains(Value,?)", e.DisplayText)
            e.DisplayFilter = New GroupOperator(GroupOperatorType.[Or], extraFilter, e.DisplayFilter)
            e.Handled = True
        End Sub
    End Class
End Namespace