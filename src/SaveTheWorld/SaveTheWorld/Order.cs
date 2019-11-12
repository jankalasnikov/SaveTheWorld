using System;
namespace SaveTheWorld
{
    public class Order
    {
        public DateTime OrderDate { get; set; }

        public Order()
        {

        }

        public Order(DateTime orderDate)
        {
            this.OrderDate = orderDate; 
        }
    }
}
