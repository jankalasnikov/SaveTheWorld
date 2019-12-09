using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldDAL
{
    public class BankAccountDAL
    {

        public bool correct = false;
        public BankAccountB GetBankAccount(int accountNumber)
        {
            BankAccountB accountData = null;
            using (var NWEntities = new SaveWorldEntities())
            {

                var account = (from p in NWEntities.BankAccounts
                               where p.accountNo == accountNumber
                               select p).FirstOrDefault();
                if (account != null)
                    accountData = new BankAccountB()
                    {
                        AccountId = account.id,
                        AccountNo = account.accountNo,
                        ExpiryDate = account.expiryDate,
                        CCV = account.ccv,
                        Amount = account.amount,


                    };
            }
            return accountData;

        }

        public void Update(BankAccountB bankAccountBefore)
        {

            var NWEntities = new SaveWorldEntities();


            var accountForSave = (from p in NWEntities.BankAccounts
                                  where p.accountNo == bankAccountBefore.AccountNo
                                  select p).FirstOrDefault();


            accountForSave.accountNo = bankAccountBefore.AccountNo;
            accountForSave.amount = bankAccountBefore.Amount;
            accountForSave.ccv = bankAccountBefore.CCV;
            accountForSave.expiryDate = bankAccountBefore.ExpiryDate;

            NWEntities.SaveChanges();

        }

        public BankAccountB GetBankAccountById(int id)
        {
            BankAccountB accountData = null;
            using (var NWEntities = new SaveWorldEntities())
            {

                var account = (from p in NWEntities.BankAccounts
                               where p.id == id
                               select p).FirstOrDefault();
                if (account != null)
                    accountData = new BankAccountB()
                    {
                        AccountId = account.id,
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

        public bool CheckBankAccountw(int accNo, int CCV)
        {


            using (var NWEntities = new SaveWorldEntities())
            {


                bankAccount accountValid = NWEntities.BankAccounts
                       .FirstOrDefault(u => u.accountNo == accNo
                        && u.ccv == CCV);

                if (accountValid != null)
                {
                    correct = true;
                }



            }

            return correct;
        }

        public bool donateToSpecificDisaster(decimal amount, int userBankId, int disasterBankId)
        {
            BankAccountB userAcc = new BankAccountB();
            BankAccountDAL dal = new BankAccountDAL();
            userAcc = dal.GetBankAccountById(userBankId);


            BankAccountB disasterAcc = new BankAccountB();
            disasterAcc = dal.GetBankAccountById(disasterBankId);



            if (userAcc.Amount < amount)
            {
                return false;
            }
            userAcc.Amount = userAcc.Amount - amount;
            dal.Update(userAcc);

            disasterAcc.Amount = disasterAcc.Amount + amount;
            dal.Update(disasterAcc);
            return true;


        }


        public bool donateMoneyToAllDisasters(decimal totalPrice, int userBankId)
        {
            BankAccountB userAcc = new BankAccountB();
            BankAccountDAL bankDal = new BankAccountDAL();
            DisasterDAL disasterDal = new DisasterDAL();
            List<DisasterB> allDis = new List<DisasterB>();
            userAcc = bankDal.GetBankAccountById(userBankId);
            decimal moneyForOneDisaster = 0;

            if (userAcc.Amount < totalPrice)
            {
                return false;
            }
            userAcc.Amount = userAcc.Amount - totalPrice;
            bankDal.Update(userAcc);
            allDis = disasterDal.GetAllDisasters();

            moneyForOneDisaster = totalPrice / allDis.Count;

            foreach (DisasterB dis in allDis)
            {
                BankAccountB disAcc = new BankAccountB();
                disAcc = bankDal.GetBankAccountById(dis.DisasterBankAccountId);
                disAcc.Amount = disAcc.Amount + moneyForOneDisaster;
                bankDal.Update(disAcc);
            }



            return true;
        }
    }
}
