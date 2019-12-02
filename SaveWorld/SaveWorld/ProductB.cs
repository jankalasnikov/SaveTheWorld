using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldModel
{
    [DataContract]
    public class ProductB
        {

            [DataMember]
            public int ProductId { get; set; }
            [DataMember]
            public string ProductName { get; set; }
            [DataMember]
            public decimal Price { get; set; }
            [DataMember]
            public string ProductDescription { get; set; }
            [DataMember]
            public int Stock { get; set; }
            [DataMember]
            public string Size { get; set; }
    }
}
