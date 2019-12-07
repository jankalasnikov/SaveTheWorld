using SaveWorldDAL;
using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldController
{
   public class ProductCtrB
    {
        ProductDAL productDal = new ProductDAL();
        public ProductB GetProduct(int id)
        {
            return productDal.GetProduct(id);
        }

        public void RemoveStockFromProduct(int id, int removeQuantity)
        {
            productDal.RemoveStockFromProduct(id, removeQuantity);
        }

        public void ReturnStock(int idOfProduct, int returnQuantity)
        {
            productDal.ReturnStock(idOfProduct, returnQuantity);
        }

        public ProductB GetProductByName(string name)
        {
            return productDal.GetProductByName(name);
        }

        public List<ProductB> GetAllProduct()
        {
            return productDal.GetAllProduct();
        }

        public bool CheckIfNameExists(string name)
        {
            return productDal.CheckIfNameExists(name);
        }


        public void DeleteProduct(int id)
        {
            productDal.DeleteProduct(id);
        }


        public bool UpdateProduct(ProductB product)
        {
            return productDal.UpdateProduct(product);
        }

        public bool CreateProduct(ProductB newProduct)
        {
            return productDal.CreateProduct(newProduct);
        }

    }
}