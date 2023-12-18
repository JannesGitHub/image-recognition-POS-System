using GUI.Core;
using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Services;
using System.Drawing.Printing;

namespace GUI.MVVM.ViewModel
{
    public class addManuallyViewModel : ViewModelBase
    {
        public IaddManuallyService _addManuallyService { get; set; }

        public addManuallyViewModel(IaddManuallyService addManuallyService)
        {
            this.products.CollectionChanged += (s, e) =>
            {
                DoFiltering();
            };

            _addManuallyService = addManuallyService;

            products = new ObservableCollection<Product>(_addManuallyService.lineOfGoods.lineOfGoods);    

            DoFiltering(); //Damit das Sortiment sofort angezeigt wird

            this.AddCommand = new DelegateCommand((o) => { 
                    if(SelectedProduct != null)
                    addManuallyService.AddArticleManually(SelectedProduct);});
        }

        private ObservableCollection<Product> products { get; set; } = new ObservableCollection<Product> ();

        public ObservableCollection<Product> FilteredProducts { get; set; } = new ObservableCollection<Product>();


        private string filter = "";

        public string Filter
        {get => filter;
            set
            {
                if(value != filter)
                {
                    filter = value;
                    this.OnPropertyChanged(nameof(Filter));
                    DoFiltering();
                }
            }
        }

        private void DoFiltering()
        {
            this.FilteredProducts.Clear();
            string? value = this.filter?.ToLower();
            foreach(var item in products)
            {
                if(String.IsNullOrEmpty(Filter) ||
                   item.Name.ToLower().Contains(value) ||
                   item.Articlenumber.ToString().Contains(value)){
                    this.FilteredProducts.Add(item);
                }
            }
        }

        public Product SelectedProduct { get; set; }

        public DelegateCommand AddCommand { get; set; }
    }
}
