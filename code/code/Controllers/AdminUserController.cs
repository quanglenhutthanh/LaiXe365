using code.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace code.Controllers
{
    public class AdminUserController : admin_baseController
    {
        //
        // GET: /AdminUser/
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = code.Utilities.EditString.mahoa_md5(user.Password);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);
            UserViewModel u = new UserViewModel();
            u.Id = user.Id;
            u.Username = user.Username;
            u.Password = user.Password;
            u.ConfirmedPass = user.Password;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(u);
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            if(user.Password != user.ConfirmedPass)
            {
                ViewBag.ThongBao = "Mật khẩu và mật khẩu xác nhận không giống";
                return View(user);
            }
            User u = db.Users.Find(user.Id);
            if(u==null)
            {
                return HttpNotFound();
            }
            u.Password = Utilities.EditString.mahoa_md5(user.Password);
            db.Entry(u).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
    }
}
