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

      
    }
}
