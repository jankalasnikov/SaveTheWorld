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
        BankAccountServiceReference.BankAccountB userBankId = new BankAccountServiceReference.BankAccountB();
        BankAccountServiceReference.BankAccountB disasterBankId = new BankAccountServiceReference.BankAccountB();
        // GET: Disaster
        public ActionResult Index()
        {
            DisasterServiceReference.DisasterServiceClient disClient = new DisasterServiceReference.DisasterServiceClient();

            return View(disClient.GetAllDisasters());
        }

        public ActionResult Details(DisasterController disaster)
        {
            return View();
        }

        public ActionResult Create(DisasterServiceReference.DisasterB disaster)
        {
            DisasterServiceReference.DisasterServiceClient disClient = new DisasterServiceReference.DisasterServiceClient();
            disClient.CreateDisaster();

            return View();
        }
        public ActionResult Donate(int disasterAccId, decimal amount)
        {
            BankAccountServiceReference.BankAccountServiceClient bank = new BankAccountServiceReference.BankAccountServiceClient();
            bank.donateToSpecificDisaster(amount, 2, disasterAccId);
            return View();
        }

        public ActionResult Delete(DisasterServiceReference.DisasterB disaster)
        {
            DisasterServiceReference.DisasterServiceClient disClient = new DisasterServiceReference.DisasterServiceClient();
            
            disClient.DeleteDisaster(disaster.DisasterId);
                
              
            
            return View();
        }

        public ActionResult Edit( )
        {
            BankAccountServiceReference.BankAccountServiceClient bank = new BankAccountServiceReference.BankAccountServiceClient();
            bank.donateToSpecificDisaster(2, 2, 5);
            return View();
        }
    }

}