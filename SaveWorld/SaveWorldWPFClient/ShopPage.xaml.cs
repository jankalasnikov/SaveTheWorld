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
         //   LoadAllProducts();
        }

      /*  private void LoadAllProducts()
        {
            ProductService.ProductServiceClient prodClient = new ProductService.ProductServiceClient();
            List<ProductService.Product> allprod = GetAllProduct();
          
            foreach (ProductService.Product prod in allprod)
            {
                listBox.Items.Add(prod.ProductName.ToString());


            }
            listBox.Items.Add("asd");
            listBox.Items.Add("Valentin");
        }
        */
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
