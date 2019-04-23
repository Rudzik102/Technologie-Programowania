using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdventureWorks;
using Warehouse.Models;
using Warehouse.View;

namespace Warehouse.ViewModels
{
    public class MasterViewModel
    {
        private ObservableCollection<MyProduct> _products = new ObservableCollection<MyProduct>();
        public int SelectedIndex { get; set; }
        private DataRepository rep;

        public MasterViewModel()
        {
            rep = new DataRepository();
            rep.Refresh(ref _products);
            

            AddItemCommand = new MasterAddItemCommand(this);
            RemoveItemCommand = new MasterRemoveItemCommand(this);
            PreviewItemCommand = new MasterPreviewItemCommand(this);
            RefreshCommand = new MasterRefreshCommand(this);
        }

        public ObservableCollection<MyProduct> MyProducts
        {
            get { return _products; }
            set { _products = value; }
        }

        public ICommand AddItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public ICommand PreviewItemCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public void AddItem()
        {
            Detail detailWindow = new Detail();
            detailWindow.DataContext = new DetailViewModel(new MyProduct(), ref detailWindow, true);
            detailWindow.ShowDialog();
        }

        public void PreviewItem()
        {
            Detail detailWindow = new Detail();
            detailWindow.DataContext = new DetailViewModel(_products[SelectedIndex], ref detailWindow, false);
            detailWindow.ShowDialog();
        }

        public void RemoveItem()
        {
            rep.Remove(_products[SelectedIndex].ProductID);
            _products.Remove(_products[SelectedIndex]);
        }

        public void RefreshList()
        {
           rep.Refresh(ref _products);
        }
    }
}
