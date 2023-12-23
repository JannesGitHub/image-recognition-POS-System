using GUI.Core;
using GUI.Services;
using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DetectionLibrary;

namespace GUI.MVVM.ViewModel
{
    public class editProductInLineOfGoodsViewModel : ViewModelBase
    {
        public editProductInLineOfGoodsViewModel(IWindowManager windowManager,ViewModelLocator viewModelLocator, IeditLineOfGoods editLineOfGoodsService)
        {
            productToChange = editLineOfGoodsService.toEditProduct;

            NewVectorsCommand = new DelegateCommand(async (o) =>
            {
                List<Bitmap> bitmaps = new List<Bitmap>();

                for (int i = 0; i < 50; i++) 
                {
                    await Task.Delay(30);

                    bitmaps.Add(editLineOfGoodsService.currentBitmap);
                }

                List<CLIPVector> vectors = new List<CLIPVector>();

                foreach(Bitmap bitmap in bitmaps)
                {
                    vectors.Add(Detection.GetCLIPVector(bitmap));
                }

                clipVectors = vectors;
            });

            ApplyCommand = new DelegateCommand((o) =>
            {
                editLineOfGoodsService.EditProduct(new Product(Name, ArticleNumber, Price, IsSecondRadioButtonSelected, clipVectors));

                windowManager.CloseWindow(viewModelLocator.editProductInLineOfGoodsViewModel);
            });
        }

        public Product productToChange { get ; set; }   

        public string Name { get; set; }

        public uint ArticleNumber { get; set; }

        public double Price { get; set; }

        private bool _isFirstRadioButtonSelected = true;
        private bool _isSecondRadioButtonSelected;

        public bool IsFirstRadioButtonSelected
        {
            get { return _isFirstRadioButtonSelected; }
            set
            {
                if (_isFirstRadioButtonSelected != value)
                {
                    _isFirstRadioButtonSelected = value;
                    OnPropertyChanged(nameof(IsFirstRadioButtonSelected));
                }
            }
        }

        public bool IsSecondRadioButtonSelected
        {
            get { return _isSecondRadioButtonSelected; }
            set
            {
                if (_isSecondRadioButtonSelected != value)
                {
                    _isSecondRadioButtonSelected = value;
                    OnPropertyChanged(nameof(IsSecondRadioButtonSelected));
                }
            }
        }

        public List<CLIPVector> clipVectors { get; set; } = new List<CLIPVector>(); 

        public DelegateCommand NewVectorsCommand { get; set; }

        public DelegateCommand ApplyCommand { get; set; }
    }
}
