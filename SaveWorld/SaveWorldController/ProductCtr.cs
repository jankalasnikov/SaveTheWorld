using SaveWorldDAL;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldController
{
   public class ProductCtr
    {
        public Product GetProduct(int id)
        {
            Product prodData = null;
            using (var NWEntities = new SaveWorldEntities())
            {
                var product = (from p in NWEntities.Products
                               where p.id == id
                               select p).FirstOrDefault();
                if (product != null)
                    prodData = new Product()
                    {
                        ProductId = product.id,
                        ProductName = product.productName,
                        ProductDescription = product.description,
                        Price = product.price,
                        Stock = product.minStock,
                       
                    };
            }
            return prodData;
        }
    }
}
