﻿using assignment2EAD.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace assignment2EAD.View
{
    /// <summary>
    /// Interaction logic for allProductsWindow.xaml
    /// </summary>
    public partial class allProductsWindow : Window
    {
        public allProductsWindow(adminMain adminMain)
        {
            InitializeComponent();
            this.DataContext = adminMain.DataContext;
        }
    }
}