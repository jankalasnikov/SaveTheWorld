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
        public int usernId;
        public int userBankAccId;
        public int userType;

        OrderLineService.OrderLineServiceClient orderLineClient = new OrderLineService.OrderLineServiceClient();
        ProductService.ProductServiceClient prodClient = new ProductService.ProductServiceClient();
        ProductService.ProductB productLine = new ProductService.ProductB();
        // ProductService.ProductB prodSelect = new ProductService.ProductB();
        string prodSelect;
        string removeOrderLine;
        List<OrderLineService.OrderLine> orderLinesToOrder = new List<OrderLineService.OrderLine>();

        //OrderServiceReference.OrderServiceClient orderClient = new OrderServiceReference.OrderServiceClient();
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

        public ShopPage(int[] userInfo) : this()
        {
            usernId = userInfo[0];
            userBankAccId = userInfo[1];
            userType = userInfo[2];
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
                result = "";
                sb.Clear();
            }
        }
        
      
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {

                prodSelect = (string)listBox.SelectedItem;
                productLine = prodClient.GetProductByName(prodSelect);
                txt_describtion.Text = productLine.ProductDescription;
                txt_price.Text = productLine.Price.ToString();
                txt_stock.Text = productLine.Stock.ToString();
                //  txt_size.Text = prodSelect.Size;

            }
        }

        /*  private void Button_Click(object sender, RoutedEventArgs e)
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
          }*/

        

      

        private void Button_Add(object sender, RoutedEventArgs e)
        {

            if (prodSelect == null)
            {
                MessageBox.Show("You have to choose product!");
                return;
            }
            if (txt_quntity.Text == "")
            {
                MessageBox.Show("You have to insert the quantity!");
                return;
            }
            if (usernId == 0)
            {
                MessageBox.Show("You have to log in before make an order!");
                return;
            }

            OrderLineService.OrderLine orderLine = new OrderLineService.OrderLine(); 
            OrderLineService.OrderLine returnOrderLine = new OrderLineService.OrderLine();

            int prodId = productLine.ProductId;
            int quantity = Int32.Parse(txt_quntity.Text);
            if(quantity>productLine.Stock)
            {
                MessageBox.Show("The quntity is more than the product stock!");
                return;
            }
            prodClient.RemoveStockFromProduct(prodId, quantity);
            orderLine.Price = productLine.Price * quantity;
            orderLine.ProductID = prodId;
            orderLine.Quantity = quantity;
            returnOrderLine = orderLineClient.CreateOrderLine(orderLine);
            orderLinesToOrder.Add(returnOrderLine);

            
            listBox_OrderLines.Items.Clear();
            foreach (OrderLineService.OrderLine ol in orderLinesToOrder)
            {

                string result = "";
                var sb = new StringBuilder();
                ProductService.ProductServiceClient prodClient = new ProductService.ProductServiceClient();
                ProductService.ProductB prod = new ProductService.ProductB();
                prod = prodClient.GetProduct(ol.ProductID);
                sb.Append(ol.OrderLineId+". "+prod.ProductName + " "+ol.Quantity+"x"+prod.Price);

                result = sb.ToString();
                listBox_OrderLines.Items.Add(result);
                result = "";
                sb.Clear();
               
            }
            txt_quntity.Text = "";
            txt_stock.Text = "";
            txt_price.Text = "";
            txt_describtion.Text = "";
            listBox.SelectedItem = null;
           
           
        }


        private void ListBox_OrderLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idOfOrder = "";


                if (listBox_OrderLines.SelectedItem != null)
                {
               
                    removeOrderLine = (string)listBox_OrderLines.SelectedItem;
                    int indexDot = removeOrderLine.IndexOf(".");
                    idOfOrder = removeOrderLine.Substring(0, indexDot);
               
                    

                }
            
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
