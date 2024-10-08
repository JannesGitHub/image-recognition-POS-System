﻿using GUI.Core;
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
using System.Windows.Media;

namespace GUI.MVVM.ViewModel
{
    public class EditProductInLineOfGoodsVM: ViewModelBase
    {
        public EditProductInLineOfGoodsVM(IWindowManager windowManager, ViewModelLocator viewModelLocator, IEditLineOfGoods editLineOfGoodsService)
        {
            // Registering for the event to make the selected product visible in the Search window for this VM.
            SearchProductInLineOfGoodsVM searchVM = viewModelLocator.SearchProductInLineOfGoodsVM;

            searchVM.ProductEditedEvent += (sender, args) => { TransferSelectedProduct(EditLineOfGoodsService.SelectedProduct); };

            NewVectorsCommand = new DelegateCommand(execute: async (o) =>
            {
                ClipVectors.Clear();

                List<Bitmap> bitmaps = new List<Bitmap>();

                ButtonBackgroundColor = System.Windows.Media.Brushes.RosyBrown;
                VectorUpdateStatus = "Images are loaded from the camera";

                for (int i = 0; i < 20; i++) // For 2 seconds, a frame is saved every 1/10th of a second (a total of 20 bitmaps).
                {
                    await Task.Delay(100);

                    bitmaps.Add(EditLineOfGoodsService.CurrentBitmap);
                }

                ButtonBackgroundColor = System.Windows.Media.Brushes.BurlyWood;
                VectorUpdateStatus = "Images are converted to vectors";

                List<Task> allTasks = new List<Task>(); // List of tasks to asynchronously transform multiple bitmaps into vectors.
				IDetection detectionObj = new Detection();
				foreach (Bitmap bitmap in bitmaps)
					allTasks.Add(Task.Run(() => ClipVectors.Add(detectionObj.GetCLIPVector(bitmap))));

                await Task.WhenAll(allTasks); // Waits until all tasks are completed.*/

                ButtonBackgroundColor = System.Windows.Media.Brushes.SandyBrown;
                VectorUpdateStatus = "Succesfully added!";
            });

            ApplyCommand = new DelegateCommand(execute: (o) =>
            {
                    editLineOfGoodsService.EditProduct(new Product(Name, ArticleNumber, Price, QuantityBased, ClipVectors));

                    ProductEditedEvent?.Invoke(this, EventArgs.Empty);

                    windowManager.CloseWindow(viewModelLocator.EditProductInLineOfGoodsVM);

                    windowManager.ShowWindow(viewModelLocator.SearchProductInLineOfGoodsVM);
            });

            CloseCommand = new DelegateCommand(execute: (o) => { windowManager.CloseWindow(viewModelLocator.EditProductInLineOfGoodsVM);});
        }

        /////////////////////////////////////////////////////ATTRIBUTES///////////////////////////////////////////////////////////

        public event EventHandler ProductEditedEvent = delegate { };

        private string _name = "";
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

        private bool _weightBased = true;
        private bool _quantityBased;

        public bool WeightBased
        {
            get { return _weightBased; }
            set
            {
                if (_weightBased != value)
                {
                    _weightBased = value;
                    OnPropertyChanged(nameof(WeightBased));
                }
            }
        }

        public bool QuantityBased
        {
            get { return _quantityBased; }
            set
            {
                if (_quantityBased != value)
                {
                    _quantityBased = value;
                    OnPropertyChanged(nameof(QuantityBased));
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

        //ANZEIGE FÜR VEKTOR AKTUALISIERUNGSZUSTAND

        private SolidColorBrush _buttonBackgroundColor = System.Windows.Media.Brushes.SandyBrown; // Standardfarbe
        public SolidColorBrush ButtonBackgroundColor
        {
            get { return _buttonBackgroundColor; }
            set
            {
                if (_buttonBackgroundColor != value)
                {
                    _buttonBackgroundColor = value;
                    OnPropertyChanged(nameof(ButtonBackgroundColor));
                }
            }
        }

        private string _vectorUpdateStatus = "Add Images to Product";

        public string VectorUpdateStatus
        {
            get { return _vectorUpdateStatus; }
            set
            {
                if (_vectorUpdateStatus != value)
                {
                    _vectorUpdateStatus = value;
                    OnPropertyChanged(nameof(VectorUpdateStatus));
                }
            }
        }

        /////////////////////////////////////////////////////METHODS/////////////////////////////////////////////////////////////

        private void TransferSelectedProduct(Product product)
        {
            Name = product.Name;
            ArticleNumber = product.Articlenumber;
            Price = product.Price;
            QuantityBased = product.Quantityarticle;
            ClipVectors = product.Allproductvectors;
            VectorUpdateStatus = "Add Images to Product";
        }

        /////////////////////////////////////////////////////COMMANDS///////////////////////////////////////////////////////////

        public DelegateCommand NewVectorsCommand { get; set; }

        public DelegateCommand ApplyCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
