using GUI.Core;
using GUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GUI.MVVM.ViewModel
{
    public class PayVM : ViewModelBase
    {
        public PayVM(IPayService payservice,ViewModelLocator viewModelLocator, IWindowManager windowManager)     
        {
            MainVM mainVM = viewModelLocator.MainVM;

            mainVM.PayEvent += (sender, args) => { TotalPrice = payservice.TotalPrice;  PaidAmount = 0.1; };

            CashInCommand = new DelegateCommand((o) =>
            {
                mainVM.ShoppingBasket.Clear();

                _soundPlayer.Play();

                windowManager.CloseWindow(viewModelLocator.PayVM);
            });

            CloseCommand = new DelegateCommand((o) => windowManager.CloseWindow(viewModelLocator.PayVM));

            //get path for Sound
            string fileName = "ChaChing.wav";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            filePath = filePath.Substring(0, filePath.IndexOf("j-kassenscanner"));
            filePath += "j-kassenscanner\\Sounds\\" + fileName;

            _soundPlayer = new SoundPlayer(filePath);
        }

        ////////////////////////////////////////ATTRIBUTES////////////////////////////////////////

        private double _totalPrice;

        public double TotalPrice {
            get {return _totalPrice;}
            set
            {
                if (_totalPrice != value)
                {
                    _totalPrice = value;
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        private double _paidAmount;
        public double PaidAmount
        {
            get { return _paidAmount; }
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
            OnPropertyChanged(nameof(Change)); 
        }
        public double Change { get; set; }

        //CHA CHING SOUND

        private readonly SoundPlayer _soundPlayer;

        ////////////////////////////////////////COMMANDS////////////////////////////////////////

        public DelegateCommand CashInCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
