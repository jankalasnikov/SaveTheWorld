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
    /// Interaction logic for SubscriptionPage.xaml
    /// </summary>
    public partial class SubscriptionPage : Page
    {
        public int usernId;
        public int userBankAccId;
        public int userType;

        string typeSelect = "";

        public SubscriptionPage()
        {
            InitializeComponent();
        }

        public SubscriptionPage(int[] userInfo) : this()
        {
            usernId = userInfo[0];
            userBankAccId = userInfo[1];
            userType = userInfo[2];
        }

        private void Listbox_subType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbox_subType.SelectedItem != null)
            {

                typeSelect = (string)listbox_subType.SelectedItem;
               // productLine = prodClient.GetProductByName(prodSelect);
               

            }
        }
    }
}
