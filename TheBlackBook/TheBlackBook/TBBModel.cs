using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheBlackBook.Annotations;

namespace TheBlackBook
{
    public class TBBModelCollection : ObservableCollection<TBBModel>
    {
        public TBBModelCollection()
        {
            var locVar = new TBBModel("Alex");
            locVar.Transaction.Add(new TBBTransaction(DateTime.Now, 100));
            Add(locVar);

            var locVar1 = new TBBModel("Jeba");
            locVar1.Transaction.Add(new TBBTransaction(DateTime.Now.AddHours(-4), -75));
            Add(locVar1);
        }
    }
    public class TBBModel : INotifyPropertyChanged
    {
        public TBBModel()
        {
            Name = "Name";
            Transaction = new ObservableCollection<TBBTransaction>();
            Transaction.Add(new TBBTransaction());
            Transaction.CollectionChanged += delegate { OnPropertyChanged(nameof(Transaction)); };
        }

        public TBBModel(string name)
        {
            Name = name;
            Transaction = new ObservableCollection<TBBTransaction>();
            Transaction.CollectionChanged += delegate {OnPropertyChanged(nameof(Transaction)); };
        }
        public string Name { get; set; }
        public ObservableCollection<TBBTransaction> Transaction { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TBBTransaction
    {
        public TBBTransaction()
        {
            TBBDateTime = DateTime.Now;
            Transfer = 0;
        }
        public TBBTransaction(DateTime date, double transferAmout )
        {
            TBBDateTime = date;
            Transfer = transferAmout;
        }
        public DateTime TBBDateTime { get; set; }
        public double Transfer { get; set; }
    }
}
