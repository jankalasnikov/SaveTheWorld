using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldModelL
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public DateTime orderDate { get; set; }
        
        public Order()
        {

        }

    }
}
