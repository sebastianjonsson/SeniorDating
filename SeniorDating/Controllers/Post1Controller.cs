using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorDating.Models;
using System.Data.Entity;

namespace SeniorDating.Controllers
{
    
    public class PostsController : Controller
    {
        // GET: Posts
        public ActionResult Index(string profileId)
        {
            using (var db = new ApplicationDbContext())
            {
                var posts = db.Posts.Include(x => x.From).Where(i => i.To.Id == profileId).ToList();
                return View(new PostIndexViewModel { Id = profileId, Posts = posts });
            }

        }
        
    }
    public class PostIndexViewModel
    {
        public string Id { get; set; }
        public ICollection<Post> Posts { get; set; }
        public PostIndexViewModel()
        {

        }
        public PostIndexViewModel(string Id)
        {
            using (var db = new ApplicationDbContext())
            {
                this.Posts = db.Posts.Include(x => x.From).Where(i => i.To.Id == Id).ToList();
                try
                {

                }
                catch
                {

                }
                this.Id = Id;
            }

        }
    }
}