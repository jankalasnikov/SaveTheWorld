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
        public DisasterPage()
        {
            InitializeComponent();
            loadAllDisasters();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

          private void loadAllDisasters()
          {
            DisasterReferences.DisasterServiceClient disClient = new DisasterReferences.DisasterServiceClient();

              string result = "";

                  var sb = new StringBuilder();
                 foreach(Disaster d in disClient.GetAllDisasters())
                  {
                      sb.Append("Disaster name: " +
                      d.Name + "\r\n");
                      sb.Append(" ");
                      result = sb.ToString();
                      listBox_allDis.Items.Add(result);
                result = "";
                sb.Clear();

            }

                 
        }
    }
}
