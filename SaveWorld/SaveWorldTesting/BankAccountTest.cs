using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaveWorldController;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldTesting
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void CheckDonation()
        {          
            BankAccountCtr bankCtr = new BankAccountCtr();
            Assert.AreEqual(true, bankCtr.CheckBankAccountw(2, 123));
        }
    }
}
