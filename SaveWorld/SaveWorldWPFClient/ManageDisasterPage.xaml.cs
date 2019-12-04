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
    /// Interaction logic for ManageDisasterPage.xaml
    /// </summary>
    public partial class ManageDisasterPage : Page
    {
        int disAccountId;
        int catId;
        int disAccNo;
        DateTime disAccDate;
        int disAccCCV;
        string disSelect = "";
        string catSelect = "";
        DisasterReferences.DisasterServiceClient disClient = new DisasterReferences.DisasterServiceClient();
        DisasterReferences.DisasterB disaster = new DisasterReferences.DisasterB();
        BankAccountService.BankAccountServiceClient bankClient = new BankAccountService.BankAccountServiceClient();
        CategoryService.CategoryServiceClient categoryClient = new CategoryService.CategoryServiceClient();
        CategoryService.Category categoryB = new CategoryService.Category();

        public ManageDisasterPage()
        {
            InitializeComponent();
            loadAllDisasters();
            loadAllCategories();
        }

        private void loadAllDisasters()
        {


            string result = "";

            var sb = new StringBuilder();
            foreach (DisasterReferences.DisasterB d in disClient.GetAllDisasters())
            {
                sb.Append(d.Name);

                result = sb.ToString();
                txt_AllDisasters.Items.Add(result);
                result = "";
                sb.Clear();
            }
        }

        private void loadAllCategories()
        {


            string result = "";

            var sb = new StringBuilder();
            foreach (CategoryService.Category d in categoryClient.GetAllCategories())
            {
                sb.Append(d.NameOfCategory);

                result = sb.ToString();
                list_AllCategories.Items.Add(result);
                result = "";
                sb.Clear();
            }
        }

       

        private void GetAccountInfo(int accountId)
        {
            BankAccountService.BankAccountB bankAccount = new BankAccountService.BankAccountB();
            bankAccount = bankClient.GetBankAccount(accountId);
            disAccNo = bankAccount.AccountNo;
            disAccDate = bankAccount.ExpiryDate;
            disAccCCV = bankAccount.CCV;
        }

        private void Txt_AllDisasters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txt_AllDisasters.SelectedItem != null)
            {
                disSelect = (string)txt_AllDisasters.SelectedItem;
                disaster = disClient.GetDisasterByName(disSelect);
                disAccountId = disaster.DisasterBankAccountId;
                GetAccountInfo(disAccountId);
                txt_DisasterName.Text = disaster.Name;
                txt_DisasterDescription.Text = disaster.Description;
                txt_Priority.Text = disaster.Priority.ToString();
                txt_Victims.Text = disaster.Victims.ToString();
                txt_Region.Text = disaster.Region;
                txt_accountNo.Text = disAccNo.ToString();
                txt_expiryDate.Text = disAccDate.ToString();
                txt_CCV.Text = disAccCCV.ToString();
                
            }
        }

       
        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {

            DisasterReferences.DisasterB disasterUpdated = new DisasterReferences.DisasterB();
            disasterUpdated.DisasterId = disaster.DisasterId;
            disasterUpdated.Name = txt_DisasterName.Text;
            disasterUpdated.Description = txt_DisasterDescription.Text;
         
            disasterUpdated.Priority = Int32.Parse(txt_Priority.Text);
            disasterUpdated.Victims = Int32.Parse(txt_Victims.Text);
            disasterUpdated.CategoryId = catId;
            disasterUpdated.Region = txt_Region.Text;
            if (txt_DisasterName.Text != Name)
            {
                if (!disClient.CheckNameIfExists(txt_DisasterName.Text))
                {
                    disaster.Name = txt_DisasterName.Text;
                }
                else
                {
                    MessageBox.Show("This name already exists!");
                    return;
                }
            }
            else
            {
                disasterUpdated.Name = txt_DisasterName.Text;
            }

            bool updated = disClient.UpdateDisaster(disasterUpdated);
            if (updated)
            {
                MessageBox.Show("disaster was updated!");
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
            txt_AllDisasters.Items.Clear();
            loadAllDisasters();
        }



        
       

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            disClient.DeleteDisaster(disaster.DisasterId);
            MessageBox.Show(disaster.Name + " was deleted!");
            txt_AllDisasters.Items.Clear();
            loadAllDisasters();
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            txt_DisasterDescription.Text = "";
            txt_DisasterName.Text = "";
            txt_expiryDate.Text = "";
            txt_CCV.Text = "";
            txt_Priority.Text = "";
            txt_Region.Text = "";
            txt_Victims.Text = "";
            txt_accountNo.Text = "";
            txt_category.Text = "";
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (txt_DisasterName.Text == "" || txt_DisasterDescription.Text == "" || txt_Priority.Text== "" || txt_Region.Text == "" || txt_Victims.Text == ""
               || txt_expiryDate.Text == "" || txt_CCV.Text == "" || txt_accountNo.Text == "" || txt_category.Text=="")
            {
                MessageBox.Show("Fill all the fields!");
                return;
            }

            bool created = false;
            DisasterReferences.DisasterB disaster = new DisasterReferences.DisasterB();
            disaster.Name = txt_DisasterName.Text;
            disaster.Description = txt_DisasterDescription.Text;
            disaster.Priority = Int32.Parse(txt_Priority.Text);
            disaster.Victims = Int32.Parse(txt_Victims.Text);
            disaster.Region = txt_Region.Text;
            disaster.CategoryId = categoryB.CatogoryId;

            if(CheckBankAccount())
            {
                disaster.DisasterBankAccountId = GetIdOfTheBankAccount();
            }
            else
            {
                MessageBox.Show("There is no bank account with this information!");
            }

            
            created = disClient.CreateDisaster(disaster);
            if(created)
            {
                MessageBox.Show("The disaster was created!");
            }
            else
            {
                MessageBox.Show("The name of the disaster already exists!");
                return;
            }

            txt_DisasterDescription.Text = "";
            txt_DisasterName.Text = "";
            txt_expiryDate.Text = "";
            txt_CCV.Text = "";
            txt_Priority.Text = "";
            txt_Region.Text = "";
            txt_Victims.Text = "";
            txt_accountNo.Text = "";
            txt_AllDisasters.Items.Clear();
            txt_category.Text = "";
            loadAllDisasters();
        }

        private bool CheckBankAccount()
        {
            if (txt_accountNo.Text == "" || txt_CCV.Text == "" || txt_expiryDate.Text == "")
            {
                MessageBox.Show("Fill all the bank account fields!");
                return false;
            }

            bool validAccount = false;
            int bankNo = 0;
            DateTime expiryDate = new DateTime(2019, 10, 9);
            int CCV = 0;
            BankAccountService.BankAccountServiceClient bankClient = new BankAccountService.BankAccountServiceClient();



            if (txt_accountNo != null)
            {
                try
                {
                    bankNo = Int32.Parse(txt_accountNo.Text);
                }
                catch (Exception)
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
                catch (Exception)

                {
                    MessageBox.Show("Please insert date like this yyyy-mm-yy!");
                    return false;
                }
            }
            if (txt_CCV != null)
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




            validAccount = bankClient.CheckBankAccount(bankNo, expiryDate, CCV);

            if (validAccount != true)
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

            bankOb = bankClient.GetBankAccount(bankNo);
            int accId = bankOb.AccountId;
            return accId;

        }

        private void List_AllCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list_AllCategories.SelectedItem != null)
            {
                catSelect = (string)list_AllCategories.SelectedItem;
                categoryB = categoryClient.GetCategoryByName(catSelect);
                catId = categoryB.CatogoryId;
                txt_category.Text = categoryB.NameOfCategory;
            }
        }
    }
}
