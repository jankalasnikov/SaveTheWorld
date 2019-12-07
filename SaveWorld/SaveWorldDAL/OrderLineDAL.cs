﻿using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldDAL
{
    public class OrderLineDAL
    {
        public OrderLine CreateOrderLine(OrderLine newOrder)
        {

            using (SaveWorldEntities dbEntities = new SaveWorldEntities())
            {

                orderLine ordLine = new orderLine()
                {
                    // id = newOrder.OrderLineId,
                    orderId = 1,
                    productId = newOrder.ProductID,
                    quantity = newOrder.Quantity,
                    price = newOrder.Price,
                };

                dbEntities.OrderLine.Add(ordLine);
                dbEntities.SaveChanges();

                OrderLine returnOrder = new OrderLine();
                //   returnOrder = null;

                returnOrder.OrderLineId = ordLine.id;
                returnOrder.ProductID = (int)ordLine.productId;
                returnOrder.OrderID = (int)ordLine.orderId;
                returnOrder.Quantity = ordLine.quantity;
                returnOrder.Price = ordLine.price;




                return returnOrder;


            }
        }

        public void UpdateOrderLine(OrderLine orderLine)
        {
            using (var NWEntities = new SaveWorldEntities())
            {
                var orderLineId = orderLine.OrderLineId;
                var orderLineDatabase =
                        (from p
                        in NWEntities.OrderLine
                         where p.id == orderLineId
                         select p).FirstOrDefault();

                if (orderLineDatabase == null)
                {
                    throw new Exception("No orderLine with ID " +
                                        orderLine.OrderLineId);
                }

                orderLineDatabase.id = orderLine.OrderLineId;
                orderLineDatabase.orderId = orderLine.OrderID;
                orderLineDatabase.price = orderLine.Price;
                orderLineDatabase.productId = orderLine.ProductID;
                orderLineDatabase.quantity = orderLine.Quantity;


                NWEntities.OrderLine.Attach(orderLineDatabase);


                NWEntities.Entry(orderLineDatabase).State = System.Data.Entity.EntityState.Modified;


                var num = NWEntities.SaveChanges();


            }

        }

        public int RemoveOrderLineAndReturnStock(int idToRemoveOrderLine)
        {
            int stock = 0;

            using (var NWEntities = new SaveWorldEntities())
            {
                var orderLine = (from p in NWEntities.OrderLine
                                 where p.id == idToRemoveOrderLine
                                 select p).FirstOrDefault();
                if (orderLine != null)

                {
                    stock = orderLine.quantity;
                    NWEntities.OrderLine.Remove(orderLine);
                    NWEntities.SaveChanges();
                };
            }
            return stock;
        }
    }
}
