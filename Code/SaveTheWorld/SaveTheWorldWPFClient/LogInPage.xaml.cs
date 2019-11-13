using SaveTheWorldController;
using SaveTheWorldModelL;
using SaveTheWorldWPFClient.UserRef;
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
        private string[] userInfo = new string[3];
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

            var myUser = new UserServiceClient();
           
              //  UserCtr myUser = new UserCtr();
                User usr = myUser.CheckLogin(userEmail, originalPassword);
            if (usr != null)
            {
                // Get the user unique ID from the database and save it to send as an argument
                int userId = usr.UserId;
                string userIdS = userId.ToString();
                userInfo[0] = userIdS;

                // Username to send as an argument
                userInfo[1] = usr.Name;
                string name = usr.Name;


                // Get the type of user from the database and save it to send as an argument
                int typeOfUser = usr.TypeOfUser;
                string typeOfUserS = typeOfUser.ToString();
                userInfo[2] = typeOfUserS;

                MessageBox.Show(userId + name + typeOfUserS);
            }
            else
            {
                MessageBox.Show("You entered wrong password or email. Try again!");
            }


                this.Content = null;
                MainPage main = new MainPage(userInfo);
          
              // HomePage main = new HomePage(userInfo);
           
                NavigationService.Navigate(main);

        }

    }
    
}
