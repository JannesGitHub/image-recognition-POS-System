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
using System.Windows;

namespace GUI.MVVM.ViewModel
{
    public class addProductToLineOfGoodsViewModel : ViewModelBase
    {
        public addProductToLineOfGoodsViewModel(IeditLineOfGoods editLineOfGoodsService, IWindowManager windowManager, ViewModelLocator viewModelLocator)
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

                ClipVectors = vectors;
            });

            AddCommand = new DelegateCommand((o) =>
            {
                if (!editLineOfGoodsService.IsIDUnique(ArticleNumber))
                {
                    MessageBox.Show("This ID is already taken.\nPlease change to apply change.");
                }
                else
                {
                    editLineOfGoodsService.AddProduct(new Product(Name, ArticleNumber, Price, IsSecondRadioButtonSelected, ClipVectors));

                    ProductAdded?.Invoke(this, EventArgs.Empty);

                    windowManager.CloseWindow(viewModelLocator.addProductToLineOfGoodsViewModel);

                    windowManager.ShowWindow(viewModelLocator.SearchProductInLineOfGoodsViewModel);

                    //Clear the Values after added:
                    Name = null;
                    ArticleNumber = 0;
                    Price = 0;
                    IsFirstRadioButtonSelected = true;
                    ClipVectors = new List<CLIPVector>();
                }
            });

            CloseCommand = new DelegateCommand(execute: (o) =>
            {
                windowManager.CloseWindow(viewModelLocator.addProductToLineOfGoodsViewModel);
            });

        }


        /////////////////////////////////////////////////////////ATTRIBUTES/////////////////////////////////////////////////////////////////

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

        public List<CLIPVector> ClipVectors { get; set; } = new List<CLIPVector>();



        /////////////////////////////////////////////////////////////COMMANDS//////////////////////////////////////////////////////////

        public DelegateCommand NewVectorsCommand { get; set; }

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
