using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldModel
{
    [DataContract]
    public class Property
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string sortOrder { get; set; }

    }
}
