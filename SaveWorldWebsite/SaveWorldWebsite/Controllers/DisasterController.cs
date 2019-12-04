using SaveWorldWebsite.ProductServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveWorldWebsite.Controllers
{
    public class DisasterController : Controller
    {
        // GET: Disaster
        public ActionResult Index()
        {

            DisasterServiceReference.DisasterServiceClient obj = new DisasterServiceReference.DisasterServiceClient();

            return View(obj.GetAllDisasters());
        }

    }
}