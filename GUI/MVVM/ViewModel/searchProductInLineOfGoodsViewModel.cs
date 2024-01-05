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
    public class searchProductInLineOfGoodsViewModel : ViewModelBase
    {

        public IeditLineOfGoods _editLineOfGoodsService { get; set; }

        public searchProductInLineOfGoodsViewModel(IeditLineOfGoods editLineOfGoodsService, IWindowManager windowManager, ViewModelLocator viewModelLocator)
        {
            _editLineOfGoodsService = editLineOfGoodsService;

            DoFiltering();

            DeleteCommand = new DelegateCommand( execute: (o) =>
            {
                if (SelectedProduct != null)
                    editLineOfGoodsService.DeleteProduct(SelectedProduct);

                DoFiltering();
            }, canExecute: (o) => SelectedProduct != null);

            EditCommand = new DelegateCommand(execute: (o) =>
            {
               editLineOfGoodsService.toEditProduct = _editLineOfGoodsService.toEditProduct;

                windowManager.CloseWindow(viewModelLocator.SearchProductInLineOfGoodsViewModel); 

                var test = viewModelLocator.editProductInLineOfGoodsViewModel;

                test.ProductEdited += (o, e) => DoFiltering();

                Window window = windowManager.ShowWindow(viewModelLocator.editProductInLineOfGoodsViewModel);

                window.Closed += (o, e) =>
                {
                    test.ProductEdited -= (o, e) => DoFiltering();
                };

                ProductEditedEvent?.Invoke(this, EventArgs.Empty);
            }, canExecute: (o) => SelectedProduct != null);

            AddCommand = new DelegateCommand(execute: (o) =>
            {
                editLineOfGoodsService.toEditProduct = _editLineOfGoodsService.toEditProduct;

                var test = viewModelLocator.addProductToLineOfGoodsViewModel;

                test.ProductAdded += (o,e ) => DoFiltering();

                Window window = windowManager.ShowWindow(viewModelLocator.addProductToLineOfGoodsViewModel);

                window.Closed += (o, e) =>
                {
                    test.ProductAdded -= (o, e) => DoFiltering();
                };
                
                windowManager.CloseWindow(viewModelLocator.SearchProductInLineOfGoodsViewModel);
            });

            CloseCommand = new DelegateCommand(execute: (o) =>
            {
                windowManager.CloseWindow(viewModelLocator.SearchProductInLineOfGoodsViewModel);
            });

        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (value != SelectedProduct)
                {
                    selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                    _editLineOfGoodsService.toEditProduct = SelectedProduct;
                }
            }
        }

        private ObservableCollection<Product> lineOfGoods;

        public ObservableCollection<Product> LineOfGoods
        {
            get { return lineOfGoods; }
            set
            {
                if (value != null)
                    lineOfGoods = value;
                OnPropertyChanged(nameof(LineOfGoods));
            }
        }

        private ObservableCollection<Product> filteredLineOfGoods = new ObservableCollection<Product>();

        public ObservableCollection<Product> FilteredLineOfGoods
        {
            get { return filteredLineOfGoods; }
            set
            {
                if (filteredLineOfGoods != value)
                {
                    filteredLineOfGoods = value;
                    OnPropertyChanged(nameof(FilteredLineOfGoods));
                }
            }
        }

        private string filter = "";

        public string Filter
        {
            get => filter;
            set
            {
                if (value != filter)
                {
                    filter = value;
                    this.OnPropertyChanged(nameof(Filter));
                    this.OnPropertyChanged(nameof(FilteredLineOfGoods));
                    DoFiltering();
                }
            }
        }

        private void DoFiltering()
        {
            LineOfGoods = new ObservableCollection<Product>(_editLineOfGoodsService.LineOfGoods.lineOfGoods);
            this.FilteredLineOfGoods.Clear();
            string? value = this.filter?.ToLower();
            foreach (Product item in LineOfGoods)
            {
                if (String.IsNullOrEmpty(Filter) ||
                   item.Name.ToLower().Contains(value) ||
                   item.Articlenumber.ToString().Contains(value))
                {
                    this.FilteredLineOfGoods.Add(item);
                }
            }
        }

        //Um neue ausgewählte produkte direkt anzuzeigen

        public event EventHandler ProductEditedEvent;

        public DelegateCommand DeleteCommand { get; set; }

        public DelegateCommand EditCommand { get; set; }

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
