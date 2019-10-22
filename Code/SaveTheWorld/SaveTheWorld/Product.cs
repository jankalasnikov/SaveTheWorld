using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld
{
    class Product
    {
        private String name { get; set; }
        private double price { get; set; }
        private String itemDescription { get; set; }
        private int stock { get; set; }

        public Product()
        {

        }

        public Product(String name, double price, String itemDescription, int stock)
        {
            this.name = name;
            this.price = price;
            this.itemDescription = itemDescription;
            this.stock = stock;
        }
    }
}
