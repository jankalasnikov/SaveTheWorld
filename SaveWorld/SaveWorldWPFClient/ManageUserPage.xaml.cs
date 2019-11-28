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
        UserService.UserClient usrClient = new UserService.UserClient(); 
        public ManageUserPage()
        {
            InitializeComponent();
            loadAllUsers(); 
        }

        private void loadAllUsers()
        {
            string result = "";

            var sb = new StringBuilder();
            /*foreach (UserService.UserB d in usrClient.())
            {
                sb.Append(d.Name);

                result = sb.ToString();
                userList.Items.Add(result);
                result = "";
                sb.Clear();

            }*/
        }
    }
}
