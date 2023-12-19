using GUI.Core;
using GUI.Services;
using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace GUI.MVVM.ViewModel
{
    public class searchProductInLineOfGoodsViewModel : ViewModelBase
    {

        public IeditLineOfGoods _editLineOfGoodsService { get; set; }

        public searchProductInLineOfGoodsViewModel(IeditLineOfGoods editLineOfGoodsService, IWindowManager windowManager, ViewModelLocator viewModelLocator) 
        {
            LineOfGoods = editLineOfGoodsService.LineOfGoods;

            DeleteCommand = new DelegateCommand((o) =>
            {
                if(SelectedProduct != null)
                editLineOfGoodsService.DeleteProduct(SelectedProduct);
                OnPropertyChanged(nameof(LineOfGoods));
            });

            EditCommand = new DelegateCommand((o) =>
            {
                
            });
        }

        public Product SelectedProduct { get; set; }

        private LineOfGoods lineOfGoods;

        public LineOfGoods LineOfGoods
        {
            get { return lineOfGoods; }
            set { if(value != null)
                    lineOfGoods = value;
                    OnPropertyChanged(nameof(LineOfGoods));}
        }

        public DelegateCommand DeleteCommand { get; set; }

        public DelegateCommand EditCommand { get; set; }
    }
}
