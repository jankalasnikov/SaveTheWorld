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
    public class DisasterCheckTest
    {
        [TestMethod]
        public void CheckIfDisasterNameExists()
        {
            DisasterCtrB disCtr = new DisasterCtrB();
            Assert.AreEqual(true, disCtr.CheckNameIfExists("Amazon fire"));
        }
    }
}
