
using SaveWorldDAL;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldController
{
    public class UserCtr
    {
        public User GetUser(int id)
        {
            User userData = null;
            using (var NWEntities = new SaveWorldEntities())
            {

                 /* var currentUser = NWEntities.Ausers.FirstOrDefault(u => u.id == id);
                  return currentUser;*/

               
                var user = (from p in NWEntities.Ausers
                                where p.id == id
                                select p).FirstOrDefault();
                if (user != null)
                    userData = new User()
                    {
                        UserId = user.id,
                        Name = user.name,
                        Email = user.email,
                        Password = user.password,
                        Address = user.address,
                        Phone = user.phoneno,
                        TypeOfUser = user.typeOfUser,

                    };
            }
            return userData;
           
        }

        public void AddUser(string name, string password, int typeOfUser, string email, string address, string phone)
        {
           
            using (SaveWorldEntities dbEntities = new SaveWorldEntities())

            {

                auser user = new auser()
                {

                   name = name,
                    email = email,
                    password = password,
                    address = address,
                    phoneno = phone,
                    typeOfUser = typeOfUser,
                };

                dbEntities.Ausers.Add(user);
                dbEntities.SaveChanges();
            }
        }

        public User CheckLogin(string userEmail, string password)
        {

            User userCorrect = null;
            using (var NWEntities = new SaveWorldEntities())
            {
               

                var user = NWEntities.Ausers
                       .FirstOrDefault(u => u.email == userEmail
                        && u.password == password);

                if (user != null)
                {
                    userCorrect = new User()
                    {
                        UserId = user.id,
                        Name = user.name,
                        Password = user.password,
                        Email = user.email,
                        Address = user.address,
                        Phone = user.phoneno,

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
