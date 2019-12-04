
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


        public UserB GetUserByName(string name)
        {
            UserB userData = null;
            using (var NWEntities = new SaveWorldEntities())
            {
                var user = (from p in NWEntities.Ausers
                           where p.name == name
                           select p).FirstOrDefault();
                if (user != null)
                    userData = new UserB()
                    {
                        UserId = user.id,
                        Name = user.name,
                        Email = user.email,
                        Address = user.address,
                        Phone = user.phoneno,
                        Password = user.password,
                        BankAccountId = (int)user.accountId,
                        TypeOfUser = user.typeOfUser,
                    };
            }
            return userData;
        }

        public List<UserB> GetAllUsers()
        {
            List<UserB> list = new List<UserB>();
            using (SaveWorldEntities NWEntities = new SaveWorldEntities())
            {
                var ptx = (from r in NWEntities.Ausers select r);
                var allRows = NWEntities.Ausers.ToList();

                for (int i = 0; i < allRows.Count; i++)
                {
                    UserB usr = new UserB();
                    usr.Name = allRows[i].name;
                    usr.UserId = allRows[i].id;
                    usr.Email = allRows[i].email;
                    usr.Password = allRows[i].password;
                    usr.Phone = allRows[i].phoneno;
                    usr.BankAccountId = (int)allRows[i].accountId;
                    usr.Address = allRows[i].address;
                    list.Add(usr);

                }
            }
            return list;
        }

        public void DeleteUser(int id)
        {
            using (var NWEntities = new SaveWorldEntities())
            {
                var usr = (from p in NWEntities.Ausers
                               where p.id == id
                               select p).FirstOrDefault();
                if (usr != null)

                {

                    NWEntities.Ausers.Remove(usr);
                    NWEntities.SaveChanges();
                };
            }
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

        public bool CheckEmailIfExists(string email)
        {
            bool exist = false;
            using (SaveWorldEntities dbEntities = new SaveWorldEntities())
            {
                if (dbEntities.Ausers.Any(o => o.email == email))
                {
                    exist = true;
                }
            }
            return exist;
        }

        public void CreateUser(UserB newUser)
        {

            using (SaveWorldEntities dbEntities = new SaveWorldEntities())
            {
                if (dbEntities.Ausers.Any(o => o.email == newUser.Email))
                { return; }

                

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

       /* public bool IsCookieValid(string cookieId)
        {
            CoreValidator.ThrowIfNullOrEmpty(cookieId, nameof(cookieId));
            using (var db = new AuctionContext())
            {
                return db.Users.Any(u => u.RememberToken == cookieId);
            }
        }
        */

        public bool UpdateUser(UserB user)
        {
           
            var updated = true;

            using (var NWEntities = new SaveWorldEntities())
            {
                var userId = user.UserId;
                var userDatabase =
                        (from p
                        in NWEntities.Ausers
                         where p.id == userId
                         select p).FirstOrDefault();
            
                if (userDatabase == null)
                {
                    throw new Exception("No user with ID " +
                                        user.UserId);
                }

                userDatabase.name = user.Name;
                userDatabase.email = user.Email;
                userDatabase.password = user.Password;
                userDatabase.phoneno = user.Phone;
                userDatabase.address = user.Address;
                userDatabase.accountId = user.BankAccountId;

                NWEntities.Ausers.Attach(userDatabase);

               
                NWEntities.Entry(userDatabase).State = System.Data.Entity.EntityState.Modified;

              
                var num = NWEntities.SaveChanges();

               
            }
            return updated;
        }
    }
}
