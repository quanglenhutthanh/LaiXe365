using code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace code.Controllers
{
    public class AdminPostController : Controller
    {
        //
        // GET: /AdminPost/
        DBEntities db = new DBEntities();
        public ActionResult Index(int type)
        {
            return View(db.Posts.Where(p=>p.Type==2).ToList());
        }

    }
}
