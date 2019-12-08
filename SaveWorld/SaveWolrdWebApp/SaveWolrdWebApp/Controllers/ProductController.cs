using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveWolrdWebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductServiceReference.ProductServiceClient obj = new ProductServiceReference.ProductServiceClient();

            return View(obj.GetAllProduct());
        }

        public ActionResult Details(ProductServiceReference.ProductB product)
        {
            ProductServiceReference.ProductServiceClient disClient = new ProductServiceReference.ProductServiceClient();

            //disClient.GetProduct(product.ProductId); 

            return View();
        }

        public ActionResult Create(ProductController product)
        {

            return View();
        }

        public ActionResult Delete(ProductServiceReference.ProductB product)
        {
            
            ProductServiceReference.ProductServiceClient disClient = new ProductServiceReference.ProductServiceClient();

            disClient.DeleteProduct(product.ProductId);


            return View();

        }

        public ActionResult Edit(ProductController product)
        {

            return View();
        }

    }
}