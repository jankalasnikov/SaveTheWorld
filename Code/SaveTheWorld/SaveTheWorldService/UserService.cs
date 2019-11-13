using SaveTheWorldController;
using SaveTheWorldModelL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldService
{
    class UserService : IUserService
    {
        UserCtr userController = new UserCtr();

        public User GetUser(int id)
        {
            User userbd = null;
          
                userbd = userController.GetUser(id);
           
            if (userbd == null)
            {
                var msg =
                    string.Format("No user found for id {0}",
                    id);
                var reason = "GetUser Empty User";
                throw new Exception(reason);
            }
            var user = new User();
            TranslateUserBDOToUserDTO(userbd, user);
            return user;
        }

        public User CheckLogin(string email, string pass)
        {
            User userbd = new User();

            userbd = userController.CheckLogin(email, pass);

            return userbd;
        }


        public void AddUser(string name, string password, int typeOfUser, string email, string address, string phone)
        {
            userController.AddUser(name, password, typeOfUser, email, address, phone);
        }

        public void DeleteUser(int id)
        {
            userController.DeleteUser(id);
        }

        private void TranslateUserBDOToUserDTO(
           User userbd,
           User user)
        {
            user.UserId = userbd.UserId;
            user.Name = userbd.Name;
            user.Password = userbd.Password;
            user.Email = userbd.Email;
            user.Address = userbd.Address;
            user.Phone = userbd.Phone;
        }

        private void TranslateUserDTOToUserBDO(
            User user,
            User userbd)
        {
            userbd.UserId = user.UserId;
            userbd.Name = user.Name;
            userbd.Password = user.Password;
            userbd.Email = user.Email;
            userbd.Address = user.Address;
            userbd.Phone = user.Phone;
        }
    }
}
