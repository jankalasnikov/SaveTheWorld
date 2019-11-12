using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldModelL
{
    [DataContract]
    public class Subscription
    {
        [DataMember]
        public string periodOfTime { get; set; }
        [DataMember]
        public string typeOfSubscription { get; set; }
        [DataMember]
        public double amount { get; set; }
        [DataMember]
        public DateTime startDate { get; set; }

        public Subscription()
        {

        }
    }
}
