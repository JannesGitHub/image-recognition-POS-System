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
using System.Windows.Media;

namespace GUI.MVVM.ViewModel
{
    public class AddProductToLineOfGoodsVM : ViewModelBase
    {
        public AddProductToLineOfGoodsVM(IEditLineOfGoods editLineOfGoodsService, IWindowManager windowManager, ViewModelLocator viewModelLocator)
        {

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


            AddCommand = new DelegateCommand(execute: (o) =>
            {
                if (!editLineOfGoodsService.IsIdUnique(ArticleNumber))
                {
                    MessageBox.Show("This ID is already taken.\nPlease change to apply change.");
                }
                else
                {
                    editLineOfGoodsService.AddProduct(new Product(Name, ArticleNumber, Price, QuantityBased, ClipVectors));

                    ProductAddedEvent?.Invoke(this, EventArgs.Empty);

                    windowManager.CloseWindow(viewModelLocator.AddProductToLineOfGoodsVM);

                    windowManager.ShowWindow(viewModelLocator.SearchProductInLineOfGoodsVM);

                    // Clears the values after theyre added:
                    Name = ""; ArticleNumber = 0; Price = 0; WeightBased = true; ClipVectors = new List<CLIPVector>();
                }
            });

            CloseCommand = new DelegateCommand(execute: (o) => { windowManager.CloseWindow(viewModelLocator.AddProductToLineOfGoodsVM); });
        }


        /////////////////////////////////////////////////////////ATTRIBUTES/////////////////////////////////////////////////////////////////

        public event EventHandler ProductAddedEvent = delegate { }; 

        public string Name { get; set; } = "";

        public uint ArticleNumber { get; set; }

        public double Price { get; set; }

        public bool WeightBased { get; set; } = true;

        public bool QuantityBased { get; set; }

        public List<CLIPVector> ClipVectors { get; set; } = new List<CLIPVector>();

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


        /////////////////////////////////////////////////////////////COMMANDS//////////////////////////////////////////////////////////

        public DelegateCommand NewVectorsCommand { get; set; }

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }
    }
}
