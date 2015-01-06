using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using code.Models;
namespace code.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/
        DBEntities db = new DBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comment(int? page)
        {
            var posts = db.Posts.Where(p => p.Type == 2).ToList();
            var pageNumber = page ?? 1;
            ViewBag.onePageOfSanPham = posts.ToPagedList(pageNumber, 10);
            return View();
        }
    }
}
