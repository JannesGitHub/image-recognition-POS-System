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

namespace GUI.MVVM.ViewModel
{
    public class addManuallyViewModel : ViewModelBase
    {
        public IaddManuallyService _addManuallyService { get; set; }

        public addManuallyViewModel(IaddManuallyService addManuallyService)
        {
            _addManuallyService = addManuallyService;

            products = new ObservableCollection<Product>(LineOfGoods.getdummi().lineOfGoods);

            this.AddCommand = new DelegateCommand((o) => { 
                    if(SelectedProduct != null)
                    addManuallyService.AddArticleManually(SelectedProduct);});
        }

        public ObservableCollection<Product> products { get; set; }



        public Product SelectedProduct { get; set; }

        public DelegateCommand AddCommand { get; set; }
    }
}
