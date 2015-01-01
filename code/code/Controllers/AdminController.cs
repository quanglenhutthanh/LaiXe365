using code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace code.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return RedirectToAction("Index", "AdminPageManager");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            string username = collection["username"];
            string pass = collection["pass"];
            string password = Utilities.EditString.mahoa_md5(pass);
            User user = db.Users.SingleOrDefault(u => u.Username == username && 
                                                 u.Password == password);
            if(user == null)
            {
                return View();
            }
            Session["admin"] = user;
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "AdminPageManager");
        }
    }
}
