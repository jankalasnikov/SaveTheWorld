﻿using System;
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
       /* string regexForEmail = "([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01]))";*/
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

            if(txt_name.Text == "" || txt_pass.Password == "" || txt_confPass.Password == "" || txt_address.Text == "" || txt_email.Text == ""
                || txt_phone.Text == "")
            {
                MessageBox.Show("Fill all the profiles fields!");
                return;
            }
           
            var newUser = CreateNewUser();
            if(newUser==null)
            {
                return;
            }
            BankAccountService.BankAccountB bank = new BankAccountService.BankAccountB();
            BankAccountService.BankAccountServiceClient accountClient = new BankAccountService.BankAccountServiceClient();

            client.CreateUser(newUser);
            int idOfUser = client.GetUserIDByName(newUser.Name);

            /* userInfo[0] = newUser.UserId.ToString();
             userInfo[1] = newUser.BankAccountId.ToString();
             MessageBox.Show(userInfo[1]);
             userInfo[2] = newUser.TypeOfUser.ToString();*/

            string userIdS = idOfUser.ToString();
            userInfo[0] = userIdS;
            string userBankAccIdS = "" + newUser.BankAccountId;
          
            userInfo[1] = userBankAccIdS;
            string userTypeS = newUser.TypeOfUser.ToString();
            userInfo[2] = userTypeS;

           
        
            this.Content = null;
            MainPage main = new MainPage(userInfo);

            NavigationService.Navigate(main);
            main.btn_logOut.Visibility = Visibility.Visible;
            main.btn_log.Visibility = Visibility.Visible;
            main.btn_profile.Visibility = Visibility.Visible;
        }

        private UserService.UserB CreateNewUser()
        {
            UserService.UserB newOne = new UserService.UserB();
            

           

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
               
                email = txt_email.Text;
                if(!client.CheckEmailIfExists(email))
                {
                    newOne.Email = txt_email.Text;
                }
                else
                {
                    MessageBox.Show("This email already exists!");
                }
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
            bool validAccount = CheckBankAccount();
            if (validAccount == true)
            {
                newOne.BankAccountId = GetIdOfTheBankAccount();
                
            }
            else
            {
                return null;
            }
            return newOne;
          

        }

        private bool CheckBankAccount()
        {
            if (txt_accountNo.Text == "" || txt_CCV.Text == "" || txt_expiryDate.Text == "")
            {
                MessageBox.Show("Fill all the bank account fields!");
                return false;
            }

            bool validAccount = false;
            int bankNo=0;
            DateTime expiryDate = new DateTime(2019,10,9);
            int CCV=0;
            BankAccountService.BankAccountServiceClient bankClient = new BankAccountService.BankAccountServiceClient();

            

            if (txt_accountNo != null)
            {
                try
                {
                    bankNo = Int32.Parse(txt_accountNo.Text);
                }
                catch (Exception )
                {
                    MessageBox.Show("Please provide number only");
                    return false;
                }
            }
           
            if (txt_expiryDate != null)
            {
                try
                {
                    expiryDate = Convert.ToDateTime(txt_expiryDate.Text);
                }
                catch (Exception )

                {
                    MessageBox.Show("Please insert date like this yyyy-mm-yy!");
                    return false;
                }
            }
            if(txt_CCV!=null)
            {
                try
                {
                    CCV = Int32.Parse(txt_CCV.Text);
                }
                catch (Exception)

                {
                    MessageBox.Show("Please insert only numbers like this 111!");
                    return false;
                }
            }
          



            validAccount = bankClient.CheckBankAccount(bankNo,expiryDate,CCV);

            if(validAccount!=true)
            { 
                MessageBox.Show("There is no bank account with this information!");
            }
            return validAccount;

        }

        private int GetIdOfTheBankAccount()
        {
            BankAccountService.BankAccountServiceClient bankClient = new BankAccountService.BankAccountServiceClient();
            BankAccountService.BankAccountB bankOb = new BankAccountService.BankAccountB();

          
          
            int bankNo = Int32.Parse(txt_accountNo.Text);
            
            bankOb=bankClient.GetBankAccount(bankNo);
            int accId = bankOb.AccountId;
            return accId;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage();
            NavigationService.Navigate(mainPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            NavigationService.Navigate(logInPage);
        }
    }
}
