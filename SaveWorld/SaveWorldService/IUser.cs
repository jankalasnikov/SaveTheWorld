using SaveWorldModel;
using System.ServiceModel;

namespace SaveWorldService
{
   
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        UserB GetUser(int id);
        [OperationContract]
        void AddUser(string name, string password, int typeOfUser, string email, string address, string phone,int bankAcc);

        [OperationContract]
        UserB CheckLogin(string email, string pass);

        [OperationContract]
        void CreateUser(UserB newUser);
    }

}
