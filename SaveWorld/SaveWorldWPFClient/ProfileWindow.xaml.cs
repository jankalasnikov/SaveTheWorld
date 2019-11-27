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
            user = client.GetUser(userId);
            txt_profileName.Text = user.Name;
            txt_profileEmail.Text = user.Email;
            txt_profileAddress.Text = user.Address;
            txt_profilePassword.Text = user.Password;
            txt_profilePhone.Text = user.Phone;
        }

       



    }
}
