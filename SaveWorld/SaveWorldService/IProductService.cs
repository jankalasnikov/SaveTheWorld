using SaveWorldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SaveWorldService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        ProductB GetProduct(int id);

        [OperationContract]
        ProductB GetProductByName(string name);

        [OperationContract]
        List<ProductB> GetAllProduct();

        [OperationContract]
        void RemoveStockFromProduct(int id, int removeQuantity);

        [OperationContract]
        void ReturnStock(int idOfProduct, int returnQuantity);
        [OperationContract]
        void DeleteProduct(int id);
        [OperationContract]
        bool UpdateProduct(ProductB product);

        [OperationContract]
        bool CheckIfNameExists(string name);

        [OperationContract]
        bool CreateProduct(ProductB newProduct);

    }
}
