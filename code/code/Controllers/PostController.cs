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
        public ActionResult Index(int? page)
        {
            var posts = db.Posts.Where(p => p.Type == 1).ToList();
            var pageNumber = page ?? 1;
            ViewBag.onePageOfSanPham = posts.ToPagedList(pageNumber, 10);
            return View();
        }

        public ActionResult Comment(int? page)
        {
            var posts = db.Posts.Where(p => p.Type == 2).ToList();
            var pageNumber = page ?? 1;
            ViewBag.onePageOfSanPham = posts.ToPagedList(pageNumber, 10);
            return View();
        }

        public ActionResult PostDetail(string alias)
        {
            Post post = db.Posts.SingleOrDefault(p => p.Alias.Equals(alias));
            if (post != null)
            {
                post.PostView++;
                db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return View(post);
            }
            return View();
        }
    }
}
