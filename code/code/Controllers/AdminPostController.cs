using code.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace code.Controllers
{
    public class AdminPostController : admin_baseController
    {
        //
        // GET: /AdminPost/
        DBEntities db = new DBEntities();
        public ActionResult Index(int type)
        {
            return View(db.Posts.Where(p=>p.Type==type).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Post post, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string imageName = "";
                if (file != null && file.ContentLength > 0)
                {
                    int size = file.ContentLength;
                    if (size >= 300000)
                    {
                        ViewBag.Error = "Kích thước file quá lớn";
                        return View();
                    }
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/baiviet"), fileName);
                    file.SaveAs(path);
                    imageName = fileName.ToString();
                }
                post.Image = imageName;
                post.Type = 1;
                post.Alias = Utilities.EditString.BoDauTrenChuoi(post.Title);
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index", new { type=1});
            }
            return View();
        }
    }
}
