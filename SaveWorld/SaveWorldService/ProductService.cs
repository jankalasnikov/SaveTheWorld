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
        ProductCtrB prodCtr = new ProductCtrB();
        public ProductB GetProduct(int id)
        {
            ProductB prod = null;
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

        public ProductB GetProductByName(string name)
        {
            ProductB prod = null;
            try
            {
                prod = prodCtr.GetProductByName(name);
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

        public List<ProductB> GetAllProduct()
        {
            return prodCtr.GetAllProduct();
        }
    }
}
