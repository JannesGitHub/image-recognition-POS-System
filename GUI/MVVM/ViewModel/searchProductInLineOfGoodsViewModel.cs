using GUI.Core;
using GUI.Services;
using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            LineOfGoods = new ObservableCollection<Product>(editLineOfGoodsService.LineOfGoods.lineOfGoods);

            DoFiltering();

            DeleteCommand = new DelegateCommand((o) =>
            {
                if(SelectedProduct != null)
                editLineOfGoodsService.DeleteProduct(SelectedProduct);
                LineOfGoods = new ObservableCollection<Product>(editLineOfGoodsService.LineOfGoods.lineOfGoods);
                DoFiltering();
            });

            EditCommand = new DelegateCommand((o) =>
            {
                
            });
        }

        public Product SelectedProduct { get; set; }

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

        public DelegateCommand DeleteCommand { get; set; }

        public DelegateCommand EditCommand { get; set; }
    }
}
