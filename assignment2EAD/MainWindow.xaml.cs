
using assignment2EAD.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace assignment2EAD
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

        private void adminBtn_Click(object sender, RoutedEventArgs e)
        {
            adminMain adMain = new adminMain();
            adMain.Show();
        }

        private void customerBtn_Click(object sender, RoutedEventArgs e)
        {
            customerMain cMain = new customerMain();
            cMain.Show();
        }
    }
}
