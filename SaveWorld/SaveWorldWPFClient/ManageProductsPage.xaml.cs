using SaveWorldWPFClient.ProductService;
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
    /// Interaction logic for ManageProductsPage.xaml
    /// </summary>
    public partial class ManageProductsPage : Page
    {
        ProductService.ProductServiceClient prodClient = new ProductService.ProductServiceClient();
        public ManageProductsPage()
        {
            InitializeComponent();
            loadAllProducts();
        }

        private void loadAllProducts()
        {
            string result = "";

            var sb = new StringBuilder();
            foreach (ProductService.ProductB d in prodClient.GetAllProduct())
            {
                sb.Append(d.ProductName);

                result = sb.ToString();
                txt_prodList.Items.Add(result);
                result = "";
                sb.Clear();

            }

        }
    }
}
