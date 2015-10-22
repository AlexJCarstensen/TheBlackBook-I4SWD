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
        public TBBModel(string name = "Name")
        {
            Name = name;
            Transaction = new ObservableCollection<TBBTransaction>();
            // To update on TBBTransaction change
            Transaction.CollectionChanged += ContentCollectionChanged;
            // To update on TBBTransaction add
            Transaction.CollectionChanged += delegate { OnPropertyChanged(nameof(Transaction)); };
        }

        /// <summary>
        /// Function to subscribe and unscribe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (TBBTransaction item in e.OldItems)
                {
                    //Removed items
                    // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
                    item.PropertyChanged -= delegate { OnPropertyChanged(nameof(Transaction)); };
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (TBBTransaction item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += delegate { OnPropertyChanged(nameof(Transaction)); };
                }
            }
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

    public class TBBTransaction : INotifyPropertyChanged
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

        private DateTime _tBBDateTime;
        public DateTime TBBDateTime { get { return _tBBDateTime; } set { _tBBDateTime = value; OnPropertyChanged(); } }
        private double _transfer;
        public double Transfer { get { return _transfer; } set { _transfer = value; OnPropertyChanged(); } }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
