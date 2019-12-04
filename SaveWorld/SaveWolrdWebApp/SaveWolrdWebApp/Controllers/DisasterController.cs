using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SaveWolrdWebApp.Controllers
{
    public class DisasterController : Controller
    {
        DisasterServiceReference.DisasterServiceClient disasterService = new DisasterServiceReference.DisasterServiceClient(); 
        
        // GET: Disaster
        public ActionResult Index()
        {
            DisasterServiceReference.DisasterServiceClient obj = new DisasterServiceReference.DisasterServiceClient();

            return View(obj.GetAllDisasters());
        }

        public ActionResult Details(DisasterController disaster)
        {
            return View();
        }

        public ActionResult Create(DisasterController disaster)
        {
        
            return View();
        }

        public ActionResult Delete(DisasterController disaster)
        {  
            return View();
        }

        public ActionResult Edit(DisasterController disaster)
        {

            return View();
        }
    }

}