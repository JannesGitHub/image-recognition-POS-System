using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel
{
    internal class addManuallyViewModel
    {
        public addManuallyViewModel()
        {
            SelectedProduct = new Product("Banane", 23, 2.2, true, null);

            this.AddCommand = new DelegateCommand((o) => { this.Add?.Invoke(this, EventArgs.Empty); });
        }

        public Product SelectedProduct { get; set; }

        public DelegateCommand AddCommand { get; set; }

        public event EventHandler Add;
    }
}
