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

            mainVM.PayEvent += (sender, args) => { TotalPrice = payservice.TotalPrice; };

            TotalPrice = payservice.TotalPrice;

            CashInCommand = new DelegateCommand((o) => windowManager.CloseWindow(viewModelLocator.PayWindowViewModel));

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
                    OnPropertyChanged(nameof(PaidAmount)); // Benachrichtigen Sie über die Änderung
                    CalculateChange(); // Berechnen Sie den Wechsel
                }
            }
        }

        private void CalculateChange()
        {
            Change = PaidAmount - TotalPrice;
            OnPropertyChanged(nameof(Change)); // Benachrichtigen Sie über die Änderung
        }
        public double Change { get; set; }


        ////////////////////////////////////////COMMANDS////////////////////////////////////////

        public DelegateCommand CashInCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
