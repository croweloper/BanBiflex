using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanBif.BanBiFlex.App.IP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string ip = Request.UserHostAddress;
            string hostName = Request.UserHostName;
            ViewBag.ip = ip;
            ViewBag.hostName = hostName;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}