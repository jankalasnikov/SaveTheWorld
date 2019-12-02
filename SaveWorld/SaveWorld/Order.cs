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
        public int OrderId { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public int UserId { get; set; }
    }
}
