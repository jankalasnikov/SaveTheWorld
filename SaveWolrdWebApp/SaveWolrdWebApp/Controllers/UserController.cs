using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveWolrdWebApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UserServiceReference.UserClient obj = new UserServiceReference.UserClient();
            UserServiceReference.UserB user = new UserServiceReference.UserB(); 

            return View(obj.GetAllUsers());
        }

        public ActionResult Details(UserController user)
        {
            return View();
        }

        public ActionResult Create(UserController user)
        {

            try
            {
                using (UserServiceReference.UserClient wcf = new UserServiceReference.UserClient())
                {
                   
                }

                return RedirectToAction("Index");
            }
            catch
            { 
            return View();
            }
        }

        public ActionResult Delete(UserController user)
        {
            using (UserServiceReference.UserClient wcf = new UserServiceReference.UserClient())
            {
             //   wcf.DeleteUser(user); 
            }
            
            return View();
        }

        public ActionResult Edit(UserController user)
        {
            using (UserServiceReference.UserClient client = new UserServiceReference.UserClient())
            {
               
            }
            return View();
        }
    }
}