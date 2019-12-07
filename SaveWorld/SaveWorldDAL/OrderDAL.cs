using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldDAL
{
    public class OrderDAL
    {
        public int CreateOrderAndReturnId(Order newOrder)
        {

            using (SaveWorldEntities dbEntities = new SaveWorldEntities())
            {


                tbOrder order = new tbOrder()
                {

                    userId = newOrder.UserId,
                    date = newOrder.OrderDate,


                };

                dbEntities.TbOrder.Add(order);

                dbEntities.SaveChanges();

                return order.id;

            }
        }
    }
}
