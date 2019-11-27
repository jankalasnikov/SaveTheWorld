using SaveWorldController;
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
        int[] userInfoData = new int[3];
        public int userId;
        public int userBankAccId;
        public int userType;
        public MainPage(string[] userInfo) : this()
        {
            userId = Int32.Parse(userInfo[0]);
            userBankAccId = Int32.Parse(userInfo[1]);
            userType = Int32.Parse(userInfo[2]);

            userInfoData[0] = userId;
            userInfoData[1] = userBankAccId;
            userInfoData[2] = userType;
            
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
           
        }


        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            string name = GetUserName(userId);
            user_name.Content = name;
        }

        private void btn_Shop(object sender, RoutedEventArgs e)
        {
            ShopPage shopPage = new ShopPage();
            mainFrame.Navigate(shopPage);

        }
        private void btn_Disaster(object sender, RoutedEventArgs e)
        {
            DisasterPage disasterPage = new DisasterPage(userInfoData);
            mainFrame.Navigate(disasterPage);

        }
        private void btn_Subscription(object sender, RoutedEventArgs e)
        {
            SubscriptionPage subscriptionPage = new SubscriptionPage();
            mainFrame.Navigate(subscriptionPage);

        }

        private void btn_LogIn(object sender, RoutedEventArgs e)
        {
            LogInPage page1 = new LogInPage();
            mainFrame.Content = null;
            mainFrame2.Navigate(page1);

        }

        private void btn_LogOut(object sender, RoutedEventArgs e)
        {
           
            this.Content = null;
            MainPage main = new MainPage();
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
       
        private string GetUserName(int id)
        {
            UserService.UserClient client = new UserService.UserClient();
            string name = "";
            UserService.UserB user = new UserService.UserB();
            user = client.GetUser(id);
            name = user.Name;
            return name;
        }

      

        private void Btn_manage_Click(object sender, RoutedEventArgs e)
        {
            ManageWindow manage = new ManageWindow();
            manage.Show();

        }

        private void Btn_profile_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profile = new ProfileWindow(userInfoData);
            profile.Show();

        }
    }
}
