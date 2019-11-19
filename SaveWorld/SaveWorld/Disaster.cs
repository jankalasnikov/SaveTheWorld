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
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public int Priority { get; set; }
        [DataMember]
        public int Victims { get; set; }
    }
}
