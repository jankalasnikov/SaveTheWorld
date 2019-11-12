using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldModelL
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
        public int category { get; set; }
        [DataMember]
        public int priority { get; set; }
        [DataMember]
        public int victims { get; set; }

        public Disaster()
        {

        }
    }
}
