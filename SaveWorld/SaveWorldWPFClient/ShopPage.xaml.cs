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
    /// Interaction logic for ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        public ShopPage()
        {
            InitializeComponent();
            LoadAllProducts();
        }

        private void LoadAllProducts()
        {
            ProductService.ProductServiceClient prodClient = new ProductService.ProductServiceClient();

            string result = "";

            var sb = new StringBuilder();
            foreach (Product d in prodClient.GetAllProduct())
            {
                sb.Append("Product name: " +
                d.ProductName + "\r\n");
                sb.Append(" ");
                result = sb.ToString();
                listBox.Items.Add(result);
                result = "";
                sb.Clear();
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
