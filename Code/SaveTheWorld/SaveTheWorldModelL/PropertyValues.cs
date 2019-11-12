using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldModelL
{
    [DataContract]
    public class PropertyValues
    {
        [DataMember]
        public int value { get; set; }

        public PropertyValues()
        {

        }
    }
}
