﻿using SaveWorldWPFClient.ProductService;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        string prodSelect = "";
        ProductService.ProductServiceClient prodClient = new ProductService.ProductServiceClient();
        ProductService.ProductB product = new ProductService.ProductB();

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

        private void txt_prodList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txt_prodList.SelectedItem != null)
            {
                prodSelect = (string)txt_prodList.SelectedItem;
                product = prodClient.GetProductByName(prodSelect);
                txt_Name.Text = product.ProductName;
                txt_Price.Text = product.Price.ToString();
                txt_ProductDescription.Text = product.ProductDescription;
                txt_Stock.Text = product.Stock.ToString();
                //txt_Size.Text = product.Size;
            }
        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prodClient.DeleteProduct(product.ProductId);
            MessageBox.Show(product.ProductId + " was deleted!");//or this MessageBox.Show(product.ProductName + " was deleted!");
            txt_prodList.Items.Clear();
            loadAllProducts();
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            ProductService.ProductB productUpdated = new ProductService.ProductB();
            productUpdated.ProductId = product.ProductId;
            productUpdated.ProductName = txt_Name.Text;
           
            productUpdated.Price = decimal.Parse(txt_Price.Text);
            productUpdated.Stock = Int32.Parse(txt_Stock.Text);
            productUpdated.ProductDescription = product.ProductDescription;
           
            //productUpdated.Size = product.Size;
            if (product.ProductName != Name)
            {
                if (!prodClient.CheckIfNameExists(txt_Name.Text))
                {
                    product.ProductName = txt_Name.Text;
                }
                else
                {
                    MessageBox.Show("This name already exists!");
                }
            }
            else
            {
                productUpdated.ProductName = txt_Name.Text;
            }
            bool updated = prodClient.UpdateProduct(productUpdated);
            if (updated)
            {
                MessageBox.Show("Product was updated!");
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
            txt_prodList.Items.Clear();
            loadAllProducts();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txt_Name.Text = "";
            txt_ProductDescription.Text = "";
            txt_Price.Text = "";
            txt_Stock.Text = "";
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Name.Text == "" || txt_ProductDescription.Text == "" || txt_Price.Text == "" || txt_Stock.Text == "")
            {
                MessageBox.Show("Fill all the fields!");
                return;
            }

            bool created = false;
            ProductService.ProductB product = new ProductService.ProductB();
            product.ProductName = txt_Name.Text;
            product.ProductDescription = txt_ProductDescription.Text;
            product.Price = Decimal.Parse(txt_Price.Text, NumberStyles.AllowDecimalPoint |  NumberStyles.AllowThousands | NumberStyles.AllowCurrencySymbol);
            product.Stock = Int32.Parse(txt_Stock.Text);

            created = prodClient.CreateProduct(product);
            if (created)
            {
                MessageBox.Show("The new product has been created!");
            }
            else
            {
                MessageBox.Show("The name of the product already exists!");
                return;
            }

            txt_Name.Text = "";
            txt_ProductDescription.Text = "";
            txt_Price.Text = "";
            txt_Stock.Text = "";
            txt_prodList.Items.Clear();
            loadAllProducts();
        }       
    } 
}
