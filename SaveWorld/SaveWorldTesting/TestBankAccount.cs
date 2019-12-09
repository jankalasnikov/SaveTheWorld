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
    public class TestBankAccount
    {
        [TestMethod]
        public void CheckDonation()
        {
           
            DateTime exDate = new DateTime(2012, 02, 20);
           
            BankAccountCtr bankCtr = new BankAccountCtr();
            Assert.AreEqual(true, bankCtr.CheckBankAccountw(2, 23));
        }
    }
}
