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
            try
            {
                userbd = userController.GetUser(id);
            }
            catch (Exception e)
            {
                var msg = e.Message;
                var reason = "GetProduct Exception";
                throw new Exception(reason);
            }

            if (userbd == null)
            {
                var msg =
                    string.Format("No product found for id {0}",
                    id);
                var reason = "GetProduct Empty Product";
                throw new Exception(reason);
            }
            var user = new User();
            TranslateUserBDOToUserDTO(userbd, user);
            return user;
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
