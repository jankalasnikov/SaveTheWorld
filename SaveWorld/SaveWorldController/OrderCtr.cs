using SaveWorldDAL;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldController
{
    public class OrderCtr
    {
        OrderDAL orderDal = new OrderDAL();
        public int CreateOrderAndReturnId(Order newOrder)
        {
            return orderDal.CreateOrderAndReturnId(newOrder);
        }

        
    }
}
