﻿using code.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace code
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            if (!File.Exists(Server.MapPath("~/Count_Visited.txt")))
                File.WriteAllText(Server.MapPath("~/Count_Visited.txt"), "0");
            Application["DaTruyCap"] = int.Parse(File.ReadAllText(Server.MapPath("~/Files/Count_Visited.txt")));
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Tăng số đang truy cập lên 1 nếu có khách truy cập
            if (Application["DangTruyCap"] == null)
                Application["DangTruyCap"] = 1;
            else
                Application["DangTruyCap"] = (int)Application["DangTruyCap"] + 1;

            // Tăng số đã truy cập lên 1 nếu có khách truy cập
            Application["DaTruyCap"] = (int)Application["DaTruyCap"] + 1;
            File.WriteAllText(Server.MapPath("~/Files/Count_Visited.txt"), Application["DaTruyCap"].ToString());

        }

        void Session_End(object sender, EventArgs e)
        {
            //Khi hết session hoặc người dùng thoát khỏi website thì giảm số người đang truy cập đi 1
            Application["DangTruyCap"] = (int)Application["DangTruyCap"] - 1;
        }  
    }
}