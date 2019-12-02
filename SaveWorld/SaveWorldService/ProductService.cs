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

        public void RemoveStockFromProduct(int id, int removeQuantity)
        {
            prodCtr.RemoveStockFromProduct(id, removeQuantity);
        }

        public void ReturnStock(int idOfProduct, int returnQuantity)
        {
            prodCtr.ReturnStock(idOfProduct, returnQuantity);
        }

        public List<ProductB> GetAllProduct()
        {
            return prodCtr.GetAllProduct();
        }

        public void DeleteProduct(int id)
        {
            prodCtr.DeleteProduct(id);
        }

        public bool UpdateProduct(ProductB product)
        {
            return prodCtr.UpdateProduct(product);
        }

        public bool CheckIfNameExists(string name)
        {
            return prodCtr.CheckIfNameExists(name);
        }
    }
}
