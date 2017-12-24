using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeniorDating.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            var users = db.Users.ToList();
            Random rnd = new Random();
            users = users.OrderBy(emp => rnd.Next()).Take(10).ToList();
            return View(users);
            
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