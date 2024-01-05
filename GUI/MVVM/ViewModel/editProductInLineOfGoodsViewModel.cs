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
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;

namespace GUI.MVVM.ViewModel
{
    public class editProductInLineOfGoodsViewModel : ViewModelBase
    {
        public editProductInLineOfGoodsViewModel(IWindowManager windowManager, ViewModelLocator viewModelLocator, IeditLineOfGoods editLineOfGoodsService)
        {

            var searchVM = viewModelLocator.SearchProductInLineOfGoodsViewModel;

            searchVM.ProductEditedEvent += (sender, args) => { TransferSelectedProduct(editLineOfGoodsService.toEditProduct); };

            NewVectorsCommand = new DelegateCommand(async (o) =>
            {
                ClipVectors.Clear();

                List<Bitmap> bitmaps = new List<Bitmap>();

                for (int i = 0; i < 20; i++) //für 2 Sekunden alle 1/10te Sekunde wird Frame gespeichert (insgesamt 20 Bitmaps)
                {
                    await Task.Delay(100); 

                    bitmaps.Add(editLineOfGoodsService.currentBitmap);
                }

                List<Task> allTasks = new List<Task>(); //Task List um mehrere Bitmaps asynchron zu tranformieren zu Vektoren

                foreach (Bitmap bitmap in bitmaps)
                    allTasks.Add(Task.Run(() => ClipVectors.Add(Detection.GetCLIPVector(bitmap))));

                await Task.WhenAll(allTasks);
            });

            ApplyCommand = new DelegateCommand((o) =>
            {
                    editLineOfGoodsService.EditProduct(new Product(Name, ArticleNumber, Price, IsSecondRadioButtonSelected, ClipVectors));

                    ProductEdited?.Invoke(this, EventArgs.Empty);

                    windowManager.CloseWindow(viewModelLocator.editProductInLineOfGoodsViewModel);

                    windowManager.ShowWindow(viewModelLocator.SearchProductInLineOfGoodsViewModel);
            });

            CloseCommand = new DelegateCommand(execute: (o) =>
            {
                windowManager.CloseWindow(viewModelLocator.editProductInLineOfGoodsViewModel);
            });
        }

        /////////////////////////////////////////////////////ATTRIBUTES///////////////////////////////////////////////////////////

        public event EventHandler ProductEdited;

        public Product productToChange { get; set; }

        private string _name;
        public string Name {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private uint _articleNumber;

        public uint ArticleNumber {
            get { return _articleNumber; }
            set
            {
                if (_articleNumber != value)
                {
                    _articleNumber = value;
                    OnPropertyChanged(nameof(ArticleNumber));
                }
            }
        }

        private double _price;

        public double Price {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

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

        private List<CLIPVector> _clipVectors = new List<CLIPVector>();

        public List<CLIPVector> ClipVectors {
            get { return _clipVectors; }
            set
            {
                if (_clipVectors != value)
                {
                    _clipVectors = value;
                    OnPropertyChanged(nameof(ClipVectors));
                }
            }
         }

        /////////////////////////////////////////////////////ÜBERTRAGUNG///////////////////////////////////////////////////////////

        private void TransferSelectedProduct(Product product)
        {
            Name = product.Name;
            ArticleNumber = product.Articlenumber;
            Price = product.Price;
            IsFirstRadioButtonSelected = !product.Quantityarticle;
            IsSecondRadioButtonSelected = product.Quantityarticle;
            ClipVectors = product.Allproductvectors;
        }

        /////////////////////////////////////////////////////COMMANDS///////////////////////////////////////////////////////////

        public DelegateCommand NewVectorsCommand { get; set; }

        public DelegateCommand ApplyCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
