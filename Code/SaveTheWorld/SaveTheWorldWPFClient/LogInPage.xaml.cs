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

namespace SaveTheWorldWPFClient
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private void btn_registration(object sender, RoutedEventArgs e)
        {
            RegistrationPage regPage = new RegistrationPage();
            // this.Content = page1; it show only the page in tho whole window
            NavigationService.Navigate(regPage);

        }

        private void btn_LogInProfile(object sender, RoutedEventArgs e)
        {
            RegistrationPage regPage = new RegistrationPage();
            // this.Content = page1; it show only the page in tho whole window
            NavigationService.Navigate(regPage);

        }
    }
}
