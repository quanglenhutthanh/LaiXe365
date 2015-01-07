using code.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace code.Controllers
{
    public class AdminPageManagerController : admin_baseController
    {
        //
        // GET: /AdminPageManager/
        DBEntities db = new DBEntities();
        public ActionResult Index()
        {
            return View(db.Pages.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Alias = Utilities.EditString.BoDauTrenChuoi(page.Title);
                db.Pages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id=0)
        {
            Page page = db.Pages.Find(id);
            if(page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Page page)
        {
            if(ModelState.IsValid)
            {
                page.Alias = Utilities.EditString.BoDauTrenChuoi(page.Title);
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(page);
        }

        public ActionResult Delete(int id = 0)
        {
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            db.Pages.Remove(page);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
