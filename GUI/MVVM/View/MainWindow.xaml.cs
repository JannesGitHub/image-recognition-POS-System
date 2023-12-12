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
    }
}
