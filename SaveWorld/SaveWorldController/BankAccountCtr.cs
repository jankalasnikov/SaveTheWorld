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

        public bool correct = false;
        public BankAccount GetBankAccount(int accountNumber)
        {
            BankAccount accountData = null;
            using (var NWEntities = new SaveWorldEntities())
            {

                var account = (from p in NWEntities.BankAccounts
                            where p.accountNo == accountNumber
                            select p).FirstOrDefault();
                if (account != null)
                    accountData = new BankAccount()
                    {
                        AccountId=account.id,
                        AccountNo = account.accountNo,
                        ExpiryDate = account.expiryDate,
                        CCV = account.ccv,
                        Amount = account.amount,
                        

                    };
            }
            return accountData;

        }

   
       public bool CheckBankAccount(int accNo, DateTime expiryDate, int CCV)
        {
          
          
            using (var NWEntities = new SaveWorldEntities())
            {


                var accountValid = NWEntities.BankAccounts
                       .FirstOrDefault(u => u.accountNo == accNo
                        && u.expiryDate == expiryDate
                        && u.ccv == CCV);

                if (accountValid != null)
                {
                    correct = true;
                }
                  
              

            }

            return correct;
        }
    }
}
