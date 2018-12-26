using DevExpress.Data.Filtering;
using DevExpress.Xpf.Editors.Helpers;
using System.Windows.Controls;

namespace LookUpEditFilterExample.Views {
    public partial class MainView : UserControl {
        public MainView() {
            InitializeComponent();
        }
        private void SubstituteDisplayFilter(object sender, SubstituteDisplayFilterEventArgs e) {
            if (string.IsNullOrEmpty(e.DisplayText))
                return;
            var extraFilter = CriteriaOperator.Parse("Contains(Value,?)", e.DisplayText);
            e.DisplayFilter = new GroupOperator(GroupOperatorType.Or, extraFilter, e.DisplayFilter);
            e.Handled = true;
        }
    }
}