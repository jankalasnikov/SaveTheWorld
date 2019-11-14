using SaveWorldModel;
using System.ServiceModel;

namespace SaveWorldService
{
   
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        User GetUser(int id);
        [OperationContract]
        void AddUser(string name, string password, int typeOfUser, string email, string address, string phone);

        [OperationContract]
        User CheckLogin(string email, string pass);
    }

}
