using GUI.ViewModel;
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
    /// Interaktionslogik für addManuallyWindow.xaml
    /// </summary>
    public partial class addManuallyWindow : Window
    {
        public addManuallyWindow()
        {
            InitializeComponent();

            var vm = this.DataContext as addManuallyViewModel;

            vm.Add += (o, e) => this.DialogResult = true;
        }
    }
}
