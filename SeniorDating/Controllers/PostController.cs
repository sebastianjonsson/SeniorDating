using SeniorDating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeniorDating.Controllers
{
    public class PostController : ApiController
    {

        // POST: api/Post
        [HttpPost, ActionName("addPost")]
        public void addPost([FromBody] PostViewModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Posts.Add(new Post()
                {
                    Text = model.Text,
                    From = db.Users.Single(x => x.Id == model.FromUsername),
                    To = db.Users.Single(x => x.Id == model.ToUsername),
                    
                });

                db.SaveChanges();
            }
        }


    }
}
