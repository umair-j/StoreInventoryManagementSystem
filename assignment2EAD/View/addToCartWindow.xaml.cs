using assignment2EAD.ViewModel;
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
    /// Interaction logic for addToCartWindow.xaml
    /// </summary>
    public partial class addToCartWindow : Window
    {
        public addToCartWindow()
        {
            InitializeComponent();
            this.DataContext = new cartViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
