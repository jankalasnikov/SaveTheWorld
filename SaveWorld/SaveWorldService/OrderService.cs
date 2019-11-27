using SaveWorldController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveWorldModel;

namespace SaveWorldService
{
    public class OrderService : IOrderService
    {
        OrderCtr orderCtr = new OrderCtr();
        Order ord = new Order();
        public string GetDates()
        {
            return orderCtr.GetDate();
        }
        public void AddOrderLine(int productID, int quantity)
        {
            orderCtr.AddOrderLine(productID, quantity);
        }

        public Order returnOrd()
        {
            return ord;
        }

        public void RemoveOrderLine(int productId)
        {
            orderCtr.RemoveOrderLine(productId);
        }
    }
}
