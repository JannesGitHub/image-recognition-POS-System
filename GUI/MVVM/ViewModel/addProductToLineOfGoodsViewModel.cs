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
    public class addProductToLineOfGoodsViewModel : ViewModelBase
    {
        public addProductToLineOfGoodsViewModel(IWindowManager windowManager, ViewModelLocator viewModelLocator, IeditLineOfGoods editLineOfGoodsService)
        {
            NewVectorsCommand = new DelegateCommand(async (o) =>
            {
                List<Bitmap> bitmaps = new List<Bitmap>();

                for (int i = 0; i < 50; i++)
                {
                    await Task.Delay(30);

                    bitmaps.Add(editLineOfGoodsService.currentBitmap);
                }

                List<CLIPVector> vectors = new List<CLIPVector>();

                foreach (Bitmap bitmap in bitmaps)
                {
                    vectors.Add(Detection.GetCLIPVector(bitmap));
                }

                clipVectors = vectors;
            });

            AddCommand = new DelegateCommand((o) =>
            {
                editLineOfGoodsService.AddProduct(new Product(Name, ArticleNumber, Price, IsSecondRadioButtonSelected, clipVectors));
                ProductAdded?.Invoke(this, EventArgs.Empty);
            });
        }


        public event EventHandler ProductAdded;

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

        //Update

        public event EventHandler WindowClosed;

        public void CloseWindow()
        {
            WindowClosed?.Invoke(this, EventArgs.Empty);
        }

        public List<CLIPVector> clipVectors { get; set; } = new List<CLIPVector>();

        public DelegateCommand NewVectorsCommand { get; set; }

        public DelegateCommand AddCommand { get; set; }
    }
}
