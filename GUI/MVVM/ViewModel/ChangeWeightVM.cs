using GUI.Core;
using GUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.MVVM.ViewModel
{
    public class ChangeWeightVM : ViewModelBase
    {
        public ChangeWeightVM(IChangeWeightService changeWeightService ,ViewModelLocator viewModelLocator, IWindowManager windowManager)
        {
            MainVM mainVM = viewModelLocator.MainVM;

            mainVM.ChangeWeightEvent += (sender, args) => { NewWeight = changeWeightService.NewWeight;};

            ApplyCommand = new DelegateCommand(execute: (o) =>
            {
                mainVM.ShoppingBasket.NewQuantity(mainVM.SelectedArticle, NewWeight);

                windowManager.CloseWindow(viewModelLocator.ChangeWeightVM);
            }
            );

            CloseCommand = new DelegateCommand((o) => windowManager.CloseWindow(viewModelLocator.ChangeWeightVM));
        }

        ////////////////////////////////////////ATTRIBUTES////////////////////////////////////////

        private double _newWeight;

        public double NewWeight
        {
            get { return _newWeight; }
            set
            {
                if (value != _newWeight)
                {
                    _newWeight = value;
                    OnPropertyChanged(nameof(NewWeight));   
                }
            }
        }
        

        ////////////////////////////////////////COMMANDS////////////////////////////////////////

        public DelegateCommand ApplyCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
