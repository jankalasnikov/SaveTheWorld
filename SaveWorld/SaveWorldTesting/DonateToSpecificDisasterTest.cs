using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaveWorldController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldTesting
{
    [TestClass]
    public class DonateToSpecificDisasterTest
    {
        [TestMethod]
        public void CheckDonating()
        {
            BankAccountCtr bankCtr = new BankAccountCtr();
            Assert.AreEqual(true, bankCtr.donateToSpecificDisaster(20, 1, 6));
            //Assert.IsTrue(bankCtr.donateToSpecificDisaster(20, 1, 66), "Donate fail!");
        }
    }
}
