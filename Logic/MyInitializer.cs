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

            var user = new ApplicationUser { Name = "Jan Jansson", UserName = $"jan@test.se", Email = $"jan@test.se", Age = 149, Gender = "Male", About = "Bänkar 100kg och har 1000 följare på instagram.", LookingFor = "Female", Hidden = false };

            userManager.CreateAsync(user, "User1!").Wait();

            var user2 = new ApplicationUser { Name = "Gun Ljung", UserName = $"gun@test.se", Email = $"gun@test.se", Age = 66, Gender = "Female", About = "Jag talar flytande sarkasm och killar under 180 kallar jag vänner.", LookingFor = "Male", Hidden = false };

            userManager.CreateAsync(user2, "User1!").Wait();

            var user3 = new ApplicationUser { Name = "Abdi Svensson", UserName = $"abdi@test.se", Email = $"abdi@test.se", Age = 100, Gender = "Male", About = "En gång träffade jag Zlatan på Ritz.", LookingFor = "Female", Hidden = false };

            userManager.CreateAsync(user3, "User1!").Wait();

            var user4 = new ApplicationUser { Name = "Ann-Britt Ronaldo", UserName = $"ann@test.se", Email = $"ann@test.se", Age = 123, Gender = "Female", About = "Jag gillar att resa, vara med vännerna och ha det kul :) följ mig på instagram.", LookingFor = "Male", Hidden = false };

            userManager.CreateAsync(user4, "User1!").Wait();

            var user5 = new ApplicationUser { Name = "Donald Trump", UserName = $"donald@test.se", Email = $"donald@test.se", Age = 69, Gender = "Male", About = "Looking for someone to have fun with.", LookingFor = "Both", Hidden = false };

            userManager.CreateAsync(user5, "User1!").Wait();

            var user6 = new ApplicationUser { Name = "Soffan Olsson", UserName = $"soffan@test.se", Email = $"soffan@test.se", Age = 130, Gender = "Female", About = "Heter egentligen Sofia men mina vänner kallar mig Soffan.", LookingFor = "Male", Hidden = false };

            userManager.CreateAsync(user6, "User1!").Wait();

            var user7 = new ApplicationUser { Name = "Fredrik Olsson", UserName = $"fredrik@test.se", Email = $"fredrik@test.se", Age = 77, Gender = "Male", About = "Jag gillar att cykla, har sju sm guld i bowling.", LookingFor = "Female", Hidden = false };

            userManager.CreateAsync(user7, "User1!").Wait();

            var user8 = new ApplicationUser { Name = "Märta Mårtensson", UserName = $"marta@test.se", Email = $"marta@test.se", Age = 111, Gender = "Female", About = "På fredagar hittar ni mig på dansgolvet.", LookingFor = "Male", Hidden = false };

            userManager.CreateAsync(user8, "User1!").Wait();

            var user9 = new ApplicationUser { Name = "Per Morberg", UserName = $"per@test.se", Email = $"per@test.se", Age = 65, Gender = "Male", About = "Jag är bäst på allt och har krulligt hår.", LookingFor = "Female", Hidden = false };

            userManager.CreateAsync(user9, "User1!").Wait();

            var user10 = new ApplicationUser { Name = "Kim Hansdotter", UserName = $"kim@test.se", Email = $"kim@test.se", Age = 99, Gender = "Female", About = "Streamar counter strike på twitch, annars hänger jag på gymmet", LookingFor = "Both", Hidden = false };

            userManager.CreateAsync(user10, "User1!").Wait();

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            context.Users.Add(user5);
            context.Users.Add(user6);
            context.Users.Add(user7);
            context.Users.Add(user8);
            context.Users.Add(user9);
            context.Users.Add(user10);
        }
    }
}
