using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld
{
    class BankAccount
    {
        private int accountNo { get; set; }
        private DateTime expiryDate { get; set; }
        private int CCV { get; set; }
        private double amount { get; set; }
        private String address { get; set; }


        public BankAccount()
        {

        }

        public BankAccount(int accountNo, DateTime expiryDate, int CCV, double amount, String address)
        {
            this.accountNo = accountNo;
            this.expiryDate = expiryDate;
            this.CCV = CCV;
            this.amount = amount;
            this.address = address;
        }

        
    }
}
