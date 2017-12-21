using SeniorDating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace SeniorDating.Controllers
{
    public class PostsController : BaseController
    {
        public ActionResult Index(string id)
        {
            var posts = db.Posts.Where(x => x.To.Id == id).ToList();
            return View(new PostIndexViewModel { Id = id, Posts = posts });
        }

        public ActionResult Create(string id)
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post posts = db.Posts.Find(id);

            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Text")] Post posts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posts);
        }
        [HttpPost]
        public ActionResult Create(Post post, string id)
        {
            var userName = User.Identity.Name;
            var user = db.Users.Single(x => x.UserName == userName);
            post.From = user;

            var toUser = db.Users.Single(x => x.Id == id);
            post.To = toUser;

            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = id });
        }
    }

        public class PostIndexViewModel
        {
            public string Id { get; set; }
            public ICollection<Post> Posts { get; set; }
        }
    }
