using SaveTheWorldBDO;
using SaveTheWorldDAL;
using SaveTheWorldModelL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldController
{
    public class ProductCtr
    {
        ProductDAO productDAO = new ProductDAO();

        public Product GetProduct(int id)
        {
            try
            {

                return productDAO.GetProduct(id);
            }
            catch (Exception e)
            {
               
                
                throw new Exception(e.Message);
            }
        }

        public bool UpdateProduct(
            ref Product productBDO,
            ref string message)
        {
            var productInDB =
                GetProduct(productBDO.ProductId);
            // invalid product to update
            if (productInDB == null)
            {
                message = "cannot get product for this ID";
                return false;
            }
            // a product cannot be discontinued 
            // if there are non-fulfilled orders
            /*if (product.Discontinued == true
                && productInDB.UnitsOnOrder > 0)
            {
                message = "cannot discontinue this product";
                return false;
            }
            else
            {*/
                return productDAO.UpdateProduct(ref productBDO,
                    ref message);
           // }
        }
    }
}
