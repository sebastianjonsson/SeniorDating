using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorDating.Models;

namespace SeniorDating.Controllers
{
    public class ProfileController : BaseController
    {
        Logic.UserRepository repost = new Logic.UserRepository();

        [Authorize]
        public ActionResult Profiles(ApplicationUser model)
        {
            var user = repost.GetUser(User.Identity.Name);
            model.Age = user.Age;
            model.Name = user.Name;
            model.About = user.About;
            model.Gender = user.Gender;
            model.LookingFor = user.LookingFor;

            return View(model);

        }

    }
}