using MeetingMinutesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MeetingMinutesSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(Account account)
        {
            if (ModelState.IsValid)
            {
                Models.Roles status = GetUserValidity(account);
                bool IsAdmin = false;
                if (status == Models.Roles.AuthenticatedAdmin)
                {
                    IsAdmin = true;
                }
                else
                {
                    IsAdmin = false;
                }

                FormsAuthentication.SetAuthCookie(account.UserName, false);
                Session["IsAdmin"] = IsAdmin;
                Session["UserName"] = account.UserName;
                return RedirectToAction("Index", "MinutesModels");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        private Models.Roles GetUserValidity(Account account)
        {
            if (account.UserName == "Admin" && account.Password == "Admin")
            {
                return Models.Roles.AuthenticatedAdmin;
            }
            else
            {
                return Models.Roles.NonAuthenticatedUser;
            }
        }
    }
}