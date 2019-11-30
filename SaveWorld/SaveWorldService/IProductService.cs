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
    }
}
