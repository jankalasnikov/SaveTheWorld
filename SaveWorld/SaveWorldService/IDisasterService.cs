using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldService
{
    
    [ServiceContract]
    public interface IDisasterService
    {

        [OperationContract]
        List<DisasterB> GetAllDisasters();

        [OperationContract]
        DisasterB GetDisasterByName(string name);

        [OperationContract]
        bool UpdateDisaster(DisasterB disaster);

        [OperationContract]
        void DeleteDisaster(string name);

        [OperationContract]
        bool CheckNameIfExists(string name);
    }
}
