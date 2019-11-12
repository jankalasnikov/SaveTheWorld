using SaveTheWorldDAL;
using SaveTheWorldModelL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorldController
{
   public class UserCtr
    {
        UserDAO userDAO = new UserDAO();

        public User GetUser(int id)
        {
            return userDAO.GetUser(id);
        }

        public void AddUser(string name, string password, string typeOfUser, string email, string address, string phone)
        {
            userDAO.AddUser(name, password, typeOfUser, email, address, phone);
        }

       /* public bool UpdateProduct(
            ref ProductBDO productBDO,
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
            //if (product.Discontinued == true
                && productInDB.UnitsOnOrder > 0)
            {
                message = "cannot discontinue this product";
                return false;
            }
            else
            {
            return productDAO.UpdateProduct(ref productBDO,
                ref message);
            // }
        }*/
    }
}
