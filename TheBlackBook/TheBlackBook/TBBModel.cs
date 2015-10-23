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
        /// Function to subscribe and unscribe  property changed events
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
}
