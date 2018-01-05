using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorDating.Models;
using System.Data.Entity;

namespace SeniorDating.Controllers
{
    [Authorize]
    public class ProfilController : BaseController
    {
        UserRepository repository = new UserRepository();

        
        public ActionResult Profiles(ApplicationUser model)
        {
            var user = repository.GetUser(User.Identity.Name);
            model.Age = user.Age;
            model.Name = user.Name;
            model.Gender = user.Gender;
            model.LookingFor = user.LookingFor;
            model.About = user.About;
            
            return View(model);
        }

        public ActionResult OtherProfiles(ApplicationUser model, string id)
        {
            var user = repository.GetUserById(id);
            model.Age = user.Age;
            model.Name = user.Name;
            model.Gender = user.Gender;
            model.LookingFor = user.LookingFor;
            model.About = user.About;

            return View("Profiles", model);
        }

        public ActionResult EditProfile(string id)
        {
            try
            {
                if (id == null)
                {
                    RedirectToAction("Index", "Home");
                }

                var user = db.Users.FirstOrDefault(u => u.Id == id);

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

            return View(id);
        }

        [HttpPost]
        public ActionResult EditProfile(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user2 = db.Users.FirstOrDefault(u => u.Id == user.Id);

                    user2.Name = user.Name;
                    user2.Age = user.Age;
                    user2.About = user.About;
                    user2.Hidden = user.Hidden;
                    

                    db.Entry(user2).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Profiles", "Profil", new { id = user.Id });

                }
                catch
                {
                    RedirectToAction("Index", "Home");
                }
            }

            return View("Profiles", user);

        }
    }
}