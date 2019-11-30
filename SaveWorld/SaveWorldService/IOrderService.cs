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
    public interface IOrderService
    {
        [OperationContract]
        int CreateOrderAndReturnId(Order newOrder);


       /* [OperationContract]
        string GetDates();

        [OperationContract]
        void AddOrderLine(int productId, int quantity);
        [OperationContract]
        void RemoveOrderLine(int productId);
 */
    }
}
