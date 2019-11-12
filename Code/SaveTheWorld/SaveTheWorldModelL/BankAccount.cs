using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldModelL
{
    [DataContract]
    public class BankAccount
    {
        [DataMember]
        public int accountNo { get; set; }
        [DataMember]
        public DateTime expiryDate { get; set; }
        [DataMember]
        public int CCV { get; set; }
        [DataMember]
        public double amount { get; set; }
        [DataMember]
        public string address { get; set; }

        public BankAccount()
        {
        }
    }
}
