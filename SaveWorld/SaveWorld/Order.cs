using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldModel
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public DateTime orderDate { get; set; }
        [DataMember]
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    }
}
