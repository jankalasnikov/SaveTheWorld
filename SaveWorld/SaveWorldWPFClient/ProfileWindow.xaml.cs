using SaveWorldService;
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
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();
           
        }

        UserService.UserClient client = new UserService.UserClient();
        BankAccountService.BankAccountServiceClient bankClient = new BankAccountService.BankAccountServiceClient();

        public int userId;
        public int userBankAccId;
        public int userType;
        public string currentEmail;
        public ProfileWindow(int[] userInfo) : this()
        {
            userId = userInfo[0];
            userBankAccId = userInfo[1];
            userType = userInfo[2];
            loadAllData();
          
        }
       

        private void loadAllData()
        {
            UserService.UserB user = new UserService.UserB();
            BankAccountService.BankAccountB account = new BankAccountService.BankAccountB();
            account = bankClient.GetBankAccountById(userBankAccId);
            user = client.GetUser(userId);
            txt_profileName.Text = user.Name;
            txt_profileEmail.Text = user.Email;
            currentEmail = user.Email;
            txt_profileAddress.Text = user.Address;
          
            txt_profilePhone.Text = user.Phone;

            txt_profileBankNumber.Text = account.AccountNo.ToString();
            txt_profileCCv.Text = account.CCV.ToString();
            txt_profileExpiryDate.Text = account.ExpiryDate.ToString();

        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            
            UserService.UserB user = new UserService.UserB();
            user.UserId = userId;
            user.Name = txt_profileName.Text;
           
            user.Address = txt_profileAddress.Text;
            user.Phone = txt_profilePhone.Text;
            if (txt_profileEmail.Text != currentEmail)
            {
                if (!client.CheckEmailIfExists(txt_profileEmail.Text))
                {
                    user.Email = txt_profileEmail.Text;
                }
                else
                {
                    MessageBox.Show("This email already exists!");
                    return;
                }
            }
            else
            {
                user.Email = txt_profileEmail.Text;
            }

            if (txt_profilePassword.Text==txt_profileConfirmPass.Text)
            {
                user.Password = txt_profileConfirmPass.Text;
            }
            else
            {
                MessageBox.Show("Passwords are not match!");
                return;
            }
            int bankNo = Int32.Parse(txt_profileBankNumber.Text);
            DateTime expiryDate = Convert.ToDateTime(txt_profileExpiryDate.Text);
            int CCV = Int32.Parse(txt_profileCCv.Text);
            
            if(bankClient.CheckBankAccount(bankNo, expiryDate, CCV))
            {
                user.BankAccountId = GetIdOfTheBankAccount();
            }
            else
            {
                MessageBox.Show("Wrong Bank Account Information!");
                return;
            }
            
           bool updated = client.UpdateUser(user);
            if(updated)
            {
                MessageBox.Show("Your profile was updated!");
                txt_profileConfirmPass.Text = "";
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private int GetIdOfTheBankAccount()
        {
            BankAccountService.BankAccountServiceClient bankClient = new BankAccountService.BankAccountServiceClient();
            BankAccountService.BankAccountB bankOb = new BankAccountService.BankAccountB();



            int bankNo = Int32.Parse(txt_profileBankNumber.Text);

            bankOb = bankClient.GetBankAccount(bankNo);
            int accId = bankOb.AccountId;
            return accId;

        }

       
    }
}
