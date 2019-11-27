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
        ProductService.ProductServiceClient prodClient = new ProductService.ProductServiceClient();
        // ProductService.ProductB prodSelect = new ProductService.ProductB();
        string prodSelect;
        List<int> productIndexes = new List<int>();

        OrderServiceReference.OrderServiceClient orderClient = new OrderServiceReference.OrderServiceClient();
        public ShopPage()
        {
            InitializeComponent();
            LoadAllProducts();
            //  listBox.Items.AddRange(prodClient.GetAllProduct());

            Information_label.Content = "Everyone who wants to donate money but doesn't know for which disaster, he is more then welcome to our online \r\n" +
                                       "shop where all the money of his purchase will be equally distributed in the \r\n" +
                                       "bank accounts of all disasters. With this option the \r\n" +
                                       "user will help to all of the disasters.";
        }

        private void LoadAllProducts()
        {
           
            string result = "";

            var sb = new StringBuilder();
            foreach (ProductService.ProductB d in prodClient.GetAllProduct())
            {
                sb.Append( d.ProductName);
               
                result = sb.ToString();
                listBox.Items.Add(result);

                productIndexes.Add(d.ProductId);

                result = "";
                sb.Clear();
            }
        }
        
        private void productsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {


                ProductService.ProductB p =new ProductService.ProductB();
                // prodSelect = (ProductService.ProductB)listBox.SelectedItem;
                prodSelect = (string)listBox.SelectedItem;
                p = prodClient.GetProductByName(prodSelect);
                txt_describtion.Text = p.ProductDescription;
                txt_price.Text = p.Price.ToString();
                txt_stock.Text = p.Stock.ToString();
              //  txt_size.Text = prodSelect.Size;
              
            }
        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {


                ProductService.ProductB p = new ProductService.ProductB();
                // prodSelect = (ProductService.ProductB)listBox.SelectedItem;
                prodSelect = (string)listBox.SelectedItem;
                p = prodClient.GetProductByName(prodSelect);
                txt_describtion.Text = p.ProductDescription;
                txt_price.Text = p.Price.ToString();
                txt_stock.Text = p.Stock.ToString();
                //  txt_size.Text = prodSelect.Size;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null && txt_quntity.Text != null)
            {
                int quantity = Convert.ToInt32(txt_quntity.Text);
                int minStock = Convert.ToInt32(txt_stock.Text);
                if (quantity != 0 && quantity <= minStock)
                {
                    int productID = productIndexes[listBox.SelectedIndex];
                    orderClient.AddOrderLine(productID, quantity);
                    ListBoxItem listBoxItem = new ListBoxItem();
                    string content = (listBox.Items[productID] as ListBoxItem).Content.ToString()
                        + " x " + txt_quntity.Text;
                    listBoxItem.Content = content;
                    listBoxItem.Tag = productID;
                    listBox_OrderLines.Items.Add(listBoxItem);
                }
            }
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            int productIDSelected = Convert.ToInt32((listBox_OrderLines.SelectedItem as ListBoxItem).Tag);
            orderClient.RemoveOrderLine(productIDSelected);
            listBox_OrderLines.Items.Remove(listBox_OrderLines.SelectedItem);
        }
    }
}
