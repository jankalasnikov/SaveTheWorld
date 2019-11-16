using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldModel
{
    [DataContract]
    public class Disaster
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string region { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public int priority { get; set; }
        [DataMember]
        public int victims { get; set; }
    }
}
