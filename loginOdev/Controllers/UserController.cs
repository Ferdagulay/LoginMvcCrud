using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using loginOdev.Models;


namespace loginOdev.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult AddOrEdit()
        {
            Usermodel usermodel = new Usermodel();

            return View(usermodel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Usermodel Usermodel)
        {
            using (logindatabaseEntities4 dbModel = new logindatabaseEntities4())
            {
                if (dbModel.User.Any(x => x.UserName == Usermodel.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("AddOrEdit", Usermodel);
                }

                User u = new User();
                u.UserName = Usermodel.UserName;
                u.Password = Usermodel.Password;
                u.UserId = Usermodel.UserId;
                dbModel.User.Add(u);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("AddOrEdit", new Usermodel());
        }
    }
}