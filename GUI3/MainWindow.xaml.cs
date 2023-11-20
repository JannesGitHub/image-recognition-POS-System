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

        private ObservableCollection<Article> entries;

        public ObservableCollection<Article> Entries
        {
            get { return entries; }
            set { entries = value; }
        }

        public void UpdateTotalPrice()
        {
            double price = 0;
            foreach (Article ar in Entries)
            {
                price += ar.TotalPrice;
            }
            priceTextBlock.Text = price.ToString();
        }

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
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;
            Entries.Remove(item);

            UpdateTotalPrice();
        }

        private void deleteShoppingBasketButton_Click(object sender, RoutedEventArgs e)
        {
            Entries.Clear();

            UpdateTotalPrice();
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;
            Entries[Entries.IndexOf(item)].Quantity++;
            Entries[Entries.IndexOf(item)].TotalPrice += Entries[Entries.IndexOf(item)].Price; //Preis updaten

            UpdateTotalPrice();
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            Article item = (Article)ShoppingBasketViewList.SelectedItem;
            Entries[Entries.IndexOf(item)].Quantity--;
            Entries[Entries.IndexOf(item)].TotalPrice -= Entries[Entries.IndexOf(item)].Price; //Preis updaten

            if (Entries[Entries.IndexOf(item)].Quantity == 0)
                deleteButton_Click(this, e);

            UpdateTotalPrice();
        }
    }
}
