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
        public UserB GetUser(int id)
        {
            return userCtr.GetUser(id);
        }
        public void AddUser(string name, string password, int typeOfUser, string email, string address, string phone,int bankAcc)
        {
             userCtr.AddUser(name,password,typeOfUser,email,address,phone, bankAcc);
        }

        public UserB CheckLogin(string email, string pass)
        {
            UserB userbd = new UserB();

            userbd = userCtr.CheckLogin(email, pass);

            return userbd;
        }

        public UserB GetUserByName(string name)
        {
            return userCtr.GetUserByName(name);
        }
        public void CreateUser(UserB newUser)
        {
            userCtr.CreateUser(newUser);
        }

        public bool CheckEmailIfExists(string email)
        {
            return userCtr.CheckEmailIfExists(email);
        }

        public int GetUserIDByName(string name)
        {
            return userCtr.GetUserIDByName(name);
        }

        public bool UpdateUser(UserB user)
        {
            return userCtr.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            userCtr.DeleteUser(id);
        }

        public List<UserB> GetAllUsers()
        {
            return userCtr.GetAllUsers();
        }

        /*public bool IsCookieValid(string cookieId)
        {
            return userCtr.Instance().IsCookieValid(cookieId);
        }
        */
    }
}
