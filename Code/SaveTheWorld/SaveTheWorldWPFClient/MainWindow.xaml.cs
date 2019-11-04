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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
