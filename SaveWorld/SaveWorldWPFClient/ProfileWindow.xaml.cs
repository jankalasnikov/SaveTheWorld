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
            txt_profileAddress.Text = user.Address;
            txt_profilePassword.Text = user.Password;
            txt_profilePhone.Text = user.Phone;

            txt_profileBankNumber.Text = account.AccountNo.ToString();
            txt_profileCCv.Text = account.CCV.ToString();
            txt_profileExpiryDate.Text = account.ExpiryDate.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            UserService.UserB user = new UserService.UserB();
            user.Name = txt_profileName.Text;
            user.Email = txt_profileEmail.Text;
            user.Address = txt_profileAddress.Text;
            user.Phone = txt_profilePhone.Text;
            if(txt_profilePassword.Text==txt_profileConfirmPass.Text)
            {
                user.Password = txt_profileConfirmPass.Text;
            }
            else
            {
                MessageBox.Show("Passwords are not match!");
                return;
            }
            int bankNo = Int32.Parse(txt_profileBankNumber.Text);
       //     bankClient.CheckBankAccount(bankNo,)
            
            client.UpdateUser(user);
        }
    }
}
