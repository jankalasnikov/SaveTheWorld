using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldModel
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public int CatogoryId { get; set; }
        [DataMember]
        public string NameOfCategory { get; set; }
    }
}
