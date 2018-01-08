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
        [HttpPost, ActionName("newPost")]
        public void newPost([FromBody] PostViewModel model)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Posts.Add(new Post()
                    {
                        Text = model.Text,
                        From = db.Users.Single(x => x.Id == model.From),
                        To = db.Users.Single(x => x.Id == model.To),

                    });

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }


    }
}
