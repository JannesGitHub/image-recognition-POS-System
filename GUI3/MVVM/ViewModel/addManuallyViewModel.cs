using GUI.Core;
using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel
{
    internal class addManuallyViewModel : ViewModelBase
    {
        public addManuallyViewModel()
        {
            SelectedProduct = new Product("Banane", 23, 2.2, true, null);

            this.AddCommand = new DelegateCommand((o) => { this.Add?.Invoke(this, EventArgs.Empty); });
        }

        public ObservableCollection<KeyValuePair<double, Product>> productsAndProbabilitys { get; set; }

        public Product SelectedProduct { get; set; }

        public DelegateCommand AddCommand { get; set; }

        public event EventHandler Add;
    }
}
