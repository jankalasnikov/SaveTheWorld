using SaveTheWorldBDO;
using SaveTheWorldModelL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldDAL
{
    public class ProductDAO
    {
        public Product GetProduct(int id)
        {
            Product productBDO = null;
            using (var dbEntities = new SaveTheWorldEntities())
            {
                var product = (from p in dbEntities.product
                               where p.id == id
                               select p).FirstOrDefault();
                if (product != null)
                    productBDO = new Product()
                    {
                        ProductId = product.id,
                        ProductName = product.productName,
                        Price = product.price,
                        ProductDescription = product.description,
                        Stock = product.minStock,
                      
                    };
            }
            return productBDO;
        }

        public bool UpdateProduct(
            ref Product productBDO,
            ref string message)
        {
            message = "product updated successfully";
            var ret = true;

            using (var dbEntities = new SaveTheWorldEntities())
            {
                var productID = productBDO.ProductId;
                var productInDB =
                        (from p
                        in dbEntities.product
                         where p.id == productID
                         select p).FirstOrDefault();
                // check product
                if (productInDB == null)
                {
                    throw new Exception("No product with ID " +
                                        productBDO.ProductId);
                }

                // update product
                productInDB.productName = productBDO.ProductName;
                productInDB.description = productBDO.ProductDescription;
                productInDB.price = productBDO.Price;
                productInDB.minStock = productBDO.Stock;
                

                dbEntities.product.Attach(productInDB);

                /*If Attach is not called, RowVersion (from the database, not from the client) will be used when submitting to the database, even though you have updated its value before submitting to the database. An update will always succeed, but without a concurrency control.*/
                dbEntities.Entry(productInDB).State = System.Data.Entity.EntityState.Modified;

                /*If the object state is not set to Modified, Entity Framework will not honor your changes to the entity object and you will not be able to save any of the changes to the database.*/
                var num = dbEntities.SaveChanges();

           
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
