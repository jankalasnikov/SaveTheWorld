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

            return View(obj.GetAllUsers());
        }

        public ActionResult Details(UserController user)
        {
            return View();
        }

        public ActionResult Create(UserController user)
        {

            return View();
        }

        public ActionResult Delete(UserController user)
        {

            return View();
        }

        public ActionResult Edit(UserController user)
        {

            return View();
        }
    }
}