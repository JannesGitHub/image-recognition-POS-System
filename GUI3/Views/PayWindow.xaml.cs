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
    /// Interaktionslogik für PayWindow.xaml
    /// </summary>
    public partial class PayWindow : Window
    {
        public PayWindow()
        {
            DataContext = this;

            //PriceToPay.Text = MainWindow.priceTextBlock.Text;
            //check ChatGPT latest Chat to fix the problem

            InitializeComponent();
        }

    }
}
