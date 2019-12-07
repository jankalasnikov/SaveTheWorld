using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldDAL
{
    public class ProductDAL
    {
        public ProductB GetProduct(int id)
        {
            ProductB prodData = null;
            using (var NWEntities = new SaveWorldEntities())
            {
                var product = (from p in NWEntities.Products
                               where p.id == id
                               select p).FirstOrDefault();
                if (product != null)
                    prodData = new ProductB()
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

        public void RemoveStockFromProduct(int id, int removeQuantity)
        {
            using (SaveWorldEntities dbEntities = new SaveWorldEntities())
            {

                var product = (from p in dbEntities.Products
                               where p.id == id
                               select p).FirstOrDefault();
                if (product != null)
                {
                    product.minStock -= removeQuantity;
                }



                dbEntities.SaveChanges();



            }
        }

        public void ReturnStock(int idOfProduct, int returnQuantity)
        {
            using (SaveWorldEntities dbEntities = new SaveWorldEntities())
            {

                var product = (from p in dbEntities.Products
                               where p.id == idOfProduct
                               select p).FirstOrDefault();
                if (product != null)
                {
                    product.minStock += returnQuantity;
                }



                dbEntities.SaveChanges();


            }
        }

        public ProductB GetProductByName(string name)
        {
            ProductB prodData = null;
            using (var NWEntities = new SaveWorldEntities())
            {
                var product = (from p in NWEntities.Products
                               where p.productName == name
                               select p).FirstOrDefault();
                if (product != null)
                    prodData = new ProductB()
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

        public List<ProductB> GetAllProduct()
        {
            // var db = new SaveWorldEntities();
            //return db.Products.ToList();
            List<ProductB> list = new List<ProductB>();
            using (SaveWorldEntities NWEntities = new SaveWorldEntities())
            {
                var ptx = (from r in NWEntities.Products select r);
                var allRows = NWEntities.Products.ToList();

                for (int i = 0; i < allRows.Count; i++)
                {
                    ProductB pro = new ProductB();
                    pro.ProductName = allRows[i].productName;
                    pro.ProductId = allRows[i].id;
                    pro.ProductDescription = allRows[i].description;
                    pro.Price = allRows[i].price;
                    list.Add(pro);

                }
            }
            return list;
        }

        public bool CheckIfNameExists(string name)
        {
            bool exists = false;
            using (SaveWorldEntities dbEntities = new SaveWorldEntities())
            {
                if (dbEntities.Products.Any(pr => pr.productName == name))
                {
                    exists = true;
                }
            }
            return exists;
        }


        public void DeleteProduct(int id)
        {
            using (var NWEntities = new SaveWorldEntities())
            {
                var product = (from p in NWEntities.Products
                               where p.id == id
                               select p).FirstOrDefault();
                if (product != null)

                {

                    NWEntities.Products.Remove(product);
                    NWEntities.SaveChanges();
                };
            }
        }


        public bool UpdateProduct(ProductB product)
        {
            var updated = true;

            using (var NWEntities = new SaveWorldEntities())
            {
                var productId = product.ProductId;
                var productDatabase =
                        (from p
                        in NWEntities.Products
                         where p.id == productId
                         select p).FirstOrDefault();

                if (productDatabase == null)
                {
                    throw new Exception("No product with ID " + product.ProductId);
                }
                productDatabase.productName = product.ProductName;
                productDatabase.price = product.Price;
                productDatabase.description = product.ProductDescription;
                productDatabase.minStock = product.Stock;


                NWEntities.Products.Attach(productDatabase);

                NWEntities.Entry(productDatabase).State = System.Data.Entity.EntityState.Modified;

                var num = NWEntities.SaveChanges();
            }
            return updated;
        }

        public bool CreateProduct(ProductB newProduct)
        {

            using (SaveWorldEntities dbEntities = new SaveWorldEntities())
            {
                if (dbEntities.Products.Any(o => o.productName == newProduct.ProductName))
                { return false; }


                product Product = new product()
                {
                    productName = newProduct.ProductName,
                    description = newProduct.ProductDescription,
                    price = newProduct.Price,
                    minStock = newProduct.Stock,
                };

                dbEntities.Products.Add(Product);

                dbEntities.SaveChanges();
            }
            return true;
        }
    }
}
