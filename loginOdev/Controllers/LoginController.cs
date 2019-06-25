using loginOdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace loginOdev.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Authorize(loginOdev.Models.Usermodel usermodel)
        {
            using (logindatabaseEntities4 db = new logindatabaseEntities4())

            {
                var userDetails = db.User.Where(x => x.UserName == usermodel.UserName && x.Password == usermodel.Password).FirstOrDefault();
                if (userDetails == null)
                {

                    usermodel.Error = "Wrong Username or Password";
                  return View("Index", usermodel);
                }
                else
                {
                    Session["userId"] = userDetails.UserId;
                    Session["userName"] = userDetails.UserName;
                    return RedirectToAction("Index", "Home");
                }

            }
        }

        public ActionResult LogOut()
        {
            int userID = (int)Session["userId"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}