using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorDating.Models;
using System.Net;

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
                    return RedirectToAction("Friends", "Friend", new { id = userId });
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

                    return RedirectToAction("Friends", "Friend", new { id = userId });
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