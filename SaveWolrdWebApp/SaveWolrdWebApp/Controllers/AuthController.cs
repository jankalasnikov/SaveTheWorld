using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveWolrdWebApp.Controllers
{
    public class AuthController : Controller
    {

        UserServiceReference.UserClient wcfUserService;
        // GET: Auth
        public AuthController()
        {
            wcfUserService = new UserServiceReference.UserClient();

        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpGet]
        public ActionResult Login()
        {
           
            return View("Login");
        }

     /*   [HttpPost]
        public ActionResult Login(FormCollection collection)
        {

            var isAuthenticated = false;
            var name = collection["name"];
            var password = collection["password"];

            #region validation
            bool valid = true;
            if (string.IsNullOrWhiteSpace(name))
            {
                valid = false;
                ViewBag.usernameEmpty = "Username is a required field";
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                valid = false;
                ViewBag.passwordEmpty = "Password is a required field";
            }
            //checking if user exists in db with the credentials provided
            if (valid)
            {
                try
                {
                    isAuthenticated = Int32.Parse(wcfUserService.GetUserByName(name));
                }
                catch (Exception)
                {
                    ViewBag.massError = "Internal error has occurred please try again after 5 minutes";
                    return View("Login");
                };

                if (isAuthenticated)
                {
                    HttpCookie authCookie = new HttpCookie("auth");
                    var user = wcfUserService.GetUserByName(name);
                    authCookie.Value = wcfUserService.GetUserIDByName(name).ToString();
                    Response.Cookies.Add(authCookie);
                    Response.Cookies["auth"].Expires.AddDays(3);
                    return Redirect("~/Disaster/Index");//TODO user should be redirected to index page of logged in users
                }
                else
                {
                    ViewBag.username = name;
                    ViewBag.errorNotExisting = "The given credentials do not match";
                    return View("Login");
                }
            }
            else
            {
                ViewBag.username = name;
                return View("Login");
            }

        }

        [HttpPost]
        public void Logout()
        {
            var authCookie = Request.Cookies["auth"];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(authCookie);
                Response.Redirect("~/");
            }
        }
        */
    }
}
