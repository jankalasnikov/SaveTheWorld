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

namespace SaveWorldWPFClient
{
    /// <summary>
    /// Interaction logic for ManageWindow.xaml
    /// </summary>
    public partial class ManageWindow : Window
    {
        public ManageWindow()
        {
            InitializeComponent();
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManageDisasterPage disPage = new ManageDisasterPage();
            mainFrame.Navigate(disPage);
        }
        private void ManageProd(object sender, RoutedEventArgs e)
        {
            ManageProductsPage managePage = new ManageProductsPage();
            mainFrame.Navigate(managePage);
        }
        private void MangeUsr(object sender, RoutedEventArgs e)
        {
            ManageUserPage usrPage = new ManageUserPage();
            mainFrame.Navigate(usrPage);
        }


    }
}
