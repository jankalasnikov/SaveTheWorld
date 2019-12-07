using SaveWorldModel;
using System.Collections.Generic;
using System.ServiceModel;

namespace SaveWorldService
{
   
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        UserB GetUser(int id);

        [OperationContract]
        bool CheckEmailIfExists(string email);

        [OperationContract]
        UserB GetUserByName(string name);

        [OperationContract]
        List<UserB> GetAllUsers();

        [OperationContract]
        UserB CheckLogin(string email, string pass);

        [OperationContract]
        void CreateUser(UserB newUser);

        [OperationContract]
        int DeleteUser(int id);

        [OperationContract]
        int GetUserIDByName(string name);
        [OperationContract]
        bool UpdateUser(UserB user);
    }

}
