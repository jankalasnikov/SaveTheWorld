using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld
{
    class BankAccount
    {
        private int AccountNo { get; set; }
        private DateTime ExpiryDate { get; set; }
        private int CCV { get; set; }
        private double Amount { get; set; }
        private String Address { get; set; }


        public BankAccount()
        {

        }

        public BankAccount(int accountNo, DateTime expiryDate, int CCV, double amount, String address)
        {
            AccountNo = accountNo;
            ExpiryDate = expiryDate;
            this.CCV = CCV;
            Amount = amount;
            Address = address;
        }

        
    }
}
