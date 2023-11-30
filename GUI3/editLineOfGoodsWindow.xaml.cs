using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaktionslogik für editLineOfGoodsWindow.xaml
    /// </summary>
    public partial class editLineOfGoodsWindow : Window
    {
        public editLineOfGoodsWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            addProductToLineOfGoodsWindow addProductToLineOfGoodsWindow = new addProductToLineOfGoodsWindow();
            addProductToLineOfGoodsWindow.Show();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            searchProductInLineOfGoodsWindow searchProductInLineOfGoodsWindow = new searchProductInLineOfGoodsWindow();
            searchProductInLineOfGoodsWindow.Show();
        }
    }
}
