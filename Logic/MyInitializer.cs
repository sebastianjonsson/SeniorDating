using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SeniorDating.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using SeniorDating;

namespace Logic
{
    public class MyInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(store);

            for (int i = 1; i < 21; i++)
            {
                var user = new ApplicationUser
                {
                    Name = "User" + i,
                    UserName = $"User{i}@test.se",
                    Email = $"user{i}@test.se",
                    Gender = "Female",
                    Age = 123,
                    About = "I like to have fun and drink beer. :)",
                    LookingFor = "Both",
                    Hidden = false
                };

                userManager.CreateAsync(user, "User1!").Wait();
            }
            base.Seed(context);

        }
    }
}
