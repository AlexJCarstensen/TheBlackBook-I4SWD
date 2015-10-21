using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackBook
{
    public class TBBModelCollection : ObservableCollection<TBBModel>
    {
        public TBBModelCollection()
        {
            Add(new TBBModel("Alex", 100));
        }
    }
    public class TBBModel
    {
        public TBBModel() { }

        public TBBModel(string name, double owe)
        {
            Name = name;
            Owe = owe;
        }
        public string Name { get; set; }
        public double Owe { get; set; }
    }
}
