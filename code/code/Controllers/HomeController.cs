using code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace code.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            
            var pages = db.Pages.Where(p=>p.IsHomePage==true).ToList();
            if(pages.Count > 0)
            {
                var page = pages.First();
                ViewBag.Content = page.Content;
            }
            
            return View();
        }

        public ActionResult page(int id)
        {
            var page = db.Pages.SingleOrDefault(p => p.ID == id);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = page.Title;
            ViewBag.Content = page.Content;
            return View();
        }

        [ChildActionOnly]
        public ActionResult menu()
        {
            return PartialView(db.Pages.ToList());
        }
    }
}
