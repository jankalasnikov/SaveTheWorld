using SaveWorldDAL;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldController
{
   public class OrderLineCtr
    {
        OrderLineDAL orderLineDal = new OrderLineDAL();
        public OrderLine CreateOrderLine(OrderLine newOrder)
        {
            return orderLineDal.CreateOrderLine(newOrder);
        }

        public void UpdateOrderLine(OrderLine orderLine)
        {
            orderLineDal.UpdateOrderLine(orderLine);
        }

        public int RemoveOrderLineAndReturnStock(int idToRemoveOrderLine)
        {
            return orderLineDal.RemoveOrderLineAndReturnStock(idToRemoveOrderLine);
        }
    }
}
