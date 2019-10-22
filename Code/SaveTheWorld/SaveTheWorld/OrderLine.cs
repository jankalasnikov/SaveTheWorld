using System;
namespace SaveTheWorld
{
    class OrderLine
    {
        private int quantity { get; set; }

        public OrderLine()
        {
            
        }

        public OrderLine(int quantity)
        {
            this.quantity = quantity; 
        }
    }
}
