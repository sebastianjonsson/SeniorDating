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

            for (int i = 0; i < 50; i++)
            {
                var user = new ApplicationUser { Name = "user" + i, UserName = $"user{i}@test.se", Email = $"user{i}@test.se", Age = 70, Gender = "Male", About = "Snygg" };

                userManager.CreateAsync(user, "User1!").Wait();

            }
           
            base.Seed(context);
        }
    }
}
