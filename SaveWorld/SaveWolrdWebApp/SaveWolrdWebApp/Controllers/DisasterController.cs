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
        // GET: Disaster
        public ActionResult Index()
        {
            DisasterServiceReference.DisasterServiceClient obj = new DisasterServiceReference.DisasterServiceClient();

            return View(obj.GetAllDisasters());
        }



        // GET: PersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        public void DeleteDisaster(int id)
        {
            using (var NWEntities = new SaveWorldEntities())
            {
                var disaster = (from p in NWEntities.Disasters
                                where p.id == id
                                select p).FirstOrDefault();
                if (disaster != null)

                {

                    NWEntities.Disasters.Remove(disaster);
                    NWEntities.SaveChanges();
                };
            }
        }

        // POST: PersonalDetails/Delete/5     
       
    }
}