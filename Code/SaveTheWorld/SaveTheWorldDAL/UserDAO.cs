using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveTheWorldModelL;

namespace SaveTheWorldDAL
{
  public  class UserDAO
    {
       
        public User GetUser(int id)
        {
            User userbd = null;
            using (var NWEntities = new SaveTheWorldEntities())
            {
                var user = (from p in NWEntities.auser
                               where p.id == id
                               select p).FirstOrDefault();
               
                if (user != null)
                    userbd = new User()
                    {
                        UserId = user.id,
                        Name = user.name,
                        Password = user.password,
                        Email = user.email,
                        Address = user.address,
                        Phone = user.phoneno,

                    };
            }
            return userbd;
        }

        public User CheckLogin(string userEmail, string password)
        {

            User userbd = new User();
            using (var NWEntities = new SaveTheWorldEntities())
            {
                /* var user = (from p in NWEntities.auser
                             where p.email == userEmail 

                             select p).FirstOrDefault();*/

                var user = NWEntities.auser
                       .FirstOrDefault(u => u.email == userEmail
                        && u.password == password);

                if (user != null)
                    userbd = new User()
                    {
                        UserId = user.id,
                        Name = user.name,
                        Password = user.password,
                        Email = user.email,
                        Address = user.address,
                        Phone = user.phoneno,

                    };
           
              
            }

       return userbd;
	}

        public void AddUser(string name, string password, int typeofUser, string email, string address, string phone)
        {
            User user = new User();
            user.Name = name;
            user.Password = password;
            user.TypeOfUser = typeofUser;
            user.Email = email;
            user.Address = address;
            user.Phone = phone;

           using(SaveTheWorldEntities dbEntities = new SaveTheWorldEntities())

            {

             //   dbEntities.auser.Add(user);
                dbEntities.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {

            using (var NWEntities = new SaveTheWorldEntities())
            {
                var user = (from s1 in NWEntities.auser
                            where s1.id == id
                            select s1).SingleOrDefault();

                //Delete it from memory
                NWEntities.auser.Remove(user);
                //Save to database
                NWEntities.SaveChanges();
            }

        }

        /*  public bool UpdateProduct(
              ref User productBDO,
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

                  //If Attach is not called, RowVersion (from the database, not from the client) will be used when submitting to the database, even though you have updated its value before submitting to the database. An update will always succeed, but without a concurrency control.
                  dbEntities.Entry(productInDB).State = System.Data.Entity.EntityState.Modified;

                  //If the object state is not set to Modified, Entity Framework will not honor your changes to the entity object and you will not be able to save any of the changes to the database.
                  var num = dbEntities.SaveChanges();


                  if (num != 1)
                  {
                      ret = false;
                      message = "no product is updated";
                  }
              } 
              return ret;
          }*/
    }
}
