﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using KassenmanagementLibrary;
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

        private Product SelectedProduct { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShoppingBasketViewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
