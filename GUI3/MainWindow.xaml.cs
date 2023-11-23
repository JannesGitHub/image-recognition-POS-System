using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public MainWindow()
        {
            DataContext = this;

            entries = new ObservableCollection<Article>();

            InitializeComponent();
        }

        //
        public void CheckConstant()
        {
            //getBitmap -> Ralf

            //getDetected(Bild Ralf) -> ProduktDictionary von Can

            //zeit ticker

            //getDetected -> bool
            //getValidProduct -> Product

            //Warenkorb:
            //Produkte bearbeiten 
            //Sortiment 
            //Sortiment speichern
        }

        private ObservableCollection<Article> entries; 

        public ObservableCollection<Article> Entries 
        {
            get { return entries; }
            set { entries = value; }
        }

        public void UpdateTotalPrice()//Aktualisiert die Gesamtpreisausgabe 
        {
            double price = 0;
            foreach (Article ar in Entries)
            {
                price += ar.TotalPrice;
            }
            priceTextBlock.Text = price.ToString();

            //////////////////////////ToChange
        }

        /// <summary>
        /// Wird gerade noch manuell getriggert werden (über Textboxen für Name und Preis)
        /// Hier soll später die Bilderkennung nur ein Produkt übergeben, welches dann in der Warenkorb hzugefügt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, RoutedEventArgs e) 
        {
            //check if Article exists in ShoppingBasket
            bool exists = false;
            foreach (Article ar in Entries)
                if(ar.Name == textBoxName.Text)
                {
                    exists = true;
                    ar.Quantity++;
                    ar.TotalPrice += ar.Price; 
                }

            if (!exists)
            {
                Article newItem = new Article
                {
                    Quantity = 1,
                    Name = textBoxName.Text,
                    Price = double.Parse(textBoxPrice.Text),
                    TotalPrice = double.Parse(textBoxPrice.Text)
                };

                Entries.Add(newItem);
            }

            textBoxName.Clear();
            textBoxPrice.Clear();

            UpdateTotalPrice();

            //////////////////////////ToChange
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) //nur zu testzwecken, später in der Minusfunktion inbegriffen //ToChange
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;
            Entries.Remove(item);

            UpdateTotalPrice();

            //////////////////////////ToChange
        }

        private void deleteShoppingBasketButton_Click(object sender, RoutedEventArgs e) //löscht den gesamten ShoppingBasket //ToChange
        {
            Entries.Clear();

            UpdateTotalPrice();

            //////////////////////////ToChange
        }

        //Vorerst nur für Stück Produkte
        private void plusButton_Click(object sender, RoutedEventArgs e) //erhöht Stückzahl und automatisch Preis Update //ToChange
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;
            Entries[Entries.IndexOf(item)].Quantity++;
            Entries[Entries.IndexOf(item)].TotalPrice += Entries[Entries.IndexOf(item)].Price; 

            UpdateTotalPrice();

            //////////////////////////ToChange
        }

        private void minusButton_Click(object sender, RoutedEventArgs e) //vermindert Stückzahl und Preis 
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;
            Entries[Entries.IndexOf(item)].Quantity--;
            Entries[Entries.IndexOf(item)].TotalPrice -= Entries[Entries.IndexOf(item)].Price; 

            if (Entries[Entries.IndexOf(item)].Quantity == 0) //Wenn 0 dann löschen
                Entries.Remove(item);
         
            UpdateTotalPrice();

            //////////////////////////ToChange
        }

        private void tryScreenButton_Click(object sender, RoutedEventArgs e)
        {
            NewWindow newWindow = new NewWindow();
            newWindow.Show();
        }
    }
}
