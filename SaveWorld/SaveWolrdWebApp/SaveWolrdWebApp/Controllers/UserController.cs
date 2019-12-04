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
    }
}