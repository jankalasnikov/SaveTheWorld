using SaveWorldController;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldService
{
    public class ProductService : IProductService
    {
        ProductCtr prodCtr = new ProductCtr();
        public Product GetProduct(int id)
        {
            Product prod = null;
            try
            {
                prod = prodCtr.GetProduct(id);
            }
            catch
            {

                var reason = "GetUser Exception";
                throw new FaultException(reason);
            }

            if (prod == null)
            {
                var reason = "GetUser empty user";
                throw new FaultException(reason);
            }

            return prod;
        }
    }
}
