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
using SaveWorldWPFClient.UserService;

namespace SaveWorldWPFClient
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    /// 

    public partial class RegistrationPage : Page
    {
        private UserClient client = new UserClient();
        private string[] userInfo = new string[3];
        public RegistrationPage()
        {
            InitializeComponent();
        }

        public string name;
        public string email;
        public string pas;
        public string address;
        public string phone;
        private void btn_createProfile(object sender, RoutedEventArgs e)
        {
            var newUser = CreateNewUser();
         
           
            userInfo[0] = newUser.UserId.ToString();
            userInfo[1] = newUser.Name;
            MessageBox.Show(userInfo[1]);
            userInfo[2] = newUser.Email;

             client.CreateUser(newUser);
            //client.AddUser(name, pas, 2, email, address, phone);
            this.Content = null;
            MainPage main = new MainPage(userInfo);

            // HomePage main = new HomePage(userInfo);

            NavigationService.Navigate(main);
        }

        private UserService.User CreateNewUser()
        {
            UserService.User newOne = new UserService.User();
            BankAccountService.BankAccount bankData = new BankAccountService.BankAccount();

            if (txt_name != null)
            {
                newOne.Name = txt_name.Text;
                name = txt_name.Text;
            }
            if (txt_pass != null && txt_confPass != null)
            {
                if (txt_pass.Password == txt_confPass.Password)
                {
                    newOne.Password = txt_pass.Password;
                    pas = txt_pass.Password;
                }
                else
                {
                    MessageBox.Show("The passwords not match!");
                }

            }
            if (txt_email != null)
            {
                newOne.Email = txt_email.Text;
                email = txt_email.Text;
            }

            if (txt_address != null)
            {
                newOne.Address = txt_address.Text;
                address = txt_address.Text;
            }
            if (txt_phone != null)
            {
                newOne.Phone = txt_phone.Text;
                phone = txt_phone.Text;
            }
            return newOne;

        }
    }
}
