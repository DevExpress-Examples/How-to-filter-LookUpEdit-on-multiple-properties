Imports DevExpress.Data.Filtering
Imports DevExpress.Xpf.Editors.Helpers
Imports DevExpress.Xpf.Grid.LookUp
Imports System.Linq
Imports System.Reflection

Namespace LookUpEditFilterExample.Controls
    Public Class LookUpEditExt
        Inherits LookUpEdit

        Shared Sub New()
            LookUpEditExtSettings.RegisterCustomEdit()
        End Sub
        Public Sub New()
        End Sub
    End Class

    Public Class LookUpEditExtSettings
        Inherits LookUpEditSettings

        Shared Sub New()
            RegisterCustomEdit()
        End Sub

        Protected Overrides Function CreateItemsProvider() As IItemsProvider2
            Return New ItemsProvider2Ext(Me)
        End Function

        Public Shared Sub RegisterCustomEdit()
            EditorSettingsProvider.Default.RegisterUserEditor(GetType(LookUpEditExt), GetType(LookUpEditExtSettings), Function() New LookUpEditExt(), Function() New LookUpEditExtSettings())
        End Sub
    End Class

    Public Class ItemsProvider2Ext
        Inherits ItemsProvider2
        Implements IItemsProvider2

        Public Sub New(ByVal owner As IItemsProviderOwner)
            MyBase.New(owner)
        End Sub

        Private Function IItemsProvider2_CreateDisplayFilterCriteria(ByVal searchText As String, ByVal filterCondition As FilterCondition) As CriteriaOperator Implements IItemsProvider2.CreateDisplayFilterCriteria
            If String.IsNullOrEmpty(searchText) Then
                Return Nothing
            End If
            Dim functionOperatorType As FunctionOperatorType = GetFunctionOperatorType(filterCondition)
            Dim filter = New GroupOperator(GroupOperatorType.Or)
            For Each pi As PropertyInfo In DirectCast(DataController.ListSource, DevExpress.Data.IListWrapper).WrappedListType.GetGenericArguments().Single().GetProperties()
                filter.Operands.Add(New FunctionOperator(functionOperatorType, New OperandProperty(pi.Name), searchText))
            Next pi
            Return filter
        End Function
    End Class
End Namespace
