using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TheBlackBook.Annotations;

namespace TheBlackBook
{
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