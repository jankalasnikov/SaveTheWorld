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

        string disSelect = "";
        DisasterReferences.DisasterServiceClient disClient = new DisasterReferences.DisasterServiceClient();
        DisasterReferences.DisasterB disaster = new DisasterReferences.DisasterB(); 

        public ManageDisasterPage()
        {
            InitializeComponent();
            loadAllDisasters(); 
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

            /* FOR SOME REASON THIS LINE OF CODE DISAPPEARS EACH TIME PROGRAM IS RUN, ITS NECESSARY TO HAVE IT IN ORDER TO LIST THE DISASTER IN TEXT BOXES
             * IT BELONGS TO ManageDisasterPage.g.cs
             * 
            #line 12 "..\..\ManageDisasterPage.xaml"
            this.txt_AllDisasters.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DisasterList_SelectionChanged);

            #line default
            #line hidden
            */

        private void Txt_AllDisasters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txt_AllDisasters.SelectedItem != null)
            {
                disSelect = (string)txt_AllDisasters.SelectedItem;
                disaster = disClient.GetDisasterByName(disSelect);
                txt_DisasterName.Text = disaster.Name;
                txt_DisasterDescription.Text = disaster.Description;
                txt_Priority.Text = disaster.Priority.ToString();
                txt_Victims.Text = disaster.Victims.ToString();
                txt_Region.Text = disaster.Region; 
            }
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {

            //DisasterReferences.DisasterB disaster = new DisasterReferences.DisasterB();
            disaster.Name = txt_DisasterName.Text; 
            disaster.Description = txt_DisasterDescription.Text;
            txt_Priority.Text = disaster.Priority.ToString();
            txt_Victims.Text = disaster.Victims.ToString();
            disaster.Region = txt_Region.Text;           
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
                disaster.Name = txt_DisasterName.Text;
            }

            bool updated = disClient.UpdateDisaster(disaster);
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

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {

            DisasterReferences.DisasterB disasterUpdated = new DisasterReferences.DisasterB();
            disasterUpdated.DisasterId = disaster.DisasterId;
            disasterUpdated.Name = txt_DisasterName.Text;
            disasterUpdated.Description = txt_DisasterDescription.Text;
            txt_Priority.Text = disasterUpdated.Priority.ToString();
            txt_Victims.Text = disasterUpdated.Victims.ToString();
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
    }
}
