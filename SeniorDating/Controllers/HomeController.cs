using SeniorDating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var users = from m in db.Users
                        where m.Hidden == false
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Name.Contains(searchString));
            }

            return View("Index", users);
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

        public ActionResult Friends(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}