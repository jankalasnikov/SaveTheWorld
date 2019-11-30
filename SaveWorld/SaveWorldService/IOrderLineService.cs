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
    public interface IOrderLineService
    {
        [OperationContract]
        OrderLine CreateOrderLine(OrderLine newOrderLine);

        [OperationContract]
        int RemoveOrderLineAndReturnStock(int idToRemoveOrderLine);

        [OperationContract]
        void UpdateOrderLine(OrderLine orderLine);
    }
}
