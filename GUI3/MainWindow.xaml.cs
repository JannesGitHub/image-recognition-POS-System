using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KassenmanagementLibrary;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public void CheckConstant()
        {
            //getBitmap -> Ralf

            //getDetected(Bitmap Ralf, Sortiment) -> ProduktDictionary von Can //sortiert nach Wahrscheinlichkeiten

            //zeit ticker

            //getValidProduct -> Product oder null

            //Warenkorb:
            //Produkte bearbeiten 
            //Sortiment 
            //Sortiment speichern
        }

        public MainWindow()
        {
            DataContext = this;

            shoppingBasketObject = new ShoppingBasket();

            ShoppingBasket = shoppingBasketObject._ShoppingBasket;

            InitializeComponent();
        }


        //ATTRIBUTE
        public ShoppingBasket shoppingBasketObject;

        private ObservableCollection<Article> shoppingBasket;  //ShoppingBasket

        public ObservableCollection<Article> ShoppingBasket 
        {
            get { return shoppingBasket; }
            set { shoppingBasket = value; }
        }

        public Product scanned { get; set; } //Hier wird das gescannte Produkt übergeben für die Add-Funktion

        //METHODEN
        private void addButton_Click(object sender, RoutedEventArgs e) 
        {
            Product test = new Product("Banane", 123, 2.2, true, null);

            shoppingBasketObject.Add(test);

            priceTextBlock.Text = Convert.ToString(shoppingBasketObject.SumPrice); //Update Price
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) //Wird gecallt wenn Minusfunktion 0 erreicht //bzw. gelöscht später
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;

            ShoppingBasket.Remove(item);

            priceTextBlock.Text = Convert.ToString(shoppingBasketObject.SumPrice); //Update Price
        }
        
        private void deleteShoppingBasketButton_Click(object sender, RoutedEventArgs e) //löscht den gesamten ShoppingBasket 
        {
            shoppingBasketObject.Clear();

            priceTextBlock.Text = Convert.ToString(shoppingBasketObject.SumPrice); //Update Price
        }
        
        //Vorerst nur für Stück Produkte
        private void plusButton_Click(object sender, RoutedEventArgs e) //erhöht Stückzahl und automatisch Preis Update //ToChange
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;
            shoppingBasketObject.UpQuantity(item);

            priceTextBlock.Text = Convert.ToString(shoppingBasketObject.SumPrice); //Update Price
        }
        
        private void minusButton_Click(object sender, RoutedEventArgs e) //vermindert Stückzahl und Preis 
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;
            shoppingBasketObject.DownQuantity(item);

            if (ShoppingBasket[ShoppingBasket.IndexOf(item)].Quantity == 0) //Wenn 0 dann löschen
                deleteButton_Click(this, e);

            priceTextBlock.Text = Convert.ToString(shoppingBasketObject.SumPrice); //Update Price
        }
        
        private void tryScreenButton_Click(object sender, RoutedEventArgs e)
        {
            NewWindow newWindow = new NewWindow();
            newWindow.Show();
        }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            PayWindow payWindow = new PayWindow();
            payWindow.Show();
        }
    }
}
