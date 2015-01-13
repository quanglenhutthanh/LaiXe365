using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace code.Controllers
{
    public class AdminSettingController : admin_baseController
    {
        //
        // GET: /AdminSetting/

        public ActionResult Index()
        {
            string headerFilePath = Server.MapPath("~/Files/header.txt");
            string footerFilePath = Server.MapPath("~/Files/footer.txt");
            string marqueeFilePath = Server.MapPath("~/Files/marquee.txt");
            ViewBag.Header = Utilities.File.ReadFile(headerFilePath);
            ViewBag.Footer = Utilities.File.ReadFile(footerFilePath);
            ViewBag.Marquee = Utilities.File.ReadFile(marqueeFilePath);
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(FormCollection collection)
        {
            string txtHeader = collection["txtTextHeader"];
            string txtFooter = collection["txtTextFooter"];
            string marquee = collection["txtMarquee"];
            string headerFilePath = Server.MapPath("~/Files/header.txt");
            string footerFilePath = Server.MapPath("~/Files/footer.txt");
            string marqueeFilePath = Server.MapPath("~/Files/marquee.txt");
            Utilities.File.WriteFile(headerFilePath, txtHeader);
            Utilities.File.WriteFile(marqueeFilePath, marquee);
            Utilities.File.WriteFile(footerFilePath, txtFooter);
            ViewBag.Header = txtHeader;
            ViewBag.Footer = txtFooter;
            ViewBag.Marquee = marquee;
            return View();
        }

        public ActionResult ImageManager() 
        {
            return View();
        }
    }
}
