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
        void AddUser(string name, string password, int typeOfUser, string email, string address, string phone,int bankAcc);

        [OperationContract]
        UserB CheckLogin(string email, string pass);

        [OperationContract]
        void CreateUser(UserB newUser);

        [OperationContract]
        void DeleteUser(int id);

        [OperationContract]
        int GetUserIDByName(string name);
        [OperationContract]
        bool UpdateUser(UserB user);
    }

}
