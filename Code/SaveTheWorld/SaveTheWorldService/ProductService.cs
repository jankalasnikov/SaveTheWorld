using SaveTheWorldBDO;
using SaveTheWorldController;
using SaveTheWorldModelL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SaveTheWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        ProductCtr productController = new ProductCtr();

        public Product GetProduct(int id)
        {
            ProductBDO productBDO = null;
            try
            {
                productBDO = productController.GetProduct(id);
            }
            catch (Exception e)
            {
                var msg = e.Message;
                var reason = "GetProduct Exception";
                throw new FaultException<ProductFault>
                    (new ProductFault(msg), reason);
            }

            if (productBDO == null)
            {
                var msg =
                    string.Format("No product found for id {0}",
                    id);
                var reason = "GetProduct Empty Product";
                throw new FaultException<ProductFault>
                    (new ProductFault(msg), reason);
            }
            var product = new Product();
            TranslateProductBDOToProductDTO(productBDO, product);
            return product;
        }

        public bool UpdateProduct(ref Product product,
            ref string message)
        {
            var result = true;

            // first check to see if it is a valid price
            if (product.Price <= 0)
            {
                message = "Price cannot be <= 0";
                result = false;
            }
            // ProductName can't be empty
            else if (string.IsNullOrEmpty(product.ProductName))
            {
                message = "Product name cannot be empty";
                result = false;
            }
            // QuantityPerUnit can't be empty
            else if
            (product.Stock <= (product.Stock))
            {
                message = "stock cannot be empty";
                result = false;
            }
            else
            {
                try
                {
                    var productBDO = new ProductBDO();
                    TranslateProductDTOToProductBDO(product,
                    productBDO);
                    result = productController.UpdateProduct(
                        ref productBDO, ref message);
                   
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    throw new FaultException<ProductFault>
                        (new ProductFault(msg), msg);
                }
            }
            return result;
        }

        private void TranslateProductBDOToProductDTO(
            ProductBDO productBDO,
            Product product)
        {
            product.ProductId = productBDO.ProductId;
            product.ProductName = productBDO.ProductName;
            product.Price = productBDO.Price;
            product.ProductDescription = productBDO.ProductDescription;
            product.Stock = productBDO.Stock;
        }

        private void TranslateProductDTOToProductBDO(
            Product product,
            ProductBDO productBDO)
        {
            productBDO.ProductId = product.ProductId;
            productBDO.ProductName = product.ProductName;
            productBDO.Price = product.Price;
            productBDO.ProductDescription = product.ProductDescription;
            productBDO.Stock = product.Stock;
        }

    }
}
