using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldModel
{
    [DataContract]
    public class Subscription
    {
        [DataMember]
        public int periodOfTime { get; set; }
        [DataMember]
        public string typeOfSubscription { get; set; }
        [DataMember]
        public double amount { get; set; }
        [DataMember]
        public DateTime startDate { get; set; }
    }
}
