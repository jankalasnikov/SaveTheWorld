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
        string disSelect;
        public DisasterPage()
        {
            InitializeComponent();
            loadAllDisasters();
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
            double amount = 0.0;
            amount = double.Parse(txt_amount.Text);

            DisasterReferences.DisasterB disaster = new DisasterReferences.DisasterB();
            DisasterReferences.DisasterServiceClient disClient = new DisasterReferences.DisasterServiceClient();
            disaster = disClient.GetDisasterByName(disSelect);
            int disasterBankAccId = disaster.DisasterBankAccountId;

            MessageBox.Show(userBankAccId.ToString());

            bool donate=bankClient.donateToSpecificDisaster(amount, userBankAccId, disasterBankAccId);
            if(donate)
            {
                MessageBox.Show("Donation is succesful!");
            }
            else
            {
                MessageBox.Show("Failed donation!");
            }

        }
    }
}
