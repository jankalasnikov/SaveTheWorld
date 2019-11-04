using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldModelL
{
    [DataContract]
   public class User
    {

        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string TypeOfUser { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Phone { get; set; }



        public User()
        {
        }

       
    }
}
