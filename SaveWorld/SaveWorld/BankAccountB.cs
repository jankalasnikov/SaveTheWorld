using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldModel
{
    [DataContract]
    public class BankAccountB
    {
        [DataMember]
        public int AccountId { get; set; }
        [DataMember]
        public int AccountNo { get; set; }
        [DataMember]
        public DateTime ExpiryDate { get; set; }
        [DataMember]
        public int CCV { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
<<<<<<< HEAD
        [DataMember]
        public byte[] RowVersion { get; set; }

      
=======

>>>>>>> 3a48c8be6e4582dbfda1dffc21e8a0166de806a2
    }
}
