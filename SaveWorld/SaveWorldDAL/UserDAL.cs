using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldDAL
{
    public class UserDAL
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
                            Salt=user.salt,
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
                            Salt = user.salt,
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

            public int DeleteUser(int id)
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

                return id;
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


        public string SaltGenerator(int size)
        {
            string salt = "";
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            for (int i = 0; i < size; i++)
                salt += chars[random.Next(chars.Length)];
            return salt;
        }
        //Hashes the input using SHA256
        public string Hasher(string input)
        {
            StringBuilder hash = new StringBuilder();
            System.Security.Cryptography.SHA256Managed sha = new System.Security.Cryptography.SHA256Managed();
            byte[] crypted = sha.ComputeHash(Encoding.UTF8.GetBytes(input), 0, Encoding.UTF8.GetByteCount(input));
            foreach (byte chunk in crypted)
                hash.Append(chunk.ToString("x2"));
            return hash.ToString();
        }
       
        public void CreateUser(UserB newUser)
            {
            string salted = SaltGenerator(10);
            string passHash = Hasher(newUser.Password + salted);

                using (SaveWorldEntities dbEntities = new SaveWorldEntities())
                {
                    if (dbEntities.Ausers.Any(o => o.email == newUser.Email))
                    { return; }



                    auser user = new auser()
                    {

                        name = newUser.Name,
                        email = newUser.Email,
                        password = passHash,
                        salt=salted,
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
                    var user = NWEntities.Ausers.FirstOrDefault(u => u.email == userEmail);
                if (user.password == Hasher(password + user.salt))
                {
                    if (user != null)
                    {
                        userCorrect = new UserB()
                        {
                            UserId = user.id,
                            Name = user.name,
                            Password = user.password,
                            Salt = user.salt,
                            Email = user.email,
                            Address = user.address,
                            Phone = user.phoneno,
                            TypeOfUser = user.typeOfUser,
                            BankAccountId = (int)user.accountId,
                        };
                    }
                }
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
            string salted = SaltGenerator(10);
            string passHash = Hasher(user.Password + salted);

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
                    userDatabase.password = passHash;
                    userDatabase.salt = salted;
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
