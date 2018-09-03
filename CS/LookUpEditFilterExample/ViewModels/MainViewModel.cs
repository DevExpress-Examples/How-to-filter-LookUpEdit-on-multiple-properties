using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.ObjectModel;

namespace LookUpEditFilterExample.ViewModels {
    [POCOViewModel]
    public class MainViewModel {
        protected MainViewModel() {
            Data = new ObservableCollection<Data>();
            Random r = new Random();
            for (int i = 0; i < 25; i++)
                Data.Add(new Data() { ID = i, Name = "Name " + i, Value = r.Next(0, 25) });
        }

        public virtual ObservableCollection<Data> Data { get; set; }
    }

    public class Data {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}