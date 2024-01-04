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
        public PayWindowViewModel(ViewModelLocator viewModelLocator, IWindowManager windowManager)     
        {



            CashInCommand = new DelegateCommand((o) => windowManager.CloseWindow(viewModelLocator.PayWindowViewModel));
            CloseCommand = new DelegateCommand((o) => windowManager.CloseWindow(viewModelLocator.PayWindowViewModel));
        }

        public double TotalPrice { get; set; }

        public double PaidAmount { get; set; }  

        public double Change { get; set; }

        //Service für Übertragung von Gesamtpreis

        ////////////////////////////////////////COMMANDS////////////////////////////////////////

        public DelegateCommand CashInCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
