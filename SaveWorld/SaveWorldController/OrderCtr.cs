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

        /*  Order Order { get; set; } = new Order();
          public string GetDate()
          {
              return "today";
          }

          public void AddOrderLine(int productID, int quantity)
          {

              List<OrderLine> existingOrderLines = Order.OrderLines.Where(orderLine => orderLine.ProductID == productID).ToList();
              if (existingOrderLines.Count > 0)
              {
                  existingOrderLines.ForEach(orderLine => orderLine.Quantity += quantity);
              }
              else
              {
                  if (existingOrderLines.Count == 0)
                  {
                      Order.OrderLines.Add(new OrderLine()
                      {
                          ProductID = productID,
                          Quantity = quantity
                      });
                  }
              }

          }

          public void RemoveOrderLine(int productId)
          {
              Order.OrderLines.RemoveAll(orderLine => orderLine.ProductID == productId);
          }*/
    }
}
