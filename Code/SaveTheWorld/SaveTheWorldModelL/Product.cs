using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldModelL
{
    [DataContract]
    public class Product
    {

        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public String ProductName { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public String ProductDescription { get; set; }
        [DataMember]
        public int Stock { get; set; }

            public Product()
            {

            }

    
    }
    [DataContract]
    public class ProductFault
    {
        [DataMember]
        public string FaultMessage;
        public ProductFault(string msg)
        {
            FaultMessage = msg;
        }
    }
}