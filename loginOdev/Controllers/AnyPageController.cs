using loginOdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace loginOdev.Controllers
{
    public class AnyPageController : Controller
    {
        logindatabaseEntities4 db = new logindatabaseEntities4();

        // GET: AnyPage
        public ActionResult CreatePage(string url)
        {
            Pages newPage = new Pages();
            newPage.PageUrl = url;
            return View("CreatePageView", newPage);
        }

        [HttpPost]
        public ActionResult CreatePage(Pages pages)
        {
            if(pages.PageUrl == null)
                Console.WriteLine("HATAAA");


            db.Pages.Add(pages);
            db.SaveChanges();

            //Sayfa kaydedildi. Sayfayi gostermek icin TEST methoduna yonlendir.
            return RedirectToAction("Test", "AnyPage", new { url = pages.PageUrl });
        }


        public ActionResult Test(string url)
        {
            //return View();

            Pages p = db.Pages.Where(x => x.PageUrl == url).FirstOrDefault();
            if(p == null)
            {

                return RedirectToAction("CreatePage", "AnyPage", new { url = url});


            }

            p.PageContent = p.PageContent.Replace("\\n", "<br>");
            return View("AnyPageView", p);
            
        }
    }
}