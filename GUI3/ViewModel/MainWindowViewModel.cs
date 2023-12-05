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

namespace GUI.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {

            shoppingBasketObject = new ShoppingBasket();

            lineOfGoodsObject = LineOfGoods.getdummi(); //Sortiment laden

            detectionObject = new Detection(lineOfGoodsObject);

            ///////////////////////////////////////////Commands////////////////////////////////////////////

            this.ClearCommand = new DelegateCommand((o) => shoppingBasketObject._ShoppingBasket.Count >= 0
                                                   , (o) => shoppingBasketObject.Clear());

            this.AddCommand = new DelegateCommand((o) => { shoppingBasketObject.AddArticle(new Product("Banane", 23, 2.2, true, null)); }); 

            this.RemoveCommand = new DelegateCommand((o) => { shoppingBasketObject._ShoppingBasket.Remove(SelectedArticle); });

            this.downQuantityCommand = new DelegateCommand((o) => { shoppingBasketObject.DownQuantity(SelectedArticle); });

            //this.upQuantityCommand = new DelegateCommand((o) => { shoppingBasketObject.UpQuantity(SelectedArticle); } ); 
            
            //WIESO FUNKTIONIERT DAS NICHT?? genau wie Zeile darüber ps: alter Code unten auskommentiert

            //Command für ScanProzess hier initialisieren

            this.payWindowCommand = new DelegateCommand((o) =>
            {
                PayWindow payWindow = new PayWindow();
                payWindow.Show();
            });

            this.editLineOfGoodsWindowCommand = new DelegateCommand((o) =>
            {
                editLineOfGoodsWindow editLineOfGoodsWindow = new editLineOfGoodsWindow();
                editLineOfGoodsWindow.Show();
            });

            this.addManuallyWindowCommand = new DelegateCommand((o) =>
            {
                addManuallyWindow addManuallyWindow = new addManuallyWindow();
                addManuallyWindow.Show();
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

        ////////////////////////////////////////////Commands//////////////////////////////////////////////////////
        
        public DelegateCommand ClearCommand { get; set; }

        public DelegateCommand AddCommand { get; set;}

        public DelegateCommand RemoveCommand { get; set;}

        public Delegate upQuantityCommand { get; set; }

        public DelegateCommand downQuantityCommand { get; set; }

        public DelegateCommand payWindowCommand { get; set; }

        public DelegateCommand editLineOfGoodsWindowCommand { get; set;}

        public DelegateCommand addManuallyWindowCommand { get; set; }



        /*
         
        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                statusTextBox.Text = "Scanning process is running.";

                for (int i = 0; i < 5; i++) // Kamerabild leidet 0 drunter bei ganz vielen Bildern (ohne Internet connection)
                {
                    await Task.Delay(500); //Warten hat also Kamerabild also keinen Effekt

                    (Dictionary<Product, double>, Product?) input = detectionObject.getDetectionOutput(lineOfGoodsObject, currentBitmap);

                    productsAndProbabilitys = input.Item1;

                    scannedProduct = input.Item2;

                    if(scannedProduct != null)
                    {
                        shoppingBasketObject.AddArticle(scannedProduct);
                    }    
                }

                statusTextBox.Text = "Press Space to scan your product!";
            }
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
         */
    }
}
