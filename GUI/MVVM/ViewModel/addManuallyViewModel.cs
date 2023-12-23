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
    public class addManuallyViewModel : ViewModelBase
    {
        public IaddManuallyService _addManuallyService { get; set; }

        public addManuallyViewModel(IaddManuallyService addManuallyService, IWindowManager windowManager, ViewModelLocator viewModelLocator)
        {
            scanData = addManuallyService.scanData;

            DoFiltering(); //Damit das Sortiment sofort angezeigt wird

            this.AddCommand = new DelegateCommand((o) => { 
                    if(SelectedProduct.Value != null)
                    addManuallyService.AddArticleManually(SelectedProduct.Value);
                    windowManager.CloseWindow(viewModelLocator.addManuallyViewModel);
            });
        }

        private SortedDictionary<double, Product> scanData { get; set; } = new SortedDictionary<double, Product>();

        private ObservableCollection<KeyValuePair<double, Product>> filteredScanData = new ObservableCollection<KeyValuePair<double, Product>>();

        public ObservableCollection<KeyValuePair<double, Product>> FilteredScanData
        {
            get { return filteredScanData; }
            set
            {
                if (filteredScanData != value)
                {
                    filteredScanData = value;
                    OnPropertyChanged(nameof(FilteredScanData));
                }
            }
        }

        private string filter = "";

        public string Filter
        {get => filter;
            set
            {
                if(value != filter)
                {
                    filter = value;
                    this.OnPropertyChanged(nameof(Filter));
                    this.OnPropertyChanged(nameof(FilteredScanData));
                    DoFiltering();
                }
            }
        }

        private void DoFiltering()
        {
            this.FilteredScanData.Clear();
            string? value = this.filter?.ToLower();
            foreach(KeyValuePair<double, Product> item in scanData)
            {
                if(String.IsNullOrEmpty(Filter) ||
                   item.Value.Name.ToLower().Contains(value) ||
                   item.Value.Articlenumber.ToString().Contains(value)){
                   this.FilteredScanData.Add(new KeyValuePair<double, Product>(item.Key, item.Value));
                }
            }
        }

        public KeyValuePair<double, Product> SelectedProduct { get; set; }

        public DelegateCommand AddCommand { get; set; }
    }
}
