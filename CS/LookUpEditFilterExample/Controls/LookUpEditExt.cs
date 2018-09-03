using DevExpress.Data.Filtering;
using DevExpress.Xpf.Editors.Helpers;
using DevExpress.Xpf.Grid.LookUp;
using System.Linq;
using System.Reflection;

namespace LookUpEditFilterExample.Controls {
    public class LookUpEditExt : LookUpEdit {
        static LookUpEditExt() {
            LookUpEditExtSettings.RegisterCustomEdit();
        }
        public LookUpEditExt() { }
    }

    public class LookUpEditExtSettings : LookUpEditSettings {
        static LookUpEditExtSettings() {
            RegisterCustomEdit();
        }

        protected override IItemsProvider2 CreateItemsProvider() {
            return new ItemsProvider2Ext(this);
        }

        public static void RegisterCustomEdit() {
            EditorSettingsProvider.Default.RegisterUserEditor(typeof(LookUpEditExt), typeof(LookUpEditExtSettings), () => new LookUpEditExt(), () => new LookUpEditExtSettings());
        }
    }

    public class ItemsProvider2Ext : ItemsProvider2, IItemsProvider2 {
        public ItemsProvider2Ext(IItemsProviderOwner owner) : base(owner) { }

        CriteriaOperator IItemsProvider2.CreateDisplayFilterCriteria(string searchText, FilterCondition filterCondition) {
            if (string.IsNullOrEmpty(searchText))
                return null;
            FunctionOperatorType functionOperatorType = GetFunctionOperatorType(filterCondition);
            var filter = new GroupOperator(GroupOperatorType.Or);
            foreach (PropertyInfo pi in ((DevExpress.Data.IListWrapper)DataController.ListSource).WrappedListType.GetGenericArguments().Single().GetProperties())
                filter.Operands.Add(new FunctionOperator(functionOperatorType, new OperandProperty(pi.Name), searchText));
            return filter;
        }
    }
}
