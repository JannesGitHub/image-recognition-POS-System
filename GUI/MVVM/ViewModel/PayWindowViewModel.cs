using GUI.Core;
using GUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.MVVM.ViewModel
{
    public class PayWindowViewModel : ViewModelBase
    {
        public PayWindowViewModel(IPayService payservice,ViewModelLocator viewModelLocator, IWindowManager windowManager)     
        {
            var mainVM = viewModelLocator.MainWindowViewModel;

            mainVM.PayEvent += (sender, args) => { TotalPrice = payservice.TotalPrice;
                PaidAmount = 0.1;
            };
            
            //gleiches Problem wie bei editProdcutLineOfGoods

            TotalPrice = payservice.TotalPrice;

            PaidAmount = 0.1; //damit man Preis ändern kann


            CashInCommand = new DelegateCommand((o) =>
            {
                mainVM.shoppingBasketObject.Clear();
                windowManager.CloseWindow(viewModelLocator.PayWindowViewModel);
            });

            CloseCommand = new DelegateCommand((o) => windowManager.CloseWindow(viewModelLocator.PayWindowViewModel));
        }

        public double TotalPrice { get; set; }

        private double _paidAmount;
        public double PaidAmount
        {
            get => _paidAmount;
            set
            {
                if (_paidAmount != value)
                {
                    _paidAmount = value;
                    OnPropertyChanged(nameof(PaidAmount)); 
                    CalculateChange(); 
                }
            }
        }

        private void CalculateChange()
        {
            Change = Math.Round(PaidAmount - TotalPrice,2);
            OnPropertyChanged(nameof(Change)); // Benachrichtigen Sie über die Änderung
        }
        public double Change { get; set; }


        ////////////////////////////////////////COMMANDS////////////////////////////////////////

        public DelegateCommand CashInCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
