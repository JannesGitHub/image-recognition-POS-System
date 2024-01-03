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
using GUI.MVVM.ViewModel;

namespace GUI.MVVM.View
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

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                // Abrufen des DataContext vom Fenster
                var dataContext = (sender as Window)?.DataContext;

                // Überprüfen, ob der DataContext vom erwarteten Typ ist (z.B. Ihr ViewModel-Typ)
                if (dataContext is MainWindowViewModel viewModel)
                {
                    // Rufen Sie den ScanCommand auf
                    viewModel.ScanCommand.Execute(null); // Übergabe von null oder anderen erforderlichen Parametern

                    // Verhindern Sie, dass das Ereignis an andere Steuerelemente weitergeleitet wird
                    e.Handled = true;
                }
            }
        }
    }
}
