using SaveWorldModel;
using SaveWorldController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SaveWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserService : IUser
    {
        UserCtr userCtr = new UserCtr();
        public User GetUser(int id)
        {
            return userCtr.GetUser(id);
        }
        public void AddUser(string name, string password, int typeOfUser, string email, string address, string phone)
        {
             userCtr.AddUser(name,password,typeOfUser,email,address,phone);
        }

        public User CheckLogin(string email, string pass)
        {
            User userbd = new User();

            userbd = userCtr.CheckLogin(email, pass);

            return userbd;
        }
    }
}
