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
    /// Interaction logic for ManageUserPage.xaml
    /// </summary>
    public partial class ManageUserPage : Page
    {
        string userSelect = "";
        string currentEmail;
        int userId;
        string password="";
        int accID;
        UserService.UserClient usrClient = new UserService.UserClient();
        UserService.UserB user = new UserService.UserB();
        public ManageUserPage()
        {
            InitializeComponent();
            loadAllUsers(); 
        }

        private void loadAllUsers()
        {
            string result = "";

            var sb = new StringBuilder();
            foreach (UserService.UserB d in usrClient.GetAllUsers())
            {
                sb.Append(d.Name);

                result = sb.ToString();
                userList.Items.Add(result);
                result = "";
                sb.Clear();

            }
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userList.SelectedItem != null)
            {
                userSelect = (string)userList.SelectedItem;
                user = usrClient.GetUserByName(userSelect);
                userId = user.UserId;
                password = user.Password;
                txt_Name.Text = user.Name;
                txt_Email.Text = user.Email;
                currentEmail = user.Email;
                txt_Address.Text = user.Address;
                txt_PhoneNo.Text = user.Phone.ToString();
                txt_TypeOfUser.Text = user.TypeOfUser.ToString();
                accID = user.BankAccountId;

            }
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {

            UserService.UserB user = new UserService.UserB();
            user.Password = password;
            user.UserId = userId;
            user.Name = txt_Name.Text;
            user.BankAccountId = accID;
            user.Address = txt_Address.Text;
            user.Phone = txt_PhoneNo.Text;
            user.TypeOfUser = Int32.Parse(txt_TypeOfUser.Text);
            if (txt_Email.Text != currentEmail)
            {
                if (!usrClient.CheckEmailIfExists(txt_Email.Text))
                {
                    user.Email = txt_Email.Text;
                }
                else
                {
                    MessageBox.Show("This email already exists!");
                    return;
                }
            }
            else
            {
                user.Email = txt_Email.Text;
            }

           
           
          

            bool updated = usrClient.UpdateUser(user);
            if (updated)
            {
                MessageBox.Show("User profile was updated!");
               
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
            userList.Items.Clear();
            loadAllUsers();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            usrClient.DeleteUser(userId);
            MessageBox.Show(user.Name + " was deleted!");
            userList.Items.Clear();
            loadAllUsers();
        }
    }
}
