using SaveWorldController;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for DisasterPage.xaml
    /// </summary>
    public partial class DisasterPage : Page
    {
        public int usernId;
        public int userBankAccId=0;
        public int userType;
        public int[] userInfoData = new int[3];
        DisasterReferences.DisasterB d = new DisasterReferences.DisasterB();
        BankAccountService.BankAccountB disasterAcc = new BankAccountService.BankAccountB();
        DisasterReferences.DisasterServiceClient disClient = new DisasterReferences.DisasterServiceClient();
        BankAccountService.BankAccountServiceClient bankClient = new BankAccountService.BankAccountServiceClient();
        string disSelect="";

        BankAccountService.BankAccountB userAcc = new BankAccountService.BankAccountB();
        
        public DisasterPage()
        {
            InitializeComponent();
            loadAllDisasters();
            Info_label.Content = "The user who has his aim and he know exactly the disaster that he want to donate he can just \r\n" +
                "click on the choosen disaster and insert the amount that he want to donate\r\n" +
                "and the amount will be translated directly from his bank account\r\n" +
                "to the disaster bank account.  ";
          
        }

        public DisasterPage(int[] userInfo) : this()
        {
            usernId = userInfo[0];
            userBankAccId = userInfo[1];
            userType = userInfo[2];

            userInfoData[0] = userInfo[0];
            userInfoData[1] = userInfo[1];
            userInfoData[2] = userInfo[2];
            if (userBankAccId != 0)
            {
                userAcc = bankClient.GetBankAccountById(userBankAccId);
            }
        }

        private void loadAllDisasters()
          {
          

              string result = "";

                  var sb = new StringBuilder();
                 foreach(DisasterReferences.DisasterB d in disClient.GetAllDisasters())
                  {
                        sb.Append(d.Name);

                        result = sb.ToString();
                        listBox_allDis.Items.Add(result);
                        result = "";
                        sb.Clear();

                  }

                 
        }

        private void ListBox_allDis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox_allDis.SelectedItem != null)
            {

                disSelect = (string)listBox_allDis.SelectedItem;
                d = disClient.GetDisasterByName(disSelect);
                txt_description.Text = d.Description;
                txt_category.Text = d.CategoryId.ToString();
                txt_priority.Text = d.Priority.ToString();
                txt_region.Text = d.Region;
                txt_victims.Text = d.Victims.ToString();
             
                disasterAcc = bankClient.GetBankAccountById(d.DisasterBankAccountId);
            }
        }

        

        private void btn_donateClick(object sender, RoutedEventArgs e)
        {

            if (disSelect=="")
            {
                MessageBox.Show("You have to choose specific disaster!");
                return;
            }
            if (txt_amount.Text=="")
            {
                MessageBox.Show("You have to insert the amount for donation!");
                return;
            }
            if (usernId == 0)
            {
                MessageBox.Show("You have to log in before donation!");
                return;
            }
            decimal amount = 0;
            amount = decimal.Parse(txt_amount.Text);

           

            if (amount > userAcc.Amount)
            {
                MessageBox.Show("You don't haave enough money. Change the amount!");
                return;
            }

            //bool donate=bankClient.donateToSpecificDisaster(amount, userAcc, disasterAcc);
            BankAccountService.BankAccountServiceClient bankCliente = new BankAccountService.BankAccountServiceClient();
            userAcc.Amount = userAcc.Amount - amount;
            bool updatedUserAcc = bankCliente.Update(userAcc);
            if (!updatedUserAcc)
            {
                MessageBox.Show("Failed donation!It can not update user account! Your page will be refreshed!");
                this.Content = null;
                DisasterPage refreshPage = new DisasterPage(userInfoData);
                NavigationService.Navigate(refreshPage);
                return;
            }
            userAcc = bankCliente.GetBankAccountById(userBankAccId);
            disasterAcc.Amount = disasterAcc.Amount + amount;
            bool updatedDisasterAcc = bankCliente.Update(disasterAcc);
            
            if (!updatedDisasterAcc)
            {
                MessageBox.Show("Failed donation!It can not update disaster account! Your page will be refreshed!");
                this.Content = null;
                DisasterPage refreshPage = new DisasterPage(userInfoData);
                NavigationService.Navigate(refreshPage);
                return;
            }
            disasterAcc = bankCliente.GetBankAccountById(disasterAcc.AccountId);
            if (updatedDisasterAcc == true && updatedUserAcc ==true)
            {
                MessageBox.Show("Donation is succesful!");
            }
          
            txt_amount.Text = "";

        }

    }
}
