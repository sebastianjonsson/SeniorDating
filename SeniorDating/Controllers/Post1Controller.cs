using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeniorDating.Models;
using System.Data.Entity;

namespace SeniorDating.Controllers
{
    
    public class PostsController : BaseController
    {
        // GET: Posts
        public ActionResult Index(string id)
        {
            try
            {
                var post = db.Posts.Include(x => x.From).Where(i => i.To.Id == id).ToList();
                return View(new PostIndexViewModel { Id = id, Posts = post });
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();

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
                this.Id = Id;
            }

        }
    }
}