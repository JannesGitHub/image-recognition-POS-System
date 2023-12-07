using Camera;
using DetectionLibrary;
using KassenmanagementLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Timers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace GUI.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {

            //////////////////////////////////////////INITIALIZING/////////////////////////////////////////

            shoppingBasketObject = new ShoppingBasket();

            lineOfGoodsObject = LineOfGoods.getdummi(); //Sortiment laden

            detectionObject = new Detection(lineOfGoodsObject);

            ScanStatus = "Press Space to scan your product!";

            ////////////////////////////////////////////CAMERA/////////////////////////////////////////////

            camera = new Cam();

            camera.NewFrame += OnNewFrame;

            ///////////////////////////////////////////Commands////////////////////////////////////////////

            this.ClearCommand = new DelegateCommand((o) => shoppingBasketObject._ShoppingBasket.Count >= 0
                                                   ,(o) => shoppingBasketObject.Clear());

            this.AddCommand = new DelegateCommand((o) => { shoppingBasketObject.AddArticle(new Product("Banane", 23, 2.2, true, null)); }); 

            this.RemoveCommand = new DelegateCommand((o) => { shoppingBasketObject._ShoppingBasket.Remove(SelectedArticle); });

            this.downQuantityCommand = new DelegateCommand((o) => 
            {
                if (SelectedArticle != null)
                {
                    shoppingBasketObject.DownQuantity(SelectedArticle);
                    if (shoppingBasketObject._ShoppingBasket[shoppingBasketObject._ShoppingBasket.IndexOf(SelectedArticle)].Quantity == 0)
                        shoppingBasketObject._ShoppingBasket.Remove(SelectedArticle);
                }
            });

            this.upQuantityCommand = new DelegateCommand((o) => {
                if (SelectedArticle != null)
                    shoppingBasketObject.UpQuantity(SelectedArticle); } );

            
            this.ScanCommand = new DelegateCommand(async (o) => 
            {
                ScanStatus = "Scanning process is running.";
                for (int i = 0; i < 5; i++) // Kamerabild leidet 0 drunter bei ganz vielen Bildern (ohne Internet connection)
                {
                    await Task.Delay(500); //Warten hat also Kamerabild also keinen Effekt

                    (Dictionary<Product, double>, Product?) input = detectionObject.getDetectionOutput(lineOfGoodsObject, currentBitmap);

                    productsAndProbabilitys = input.Item1;

                    scannedProduct = input.Item2;

                    if (scannedProduct != null)
                    {
                        shoppingBasketObject.AddArticle(scannedProduct);
                    }
                }
                ScanStatus = "Press Space to scan your product!";
            });

            this.payWindowCommand = new DelegateCommand((o) =>
            {
                this.payWindow?.Invoke(this, EventArgs.Empty);
            });

            this.editLineOfGoodsWindowCommand = new DelegateCommand((o) =>
            {
                this.editLineOfGoodsWindow?.Invoke(this, EventArgs.Empty);
            });

            this.addManuallyWindowCommand = new DelegateCommand((o) =>
            {
                this.addManuallyWindow?.Invoke(this, EventArgs.Empty);
            });
        }
        ////////////////////////////////////////////ATTRIBUTES///////////////////////////////////////////////
        
        //Kassenmanagement Objects
        public ShoppingBasket shoppingBasketObject { get; set; }

        private Article selectedArticle;

        public Article SelectedArticle
        {
            get { return selectedArticle; }
            set
            {
                if (selectedArticle != value)
                {
                    selectedArticle = value;
                    OnPropertyChanged(nameof(SelectedArticle));
                }
            }
        }
        public LineOfGoods lineOfGoodsObject { get; set; }

        //Detection Objects
        private Detection detectionObject { get; set; }

        public Product scannedProduct { get; set; }

        private Dictionary<Product, double> productsAndProbabilitys {  get; set; }

        private string scanStatus;

        public string ScanStatus {
            get { return scanStatus; }
            set
            {
                if (scanStatus != value)
                {
                    scanStatus = value;
                    OnPropertyChanged(nameof(ScanStatus));
                }
            }
        }

        //Camera Objects

        public Cam camera { get; set; }

        public Bitmap currentBitmap { get; set; }

        private BitmapSource _currentSource;

        public BitmapSource CurrentSource
        {
            get { return _currentSource; }
            set
            {
                if (_currentSource != value)
                {
                    _currentSource = value;
                    OnPropertyChanged(nameof(CurrentSource));
                }
            }
        }

        //////////////////////////////////////////////EVENTS////////////////////////////////////////////////////// 

        public event EventHandler addManuallyWindow;

        public event EventHandler editLineOfGoodsWindow;

        public event EventHandler payWindow;

        ////////////////////////////////////////////CAMERA METHODS////////////////////////////////////////////////

        public virtual void OnNewFrame(object sender, EventArgs e)
        {
            if (camera != null)
            {
                Bitmap bitmap = camera.GetCurrentBitmap();

                currentBitmap = bitmap; //speichern in lokaler Variable

                //CHATGPT -> unsicher ob es funktioniert

                if (bitmap != null)
                {
                    // Überprüfen Sie, ob der Dispatcher verfügbar ist und auf dem UI-Thread läuft
                    if (System.Windows.Application.Current.Dispatcher.CheckAccess())
                    {
                        ShowBitmap(bitmap);
                    }
                    else
                    {
                        // Falls nicht, rufen Sie den Dispatcher des UI-Threads auf
                        System.Windows.Application.Current.Dispatcher.Invoke(() => ShowBitmap(bitmap));
                    }
                }
            }
        }

        private void ShowBitmap(Bitmap bitmap)
        {
            // Konvertiere das Bitmap in ein BitmapImage und zeige es in der GUI an
            BitmapImage bitmapImage = BmpImageFromBmp(bitmap);
            CurrentSource = bitmapImage;
        }

        private BitmapImage BmpImageFromBmp(Bitmap bmp) //Aus Forum: Transformiert Bitmap in GUI nutzbares BitmapSource
        {
            using (var memory = new System.IO.MemoryStream())
            {
                bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }


        ////////////////////////////////////////////Commands//////////////////////////////////////////////////////

        public DelegateCommand ClearCommand { get; set; }

        public DelegateCommand AddCommand { get; set;}

        public DelegateCommand RemoveCommand { get; set;}

        public DelegateCommand upQuantityCommand { get; set; }

        public DelegateCommand downQuantityCommand { get; set; }

        public DelegateCommand payWindowCommand { get; set; }

        public DelegateCommand editLineOfGoodsWindowCommand { get; set;}

        public DelegateCommand addManuallyWindowCommand { get; set; }

        public DelegateCommand ScanCommand { get; set; }
    }
}
