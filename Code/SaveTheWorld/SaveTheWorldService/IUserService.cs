using SaveTheWorldModelL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldService
{
    [ServiceContract]
    interface IUserService
    {

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        void AddUser(string name, string password, int typeOfUser, string email, string address, string phone);

        [OperationContract]
        void DeleteUser(int id);

        [OperationContract]
         User CheckLogin(string email, string pass);


    }
}
