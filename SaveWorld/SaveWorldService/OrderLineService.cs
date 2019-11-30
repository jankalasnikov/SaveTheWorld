using SaveWorldController;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldService
{
    public class OrderLineService : IOrderLineService
    {
        OrderLineCtr orderLineCtr = new OrderLineCtr();
        public OrderLine CreateOrderLine(OrderLine newOrderLine)
        {
          return orderLineCtr.CreateOrderLine(newOrderLine);

        }

        public int RemoveOrderLineAndReturnStock(int idToRemoveOrderLine)
        {
            return orderLineCtr.RemoveOrderLineAndReturnStock(idToRemoveOrderLine);
        }

        public void UpdateOrderLine(OrderLine orderLine)
        {
            orderLineCtr.UpdateOrderLine(orderLine);
        }
    }
}
