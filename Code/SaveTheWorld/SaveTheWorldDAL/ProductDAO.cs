using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveTheWorld;
using SaveTheWorldModelL;

namespace SaveTheWorldDAL
{
    public class ProductDAO
    {
        public Product GetProduct(int id)
        {
            Product productBase= null;
            using (var NWEntities = new SaveTheWorldEntities())
            {
                var product = (from p in NWEntities.product
                               where p.id == id
                               select p).FirstOrDefault();
                if (product != null)
                    productBase = new Product()
                    {
                        ProductId = product.id,
                        ProductName = product.productName,
                        Price = product.price,
                        ProductDescription = product.description,
                        Stock = (int)product.minStock
                    };
            }
            return productBase;
        }

        public bool UpdateProduct(
            ref Product product,
            ref string message)
        {
            message = "product updated successfully";
            var ret = true;

            using (var NWEntities = new SaveTheWorldEntities())
            {
                var productID = product.ProductId;
                var productInDB =
                        (from p
                        in NWEntities.product
                         where p.id == productID
                         select p).FirstOrDefault();
                // check product
                if (productInDB == null)
                {
                    throw new Exception("No product with ID " +
                                        product.ProductId);
                }

                // update product
                productInDB.productName = product.ProductName;
                productInDB.price = product.Price;
                productInDB.description = product.ProductDescription;
                productInDB.minStock = product.Stock;
        

                NWEntities.product.Attach(productInDB);

                /*If Attach is not called, RowVersion (from the database, not from the client) will be used when submitting to the database, even though you have updated its value before submitting to the database. An update will always succeed, but without a concurrency control.*/
                NWEntities.Entry(productInDB).State = System.Data.Entity.EntityState.Modified;

                /*If the object state is not set to Modified, Entity Framework will not honor your changes to the entity object and you will not be able to save any of the changes to the database.*/
                var num = NWEntities.SaveChanges();

                //product.RowVersion = productInDB.RowVersion;

                if (num != 1)
                {
                    ret = false;
                    message = "no product is updated";
                }
            }
            return ret;
        }
    }
}
