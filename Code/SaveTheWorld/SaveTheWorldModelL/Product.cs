using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldModelL
{
    [DataContract]
    public class Product
    {

        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public string ProductDescription { get; set; }
        [DataMember]
        public int Stock { get; set; }


        public int productId { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public string productDescription { get; set; }
        public int stock { get; set; }

        public Product(string productName, double price, string productDescription, int stock)
        {
            ProductName = productName;
            Price = price;
            ProductDescription = productDescription;
            Stock = stock;
          
        }
        public Product()
            {

            }

    
    }
    [DataContract]
    public class ProductFault
    {
        [DataMember]
        public string FaultMessage;
        public ProductFault(string msg)
        {
            FaultMessage = msg;
        }
    }
}