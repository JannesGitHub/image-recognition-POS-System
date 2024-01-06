using GUI.Core;
using GUI.Services;
using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace GUI.MVVM.ViewModel
{
    public class SearchProductInLineOfGoodsVM : ViewModelBase
    {

        public SearchProductInLineOfGoodsVM(IEditLineOfGoods editLineOfGoodsService, IWindowManager windowManager, ViewModelLocator viewModelLocator)
        {
            DoFiltering();

            DeleteCommand = new DelegateCommand(execute: (o) =>
            {
                if (SelectedProduct != null)
                    editLineOfGoodsService.DeleteProduct(SelectedProduct);

                DoFiltering();
            }, canExecute: (o) => SelectedProduct != null);

            EditCommand = new DelegateCommand(execute: (o) =>
            {
                windowManager.CloseWindow(viewModelLocator.SearchProductInLineOfGoodsVM);

                EditProductInLineOfGoodsVM editVM = viewModelLocator.EditProductInLineOfGoodsVM;

                Window window = windowManager.ShowWindow(viewModelLocator.EditProductInLineOfGoodsVM);

                editVM.ProductEditedEvent += (o, e) => DoFiltering();

                window.Closed += (o, e) =>
                {
                    editVM.ProductEditedEvent -= (o, e) => DoFiltering();
                };

                ProductEditedEvent?.Invoke(this, EventArgs.Empty);

            }, canExecute: (o) => SelectedProduct != null);

            AddCommand = new DelegateCommand(execute: (o) =>
            {
                AddProductToLineOfGoodsVM addVM = viewModelLocator.AddProductToLineOfGoodsVM;

                Window window = windowManager.ShowWindow(viewModelLocator.AddProductToLineOfGoodsVM);

                addVM.ProductAddedEvent += (o, e) => DoFiltering();

                window.Closed += (o, e) =>
                {
                    addVM.ProductAddedEvent -= (o, e) => DoFiltering();
                };

                windowManager.CloseWindow(viewModelLocator.SearchProductInLineOfGoodsVM);
            });

            CloseCommand = new DelegateCommand(execute: (o) => { windowManager.CloseWindow(viewModelLocator.SearchProductInLineOfGoodsVM); });
        }


        ////////////////////////////////////////ATTRIBUTES////////////////////////////////////////

        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (value != SelectedProduct)
                {
                    _selectedProduct = value;
                    EditLineOfGoodsService.SelectedProduct = this.SelectedProduct;
                }
            }
        }

        public ObservableCollection<Product> LineOfGoods { get; set; } 

        public ObservableCollection<Product> FilteredLineOfGoods { get; set; } = new ObservableCollection<Product>();

        private string filter = "";

        public string Filter
        {
            get => filter;
            set
            {
                if (value != filter)
                {
                    filter = value;
                    DoFiltering();
                }
            }
        }

        private void DoFiltering()
        {
            LineOfGoods = new ObservableCollection<Product>(EditLineOfGoodsService.LineOfGoods.lineOfGoods);
            FilteredLineOfGoods.Clear();
            string value = Filter.ToLower();
            foreach (Product item in LineOfGoods)
            {
                if (String.IsNullOrEmpty(Filter) ||
                   item.Name.ToLower().Contains(value) ||
                   item.Articlenumber.ToString().Contains(value))
                {
                    FilteredLineOfGoods.Add(item);
                }
            }
        }

        public event EventHandler ProductEditedEvent = delegate{}; //Um neue ausgewählte produkte direkt anzuzeigen

        ////////////////////////////////////////COMMANDS////////////////////////////////////////

        public DelegateCommand DeleteCommand { get; set; }

        public DelegateCommand EditCommand { get; set; }

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
