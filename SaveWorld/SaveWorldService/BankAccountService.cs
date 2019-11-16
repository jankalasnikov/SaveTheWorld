using SaveWorldController;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldService
{
    class BankAccountService : IBankAccountService
    {
        BankAccountCtr bankCtr = new BankAccountCtr();
        public BankAccount GetBankAccount(int accountNumber)
        {
            BankAccount bank = null;
            try
            {
                bank = bankCtr.GetBankAccount(accountNumber);
            }
            catch
            {

                var reason = "GetBankAccount Exception";
                throw new FaultException(reason);
            }

            if (bank == null)
            {
                var reason = "GetBankAccount empty account";
                throw new FaultException(reason);
            }

            return bank;
        }

        public bool CheckBankAccount(int accNo, DateTime expiryDate, int CCV)
        {
            bool bankAccountValid = false;
            try
            {
                bankAccountValid = bankCtr.CheckBankAccount(accNo, expiryDate, CCV);
            }
            catch
            {

                var reason = "GetBankAccount Exception";
                throw new FaultException(reason);
            }

            if (bankAccountValid == false)
            {
                var reason = "GetBankAccount empty account";
                throw new FaultException(reason);
            }

            return bankAccountValid;

        }
    }
}
