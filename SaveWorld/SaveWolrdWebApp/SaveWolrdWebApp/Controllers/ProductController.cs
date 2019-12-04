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
    }
}