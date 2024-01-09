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
using System.Xml;
using System.Collections;
using System.Windows.Controls;

namespace GUI.MVVM.ViewModel
{
    public class AddManuallyVM : ViewModelBase
    {
        public AddManuallyVM(IAddManuallyService addManuallyService, IWindowManager windowManager, ViewModelLocator viewModelLocator)
        {
            ScanData = addManuallyService.ScanData;

            this.AddCommand = new DelegateCommand(execute: (o) =>{ addManuallyService.AddArticleManually(SelectedProduct.Value);
                                                                      windowManager.CloseWindow(viewModelLocator.AddManuallyVM);},
                                                  canExecute: (o) => SelectedProduct.Value != null);

            CloseCommand = new DelegateCommand(execute: (o) => { windowManager.CloseWindow(viewModelLocator.AddManuallyVM); });
        }


        /////////////////////////////////////////////////////////ATTRIBUTES/////////////////////////////////////////////////////////////////

        private SortedDictionary<double, Product> _scanData = new SortedDictionary<double, Product>();
        public SortedDictionary<double, Product> ScanData
        {
            get { return _scanData; }
            set
            {
                if (_scanData != value)
                {
                    _scanData = value;
                    DoFiltering(); //Is needed to update the view when opend first time.
                }
            }
        }

        public ObservableCollection<KeyValuePair<double, Product>> FilteredScanData { get; set; } = new ObservableCollection<KeyValuePair<double, Product>>();

        private string _filter = "";

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (value != _filter)
                {
                    _filter = value;
                    DoFiltering();
                }
            }
        }

        private void DoFiltering()
        {
            FilteredScanData.Clear();

            string value = Filter.ToLower();

            foreach (KeyValuePair<double, Product> item in ScanData)
            {
                if (String.IsNullOrEmpty(Filter) ||
                   item.Value.Name.ToLower().Contains(value) ||
                   item.Value.Articlenumber.ToString().Contains(value))
                {
                    this.FilteredScanData.Add(new KeyValuePair<double, Product>(item.Key, item.Value));
                }
            }
        }

        public KeyValuePair<double, Product> SelectedProduct { get; set; } 

        /////////////////////////////////////////////////////////////COMMANDS//////////////////////////////////////////////////////////
        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
