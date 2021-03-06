﻿using SeniorDating.Models;
using System.Linq;
using System.Web.Mvc;

namespace SeniorDating.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var db = new ApplicationDbContext();
                var name = User.Identity.Name;

                if (!string.IsNullOrEmpty(name))
                {
                    var user = db.Users.SingleOrDefault(x => x.UserName == name);

                    if (user != null)
                    {
                        var requests = user.FriendRequests;   
                        ViewData.Add("requests", requests);
                    }
                }
            }
            base.OnActionExecuted(filterContext);
        }

    }
}