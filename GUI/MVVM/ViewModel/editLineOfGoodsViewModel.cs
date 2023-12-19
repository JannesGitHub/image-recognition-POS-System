using GUI.Core;
using GUI.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.MVVM.ViewModel
{
    public class editLineOfGoodsViewModel : ViewModelBase
    {

        private readonly IWindowManager _windowManager;
        private readonly ViewModelLocator _viewModelLocator;

        public editLineOfGoodsViewModel(IWindowManager windowManager, ViewModelLocator viewModelLocator) 
        {
            _viewModelLocator = viewModelLocator;

            _windowManager = windowManager;

            this.AddCommand = new DelegateCommand((o) =>
            {
                _windowManager.ShowWindow(_viewModelLocator.addProductToLineOfGoodsViewModel);
            });

            this.EditCommand = new DelegateCommand((o) =>
            {
                _windowManager.ShowWindow(_viewModelLocator.SearchProductInLineOfGoodsViewModel);
            });
        }

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand EditCommand { get; set; }
    }
}
