## How to filter LookUpEdit on multiple properties

In versions **18.2.3** and newer, you can do this by handling the built-in [SubstituteDisplayFilter](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.LookUpEditBase.SubstituteDisplayFilter) event.

For example:
```CS
private void SubstituteDisplayFilter(object sender, SubstituteDisplayFilterEventArgs e) {
    if (string.IsNullOrEmpty(e.DisplayText))
        return;
    var extraFilter = CriteriaOperator.Parse("Contains(Value,?)", e.DisplayText);
    e.DisplayFilter = new GroupOperator(GroupOperatorType.Or, extraFilter, e.DisplayFilter);
    e.Handled = true;
}
```
```VB
Private Sub SubstituteDisplayFilter(sender As Object, e As SubstituteDisplayFilterEventArgs)
    If String.IsNullOrEmpty(e.DisplayText) Then Return
    Dim extraFilter = CriteriaOperator.Parse("Contains(Value,?)", e.DisplayText)
    e.DisplayFilter = New GroupOperator(GroupOperatorType.[Or], extraFilter, e.DisplayFilter)
    e.Handled = True
End Sub
```

See also:
- [Criteria Operators](https://docs.devexpress.com/CoreLibraries/2129/devexpress-data-library/criteria-operators)
- [Criteria Language Syntax](https://docs.devexpress.com/CoreLibraries/4928/devexpress-data-library/criteria-language-syntax)