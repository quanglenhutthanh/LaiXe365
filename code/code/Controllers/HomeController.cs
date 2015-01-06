using code.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace code.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DBEntities db = new DBEntities();
        //DataContext db = new DataContext();
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
        public ActionResult PageByTitle(string title)
        {
            //string[] aliasArray = title.Split((".").ToCharArray());
            //if(aliasArray.Count() > 1)
            //{
            //    string alias = aliasArray[0];
                var pages = db.Pages.Where(p => p.Alias.Equals(title)).ToList();
                if (pages.Count > 0)
                {
                    var page = pages.First();
                    ViewBag.Content = page.Content;
                }
            //}
           
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
        public ActionResult header()
        {
            string headerFilePath = Server.MapPath("~/Files/header.txt");
            ViewBag.Text = Utilities.File.ReadFile(headerFilePath);
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult marquee()
        {
            string marqueeFilePath = Server.MapPath("~/Files/marquee.txt");
            ViewBag.Text = Utilities.File.ReadFile(marqueeFilePath);
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult menu()
        {
            return PartialView(db.Pages.OrderBy(p=>p.PageOrder).ToList());
        }

        [ChildActionOnly]
        public ActionResult moduleContact()
        {
            return PartialView(db.Contacts.ToList());
        }

        [ChildActionOnly]
        public ActionResult slider()
        {
            try
            {
                string slideImagePath = Server.MapPath("~/Content/images/slider");
                DirectoryInfo di = new DirectoryInfo(slideImagePath);
                FileInfo[] files = di.GetFiles();
                List<string> imgNames = new List<string>();
                foreach (FileInfo file in files)
                {
                    imgNames.Add(file.Name);
                }
                ViewBag.FileNames = imgNames;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult comment()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult footer()
        {
            string footerFilePath = Server.MapPath("~/Files/footer.txt");
            ViewBag.Text = Utilities.File.ReadFile(footerFilePath);
            return PartialView();
        }
    }
}
