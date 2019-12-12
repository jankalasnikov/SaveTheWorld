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
    public class CheckLoginTest
    {
        [TestMethod]
        public void CheckLoginData()
        {
            UserB user = new UserB();
            UserCtr userCtr = new UserCtr();
            Assert.IsNotNull(userCtr.CheckLogin("asdasd@as.dk", "123"));
        }

    }
}
