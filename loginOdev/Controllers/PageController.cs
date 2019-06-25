using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using loginOdev.Models;

namespace loginOdev.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
   
        logindatabaseEntities4 db = new logindatabaseEntities4();

        public ActionResult Index()
        {
            Pages pages = new Pages();


           /* var std = db.Pages.Where(s => s.PageId == pages.PageId ).FirstOrDefault();*/
            return View(db.Pages.ToList());
        }

        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(Pages pages)
        {

            if (ModelState.IsValid)
            {
                db.Pages.Add(pages);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(pages);
            }
        }



        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

    }
}