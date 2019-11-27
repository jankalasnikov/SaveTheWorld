using SaveWorldController;
using SaveWorldModel;
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
    /// Interaction logic for DisasterPage.xaml
    /// </summary>
    public partial class DisasterPage : Page
    {
        //private int[] userInfo = new int[3];
      
        public int usernId;
        public int userBankAccId;
        public int userType;

        DisasterReferences.DisasterServiceClient disClient = new DisasterReferences.DisasterServiceClient();
        BankAccountService.BankAccountServiceClient bankClient = new BankAccountService.BankAccountServiceClient();
        string disSelect="";
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



                DisasterReferences.DisasterB d = new DisasterReferences.DisasterB();
                disSelect = (string)listBox_allDis.SelectedItem;
                d = disClient.GetDisasterByName(disSelect);
                txt_description.Text = d.Description;
                txt_category.Text = d.CategoryId.ToString();
                txt_priority.Text = d.Priority.ToString();
                txt_region.Text = d.Region;
                txt_victims.Text = d.Victims.ToString();

            }
        }

        

        private void btn_donateClick(object sender, RoutedEventArgs e)
        {
            if(disSelect=="")
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
            double amount = 0.0;
            amount = double.Parse(txt_amount.Text);

            DisasterReferences.DisasterB disaster = new DisasterReferences.DisasterB();
            DisasterReferences.DisasterServiceClient disClient = new DisasterReferences.DisasterServiceClient();
            disaster = disClient.GetDisasterByName(disSelect);
            int disasterBankAccId = disaster.DisasterBankAccountId;

            
            bool donate=bankClient.donateToSpecificDisaster(amount, userBankAccId, disasterBankAccId);
            if(donate)
            {
                MessageBox.Show("Donation is succesful!");
            }
            else
            {
                MessageBox.Show("Failed donation!");
            }
            txt_amount.Text = "";

        }
    }
}
