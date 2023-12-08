using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KassenmanagementLibrary;
using System.Windows;
using System.Windows.Media.Imaging;
using Camera;
using System.Timers;
using DetectionLibrary;
using System.Windows.Media.Media3D;
using System.Drawing;
using System.Windows.Input;
using System.Threading.Tasks;
using GUI.ViewModel;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var mainWindowViewModel = ((MainWindowViewModel)DataContext);

            mainWindowViewModel.addManuallyWindow += (s, ev) =>
            {
                addManuallyWindow addManuallyWindow = new addManuallyWindow();
                if(addManuallyWindow.ShowDialog()== true)
                {
                    var addManuallyViewModel = (addManuallyViewModel)addManuallyWindow.DataContext;

                    mainWindowViewModel.shoppingBasketObject.AddArticle(addManuallyViewModel.SelectedProduct);
                }
            };
        }
    }
}
