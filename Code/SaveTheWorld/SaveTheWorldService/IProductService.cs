﻿using SaveTheWorldModelL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SaveTheWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [FaultContract(typeof(ProductFault))]
        Product GetProduct(int id);

        [OperationContract]
        [FaultContract(typeof(ProductFault))]
        bool UpdateProduct(ref Product product, ref string message);

     
    }

    
}
