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

        public ActionResult Create(DisasterServiceReference.DisasterB disaster)
        {

            DisasterServiceReference.DisasterServiceClient disClient = new DisasterServiceReference.DisasterServiceClient();

            //   disClient.CreateDisaster(disaster);

            return View();
        }

        public ActionResult Delete(DisasterServiceReference.DisasterB disaster)
        {
            DisasterServiceReference.DisasterServiceClient disClient = new DisasterServiceReference.DisasterServiceClient();

            disClient.DeleteDisaster(disaster.DisasterId);


            return View();
        }
        /* public ActionResult Donate(string valueINeed)
         { 

             BankAccountServiceReference.BankAccountServiceClient bank = new BankAccountServiceReference.BankAccountServiceClient();
         bank.donateToSpecificDisaster(100, 2,3); 
             return View();
         }
     */

        public ActionResult Edit(DisasterServiceReference.DisasterB disaster)
        {


            return View();
        }

        public ActionResult Donate(BankAccountServiceReference.BankAccountB bank)
        {
            BankAccountServiceReference.BankAccountServiceClient bankClient = new BankAccountServiceReference.BankAccountServiceClient();

            bankClient.donateMoneyToAllDisasters(bank.Amount, 2);

            return View();
        }

    }

}

