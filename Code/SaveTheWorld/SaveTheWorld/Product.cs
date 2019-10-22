using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld
{
        class Product
        {
            private String LName { get; set; }
            private String Name { get; set; }
            private double Price { get; set; }
            private String ItemDescription { get; set; }
            private int Stock { get; set; }

            public Product()
            {

            }

            public Product(String lname, String name, double price, String itemDescription, int stock)
            {
                LName = lname;
                Name = name;
                Price = price;
                ItemDescription = itemDescription;
                Stock = stock;
            }
        }
}
