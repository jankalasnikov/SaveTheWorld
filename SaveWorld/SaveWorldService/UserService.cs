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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                  ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class UserService : IUser
    {
        readonly object ThisLock = new object();

        UserCtr userCtr = new UserCtr();
        public UserB GetUser(int id)
        {
            return userCtr.GetUser(id);
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

        
        public int DeleteUser(int id)
        {
            lock (ThisLock)
            {
                return userCtr.DeleteUser(id);
            }
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
