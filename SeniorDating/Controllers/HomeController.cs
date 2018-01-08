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
            try
            {
                var users = db.Users.ToList();
                Random rnd = new Random();
                users = users.OrderBy(emp => rnd.Next()).Take(10).ToList();
                return View(users);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            try
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
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }
         
    }
}