using System;
using System.Collections.ObjectModel;

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
}