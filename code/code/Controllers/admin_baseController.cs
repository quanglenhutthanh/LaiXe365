using code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace code.Controllers
{
    public class admin_baseController : Controller
    {
        //
        // GET: /admin_base/

        DataContext db = new DataContext();
        [NonAction]
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            User su = (User)Session["admin"];

            if (su == null)
            {
                filterContext.Result = new RedirectResult("~/admin/login");
            }
            base.OnActionExecuting(filterContext);
        }

    }
}
