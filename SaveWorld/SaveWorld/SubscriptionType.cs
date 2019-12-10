using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldModel
{
    [DataContract]
    public class SubscriptionType
    {
        [DataMember]
        public int SubscriptionTypeID { get; set; }
        [DataMember]
        public string NameOfSubscription { get; set; }
        [DataMember]
        public int Days { get; set; }
    }
}
