using SaveWorldDAL;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldController
{
   public class BankAccountCtr
    {
        BankAccountDAL bankDal = new BankAccountDAL();
        
        public BankAccountB GetBankAccount(int accountNumber)
        {
           return bankDal.GetBankAccount(accountNumber);
        }

        public bool Update(BankAccountB bankAccountBefore)
        {
           return bankDal.Update(bankAccountBefore);
        }


        public BankAccountB GetBankAccountById(int id)
        {
            return bankDal.GetBankAccountById(id);
        }

        public bool CheckBankAccount(int accNo, DateTime expiryDate, int CCV)
        {
           return bankDal.CheckBankAccount(accNo, expiryDate, CCV);
        }

        public bool CheckBankAccountw(int accNo, int CCV)
        {
            return bankDal.CheckBankAccountw(accNo, CCV);
        }
        public bool donateToSpecificDisaster(decimal amount, BankAccountB userBankAcc, BankAccountB disasterBankAcc)
        {
           return bankDal.donateToSpecificDisaster(amount, userBankAcc, disasterBankAcc);
        }


        public bool donateMoneyToAllDisasters(decimal totalPrice, int userBankId)
        {
            return bankDal.donateMoneyToAllDisasters(totalPrice, userBankId);
        }
    }
}
