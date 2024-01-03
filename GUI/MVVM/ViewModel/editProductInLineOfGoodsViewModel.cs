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

            searchVM.ProductEditedEvent += (sender, args) => //wird beim ersten Mal nicht korrekt ausgeführt. Warum?
            {
                productToChange = args.EditedProduct;

                Name = productToChange.Name;
                ArticleNumber = productToChange.Articlenumber;
                Price = productToChange.Price;
                IsSecondRadioButtonSelected = productToChange.Quantityarticle;
                clipVectors = productToChange.Allproductvectors;
            };

            NewVectorsCommand = new DelegateCommand(async (o) =>
            {

                clipVectors.Clear();

                Stopwatch watch = new Stopwatch();

                watch.Start();

                List<Bitmap> bitmaps = new List<Bitmap>();

                for (int i = 0; i < 100; i++)
                {
                    await Task.Delay(20);

                    bitmaps.Add(editLineOfGoodsService.currentBitmap);
                }

                List<Task> allTasks = new List<Task>(); //vielleicht noch nicht optimal aber kann ich erst richtig testen wenn mit Internet verbunden

                foreach (Bitmap bitmap in bitmaps)
                {
                    //allTasks.Add(Task.Run(() => clipVectors.Add(Detection.GetCLIPVector(bitmap))));
                    allTasks.Add(Task.Run(() => clipVectors.Add(new CLIPVector()))); //kriege ich hier schon einen Zeitvorteil?
                }

                await Task.WhenAll(allTasks);

                watch.Stop();

                MessageBox.Show($"{watch.ElapsedMilliseconds}");
            });

            ApplyCommand = new DelegateCommand((o) =>
            {
                editLineOfGoodsService.EditProduct(new Product(Name, ArticleNumber, Price, IsSecondRadioButtonSelected, clipVectors));

                ProductEdited?.Invoke(this, EventArgs.Empty);

                windowManager.CloseWindow(viewModelLocator.editProductInLineOfGoodsViewModel);

                windowManager.ShowWindow(viewModelLocator.SearchProductInLineOfGoodsViewModel);
            });

            CloseCommand = new DelegateCommand(execute: (o) =>
            {
                windowManager.CloseWindow(viewModelLocator.editProductInLineOfGoodsViewModel);
            });
        }

        public event EventHandler ProductEdited;

        public Product productToChange { get; set; }

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

        public DelegateCommand CloseCommand { get; set; }
    }
}
