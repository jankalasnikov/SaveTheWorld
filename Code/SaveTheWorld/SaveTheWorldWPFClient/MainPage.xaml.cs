using SaveTheWorldController;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public string username;
        public MainPage(string userName) : this()
        {
            username = userName;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

        }
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            user_name.Content =username;
        }

        private void btn_Shop(object sender, RoutedEventArgs e)
        {
            LogInPage page1 = new LogInPage();
            // this.Content = page1; it show only the page in tho whole window
            mainFrame.Navigate(page1);

        }
        private void btn_Disaster(object sender, RoutedEventArgs e)
        {


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
            mainFrame.Navigate(page1);

        }
    }
}
