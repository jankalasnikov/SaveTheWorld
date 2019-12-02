﻿using SaveWorldDAL;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldController
{
   public class ProductCtrB
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
                if (dbEntities.Disasters.Any(pr => pr.ProductName == name))
                {
                    exists = true;
                }
            }
            return exists;
        }


        /*  public void AddProduct(int productId, string name, double price, string productDescription, int stock)
          {

              using (SaveWorldEntities dbEntities = new SaveWorldEntities())

              {
                  try
                  {
                      aproduct product = new aproduct()
                      {

                          name = name,
                          price = price,
                          productDescription = productDescription,
                          stock = stock,
                      };

                      dbEntities.Aproduct.Add(product);
                      dbEntities.SaveChanges();


                  }
                  catch (DbEntityValidationException e)
                  {
                      foreach (var eve in e.EntityValidationErrors)
                      {
                          Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                              eve.Entry.Entity.GetType().Name, eve.Entry.State);
                          foreach (var ve in eve.ValidationErrors)
                          {
                              Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                  ve.PropertyName, ve.ErrorMessage);
                          }
                      }
                      throw;
                  }
              }
          }
          public void CreateProduct(Product newProduct)
          {

              using (SaveWorldEntities dbEntities = new SaveWorldEntities())

              {

                  aproduct product = new aproduct()
                  {

                      name = newProduct.Name,
                      price = newProduct.Price,
                      productDescription = newProduct.ProductDescription,
                      stock = newProduct.Stock,
                  };

                  dbEntities.Aproduct.Add(product);

                  try
                  {
                      dbEntities.SaveChanges();
                  }
                  catch (DbEntityValidationException e)
                  {
                      foreach (var eve in e.EntityValidationErrors)
                      {
                          Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                              eve.Entry.Entity.GetType().Name, eve.Entry.State);
                          foreach (var ve in eve.ValidationErrors)
                          {
                              Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                  ve.PropertyName, ve.ErrorMessage);
                          }
                      }

                  }
              }
          }
          */
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
                productDatabase.size = product.Size;

                NWEntities.Products.Attach(productDatabase);

                NWEntities.Entry(productDatabase).State = System.Data.Entity.EntityState.Modified;

                var num = NWEntities.SaveChanges();
            }
            return updated;
        }

    }
}