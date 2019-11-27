using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldService
{
    [ServiceContract]
    public interface IBankAccountService
    {
        [OperationContract]
        BankAccountB GetBankAccount(int accountNumber);

        [OperationContract]
        BankAccountB GetBankAccountById(int id);

        [OperationContract]
        bool CheckBankAccount(int accNo, DateTime expiryDate, int CCV);

        [OperationContract]
        bool donateToSpecificDisaster(double amount, int userBankAccId, int disasterBankAccId);

        [OperationContract]
        void Update(BankAccountB bankAccountBefore);

    }
}
