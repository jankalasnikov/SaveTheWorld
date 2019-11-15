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
        public BankAccount GetBankAccount(int accountNumber)
        {
            BankAccount accountData = null;
            using (var NWEntities = new SaveWorldEntities())
            {

                /* var currentUser = NWEntities.Ausers.FirstOrDefault(u => u.id == id);
                 return currentUser;*/


                var account = (from p in NWEntities.BankAccounts
                            where p.accountNo == accountNumber
                            select p).FirstOrDefault();
                if (account != null)
                    accountData = new BankAccount()
                    {
                        AccountNo = account.accountNo,
                        ExpiryDate = account.expiryDate,
                        CCV = account.ccv,
                        Amount = account.amount,
                        

                    };
            }
            return accountData;

        }

     /* doing the account cheking
      * public User CheckLogin(string userEmail, string password)
        {

            User userCorrect = null;
            using (var NWEntities = new SaveWorldEntities())
            {


                var user = NWEntities.Ausers
                       .FirstOrDefault(u => u.email == userEmail
                        && u.password == password);

                if (user != null)
                {
                    userCorrect = new User()
                    {
                        UserId = user.id,
                        Name = user.name,
                        Password = user.password,
                        Email = user.email,
                        Address = user.address,
                        Phone = user.phoneno,

                    };
                }
                   else
                   {
                       throw new ArgumentNullException("user is null");
                   }
              

            }

            return userCorrect;
        }*/
    }
}
