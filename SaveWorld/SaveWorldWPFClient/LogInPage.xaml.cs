using SaveWorldController;
using SaveWorldWPFClient.UserService;
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
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public string[] userInfo = new string[3];
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
            string userEmail = txt_email.Text;
            string originalPassword = psw_password.Password;

            var myUser = new UserClient();

            // UserCtr myUser = new UserCtr();
            UserB usr = myUser.CheckLogin(userEmail, originalPassword);
            if (usr != null)
            {
                string userIdS = usr.UserId.ToString();
                userInfo[0] = userIdS;
                string userBankAccIdS = ""+usr.BankAccountId;
                MessageBox.Show(userBankAccIdS);
                userInfo[1] = userBankAccIdS;
                string userTypeS = usr.TypeOfUser.ToString();
                userInfo[2] = userTypeS;


                int userId = usr.UserId;
                string name = usr.Name;
                int typeOfUser = usr.TypeOfUser;
                int accId = usr.BankAccountId;
              

                MessageBox.Show(userId + " " + name + " " + typeOfUser + " "+accId);
            }
            else
            {
                MessageBox.Show("You entered wrong password or email. Try again!");
            }


            this.Content = null;
            MainPage main = new MainPage(userInfo);

            // HomePage main = new HomePage(userInfo);

            NavigationService.Navigate(main);

            main.btn_logOut.Visibility = Visibility.Visible;
            main.btn_log.Visibility = Visibility.Visible;

        }
    }
}
