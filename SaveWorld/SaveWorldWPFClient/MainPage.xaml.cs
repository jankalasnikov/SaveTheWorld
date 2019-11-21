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

namespace SaveWorldWPFClient
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public string username;
        public string usernId;
        public MainPage(string[] userInfo) : this()
        {
            username = userInfo[1];
            usernId = userInfo[0];
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
           


        }


        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            user_name.Content = username;
        }

        private void btn_Shop(object sender, RoutedEventArgs e)
        {
            ShopPage shopPage = new ShopPage();
            // this.Content = page1; it show only the page in tho whole window
            mainFrame.Navigate(shopPage);

        }
        private void btn_Disaster(object sender, RoutedEventArgs e)
        {
            DisasterPage disasterPage = new DisasterPage();
            mainFrame.Navigate(disasterPage);

        }
        private void btn_Subscription(object sender, RoutedEventArgs e)
        {
            LogInPage page1 = new LogInPage();
            // this.Content = page1; it show only the page in tho whole window
            mainFrame.Navigate(page1);

        }

        private void btn_LogIn(object sender, RoutedEventArgs e)
        {
            LogInPage page1 = new LogInPage();
            // this.Content = page1; it show only the page in tho whole window
            mainFrame2.Navigate(page1);

        }

        private void btn_LogOut(object sender, RoutedEventArgs e)
        {
            string[] userInfo = new string[3];
            userInfo[0] = null;
            userInfo[1] = null;
            userInfo[2] = null;

            this.Content = null;
            MainPage main = new MainPage(userInfo);

            // HomePage main = new HomePage(userInfo);

            NavigationService.Navigate(main);

        }

        private void vissibilityForBtnLog()
        {
            btn_log.Visibility = Visibility.Hidden;
        }
        private void vissibilityForBtnLogOut()
        {
            btn_log.Visibility = Visibility.Visible;
        }
    }
}
