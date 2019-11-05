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
      

        public int id { get; set; }

        public string name { get; set; }
        
        public string password { get; set; }
       
        public string typeOfUser { get; set; }
        
        public string email { get; set; }
        
        public string address { get; set; }
       
        public string phoneno { get; set; }
  

        public User(string name, string password, string typeOfUser, string email, string address, string phone)
        {
            Name = name;
            Password = password;
            TypeOfUser = typeOfUser;
            Email = email;
            Address = address;
            Phone = phone;
           

        }

        public User()
        {
        }

       
    }
}
