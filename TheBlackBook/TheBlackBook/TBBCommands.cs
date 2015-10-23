using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TheBlackBook
{
    public class TBBCommands
    {
        private ICommand _addtTBBModelCommand;
        public ICommand AddTbbModelCommand => _addtTBBModelCommand ?? (_addtTBBModelCommand = new RelayCommand<ObservableCollection<TBBModel>>(
            collection =>
            {
                collection.Add(new TBBModel());
            }));

        private ICommand _addTbbTransactionCommand;
        public  ICommand AddTbbTransactionCommand => _addTbbTransactionCommand ?? (_addTbbTransactionCommand = new RelayCommand<ListView>(
            list =>
            {
                ((list.ItemsSource) as ObservableCollection<TBBModel>)?[list.SelectedIndex]?.Transaction.Add(new TBBTransaction());
            }));

        private ICommand _deleteTbbModelCommand;
        public ICommand DeleteTbbModelCommand => _deleteTbbModelCommand ?? (_deleteTbbModelCommand = new RelayCommand<object[]>(
            objects =>
            {
                (objects[0] as TBBModelCollection)?.Remove(objects[1] as TBBModel);
            }));
    }
}