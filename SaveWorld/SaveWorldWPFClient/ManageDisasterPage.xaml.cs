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

        DisasterReferences.DisasterServiceClient disClient = new DisasterReferences.DisasterServiceClient();

        public ManageDisasterPage()
        {
            InitializeComponent();
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
    }
}
