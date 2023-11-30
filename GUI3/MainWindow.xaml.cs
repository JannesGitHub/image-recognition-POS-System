using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KassenmanagementLibrary;
using System.Windows;
using System.Windows.Media.Imaging;
using Camera;
using System.Timers;
using Camera;
using System.Windows.Media.Media3D;
using System.Drawing;
using System.Windows.Input;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public void CheckConstant() 
        {
           

            //getDetected(Bitmap Ralf, Sortiment) -> ProduktDictionary von Can //sortiert nach Wahrscheinlichkeiten

            //zeit ticker

            //getValidProduct -> Product oder null
        }


        

        public MainWindow()
        {
            shoppingBasketObject = new ShoppingBasket();

            DataContext = shoppingBasketObject; // DataContext wird auf dieses Object gelegt

            lineOfGoodsObject = LineOfGoods.getdummi(); //Sortiment laden

            InitializeComponent();

            //CAMERA STUFF
            camera = new Cam();

            //cam.newFrame -> RALF schau mal in Camera die Kommentare

            timer = new Timer(100); //not optimal
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;

            // Starte den Timer
            timer.Start();

            //CAMERA STUFF ENDE
        }

        ///////////////////////////////////////////////////////ATTRIBUTE///////////////////////////////////////////////////////////

        //Kassenmanagement Objects
        public ShoppingBasket shoppingBasketObject;

        public LineOfGoods lineOfGoodsObject;

        //Cam Object
        private Cam camera;

        private Bitmap currentBitmap;

        //Detection Objects
        private Timer timer;

        public Product scannedProduct;

        Dictionary<Product, double> productsAndProbabilitys;

        ///////////////////////////////////////////////////////METHODEN///////////////////////////////////////////////////////////

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is the space bar
            if (e.Key == Key.Space)
            {
                // Your code to handle the space bar press
                // For example, display a message or perform an action
                MessageBox.Show("Space bar pressed!");
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e) 
        {
            Product test = new Product("Banane", 123, 2.2, true, null);

            shoppingBasketObject.AddArticle(test);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) //Wird gecallt wenn Minusfunktion 0 erreicht //bzw. gelöscht später
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;

            shoppingBasketObject._ShoppingBasket.Remove(item);
        }
        
        private void deleteShoppingBasketButton_Click(object sender, RoutedEventArgs e) //löscht den gesamten ShoppingBasket 
        {
            shoppingBasketObject.Clear();
        }
        
        //Vorerst nur für Stück Produkte
        private void plusButton_Click(object sender, RoutedEventArgs e) //erhöht Stückzahl und automatisch Preis Update //ToChange
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;
            if(item != null)
            shoppingBasketObject.UpQuantity(item);
        }
        
        private void minusButton_Click(object sender, RoutedEventArgs e) //vermindert Stückzahl und Preis 
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;
            if (item != null)
            {
                shoppingBasketObject.DownQuantity(item);

                if (shoppingBasketObject._ShoppingBasket[shoppingBasketObject._ShoppingBasket.IndexOf(item)].Quantity == 0) //Wenn 0 dann löschen
                    deleteButton_Click(this, e);
            }
        }
        
        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            PayWindow payWindow = new PayWindow();
            payWindow.Show();
        }

        private void editLineOfGoodsButton_Click(object sender, RoutedEventArgs e)
        {
            editLineOfGoodsWindow editLineOfGoodsWindow = new editLineOfGoodsWindow();
            editLineOfGoodsWindow.Show();
        }

        private void addManuallyButton_Click(object sender, RoutedEventArgs e)
        {
            addManuallyWindow addManuallyWindow = new addManuallyWindow();
            addManuallyWindow.Show();
        }

        ///////////////////////////////////////////////////////BILDDARSTELLUNG///////////////////////////////////////////////////////////
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Übertrage und zeige das aktuelle Bitmap
            if (camera != null)
            {
                Bitmap bitmap = camera.GetCurrentBitmap();

                currentBitmap = bitmap; //speichern in lokaler Variable
                if (bitmap != null)
                {
                    // Führe die Anzeigeoperation auf dem UI-Thread aus
                    Dispatcher.Invoke(() => ShowBitmap(bitmap));
                }
            }
        }

        private void ShowBitmap(Bitmap bitmap)
        {
            // Konvertiere das Bitmap in ein BitmapImage und zeige es in der GUI an
            BitmapImage bitmapImage = BmpImageFromBmp(bitmap);
            anzeigeBild.Source = bitmapImage;
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
    }
}
