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
    

    public class CreatingProductTest
    {
        [TestMethod]
        public void CreatingAProduct()
        {
            ProductCtrB productCtr = new ProductCtrB();
            ProductB prod = new ProductB();
            prod.ProductName = "umbrella";
            prod.ProductDescription = "a very nice umbrella";
            prod.Stock = 10;
            prod.Price = 10.35M;
            prod.ProductId = 6;
            Assert.IsNotNull(productCtr.CreateProduct(prod));
        }
    }
}
