using SeniorDating.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace SeniorDating.Controllers
{
    public class PokeController : BaseController
    {
        // GET: Poke
        public ActionResult Index(string id)
        {
            try
            {
                var pokes = db.Pokes.Include(x => x.From).Where(x => x.To.Id == id).ToList();
                return View(new PokeIndexViewModel { Id = id, Pokes = pokes });
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();

        }

        public ActionResult Poke(Poke poke, string id)
        {
            try
            {
                var user = User.Identity.GetUserId();
                var fromUser = db.Users.Single(x => x.Id == user);
                var to = db.Users.Single(x => x.Id == id);

                poke.From = fromUser;
                poke.To = to;

                db.Pokes.Add(poke);
                db.SaveChanges();
            }

            catch
            {

            }
            return RedirectToAction("OtherProfiles", "Profil", new { Id = id });
        }
    }
    public class PokeIndexViewModel
    {
        public string Id { get; set; }
        public ICollection<Poke> Pokes { get; set; }
        public PokeIndexViewModel()
        {

        }
        public PokeIndexViewModel(string Id)
        {
            using (var db = new ApplicationDbContext())
            {
                this.Pokes = db.Pokes.Include(x => x.From).Where(i => i.To.Id == Id).ToList();
                this.Id = Id;
            }

        }
    }
}