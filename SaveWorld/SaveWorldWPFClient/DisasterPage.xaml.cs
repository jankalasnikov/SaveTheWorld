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
        DisasterReferences.DisasterServiceClient disClient = new DisasterReferences.DisasterServiceClient();
        string disSelect;
        public DisasterPage()
        {
            InitializeComponent();
            loadAllDisasters();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
