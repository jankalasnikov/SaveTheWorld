﻿using SaveWorldModel;
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
        BankAccount GetBankAccount(int accountNumber);
        [OperationContract]
        bool CheckBankAccount(int accNo, DateTime expiryDate, int CCV);

    }
}