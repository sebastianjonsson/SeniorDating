using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorDating.Models;

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
    }
}