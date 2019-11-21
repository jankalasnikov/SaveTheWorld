using SaveWorldController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveTheWorldModelL;

namespace SaveWorldService
{
   public class OrderService : IOrderService
    {
        OrderCtr orderCtr = new OrderCtr();
        public string GetDates()
        {
            return orderCtr.GetDate();
        }
    }
}
