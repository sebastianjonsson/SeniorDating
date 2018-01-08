using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorDating.Models;

namespace SeniorDating.Controllers
{
    public class FriendController : BaseController
    {
        // GET: Friend
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AcceptRequest(string id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                    var user = db.Users.SingleOrDefault(x => x.Id == userId);
                    var friend = db.Users.SingleOrDefault(x => x.Id == id);
                    user.Friends.Add(friend);
                    friend.Friends.Add(user);

                    user.FriendRequests.Remove(friend);

                    db.SaveChanges();
                    return RedirectToAction("Friends", "Home", new { id = userId });
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }

        public ActionResult DeclineRequest(string id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                    var user = db.Users.SingleOrDefault(x => x.Id == userId);

                    var friend = db.Users.SingleOrDefault(x => x.Id == id);
                    user.FriendRequests.Remove(friend);
                    db.SaveChanges();

                    return RedirectToAction("Friends", "Home", new { id = userId });
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }

        public ActionResult AddRequest(string id)
        {
            var friend = db.Users.SingleOrDefault(x => x.Id == id);
            var userId = User.Identity.GetUserId();
            var user = db.Users.SingleOrDefault(x => x.Id == userId);

            friend.FriendRequests.Add(user);

            db.SaveChanges();

            return RedirectToAction("OtherProfiles", "Profil", new { id = id });
        }
    }
}