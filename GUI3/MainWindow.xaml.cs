using System;
using System.Collections.Generic;
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
            InitializeComponent();
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
            ShoppingBasketViewList.Items.Add(textBoxName.Text);
            textBoxName.Clear();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            object item = ShoppingBasketViewList.SelectedItem;
            ShoppingBasketViewList.Items.Remove(item);
        }

        private void deleteShoppingBasketButton_Click(object sender, RoutedEventArgs e)
        {
            ShoppingBasketViewList.Items.Clear();
        }
    }
}
