﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace SeniorDating.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name{ get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Gender { get; set; }

        public string About { get; set; }

        public string LookingFor { get; set; }

        public bool Hidden { get; set; }
        public byte[] Picture { get; set; }

        public string File { get; set; }
       
        public string Content { get; set; }

        public virtual ICollection<Poke> Pokes { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<ApplicationUser> Friends { get; set; }
        public virtual ICollection<ApplicationUser> FriendRequests { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
 }