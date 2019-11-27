
using SaveWorldDAL;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldController
{
    public class UserCtr
    {
        public UserB GetUser(int id)
        {
            UserB userData = null;
            using (var NWEntities = new SaveWorldEntities())
            {
               
                var user = (from p in NWEntities.Ausers
                                where p.id == id
                                select p).FirstOrDefault();
                if (user != null)
                    userData = new UserB()
                    {
                        UserId = user.id,
                        Name = user.name,
                        Email = user.email,
                        Password = user.password,
                        Address = user.address,
                        Phone = user.phoneno,
                        TypeOfUser = user.typeOfUser,
                        BankAccountId = (int)user.accountId,

                    };
            }
            return userData;
           
        }


        public int GetUserIDByName(string name)
        {
            int id = 0;
            using (var NWEntities = new SaveWorldEntities())
            {

                var user = (from p in NWEntities.Ausers
                            where p.name == name
                            select p).FirstOrDefault();
                if (user != null)
                {
                    id = user.id;
                }
            }
            return id;

        }


        public void AddUser(string name, string password, int typeOfUser, string email, string address, string phone, int bankAcc)
        {
           
            using (SaveWorldEntities dbEntities = new SaveWorldEntities())

            {
                try
                {
                    auser user = new auser()
                {

                   name = name,
                    email = email,
                    password = password,
                    address = address,
                    phoneno = phone,
                    typeOfUser = typeOfUser,
                    accountId = bankAcc,
                };

                dbEntities.Ausers.Add(user);
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

        public void CreateUser(UserB newUser)
        {

            using (SaveWorldEntities dbEntities = new SaveWorldEntities())

            {

                auser user = new auser()
                {
  
                        name= newUser.Name,
                        email = newUser.Email,
                        password = newUser.Password,
                        address = newUser.Address,
                        phoneno = newUser.Phone,
                        typeOfUser = 1,
                        accountId = newUser.BankAccountId,
                };

                    dbEntities.Ausers.Add(user);

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


        public UserB CheckLogin(string userEmail, string password)
        {

            UserB userCorrect = null;
            using (var NWEntities = new SaveWorldEntities())
            {
               

                var user = NWEntities.Ausers
                       .FirstOrDefault(u => u.email == userEmail
                        && u.password == password);

                if (user != null)
                {
                    userCorrect = new UserB()
                    {
                        UserId = user.id,
                        Name = user.name,
                        Password = user.password,
                        Email = user.email,
                        Address = user.address,
                        Phone = user.phoneno,
                        TypeOfUser = user.typeOfUser,
                        BankAccountId = (int)user.accountId,

                    };
                }
                /*   else
                   {
                       throw new ArgumentNullException("user is null");
                   }
              */

            }

            return userCorrect;
        }

        /*  public void AddUser(User newUser)
          {

              auser usern = null;
              using (SaveWorldEntities dbEntities = new SaveWorldEntities())

              {
                  User user = new User()
                  {
                      UserId = newUser.UserId,
                      Name = newUser.Name,
                      Email = newUser.Email,
                      Password = newUser.Password,
                      Address = newUser.Address,
                      Phone = newUser.Phone,
                      TypeOfUser = newUser.TypeOfUser,
                  };
                  dbEntities.Ausers.Add(usern);
                  dbEntities.SaveChanges();
              }
          }*/
    }
}
