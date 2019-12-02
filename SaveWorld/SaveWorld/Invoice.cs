using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldModel
{
    [DataContract]
    public class Invoice
    {
        [DataMember]
        public int invoiceNo { get; set; }
        [DataMember]
        public DateTime paymentDate { get; set; }
        [DataMember]
        public double totalPrice { get; set; }

    }
}