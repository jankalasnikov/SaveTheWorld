
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
        UserDAL userDal = new UserDAL();
        public UserB GetUser(int id)
        {
            return userDal.GetUser(id);
        }


        public UserB GetUserByName(string name)
        {
            return userDal.GetUserByName(name);
        }

        public List<UserB> GetAllUsers()
        {
            return userDal.GetAllUsers();
        }

        public int DeleteUser(int id)
        {
            return userDal.DeleteUser(id);
        }

        public int GetUserIDByName(string name)
        {
            return userDal.GetUserIDByName(name);
        }


        public bool CheckEmailIfExists(string email)
        {
            return userDal.CheckEmailIfExists(email);
        }

        public void CreateUser(UserB newUser)
        {
            userDal.CreateUser(newUser);
        }


        public UserB CheckLogin(string userEmail, string password)
        {
            return userDal.CheckLogin(userEmail, password);
        }

      
        public bool UpdateUser(UserB user)
        {
            return userDal.UpdateUser(user);
        }
    }
}
