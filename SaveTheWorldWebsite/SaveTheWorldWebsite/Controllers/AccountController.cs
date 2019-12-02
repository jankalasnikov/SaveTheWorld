using SaveTheWorldWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTheWorldWebsite.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AccountRegisterViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                // Instantiate a User object
                var user = new User { UserName = viewModel.Email, Email = viewModel.Email };

                // Create the user

                // If the user was successfully created...

                // Sign-in the user and redirect them to the web app's "Home" page

                // If there were errors...

                // Add model errors
            }

            // Add model errors
            return View(viewModel);
        }

    }
}