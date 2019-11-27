using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldModel
{
    [DataContract]
    public class OrderLine
    {
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public int ProductID { get; set; }


    }
}