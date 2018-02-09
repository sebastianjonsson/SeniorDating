using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SeniorDating.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.Friends).WithMany()
                .Map(x => x.ToTable("Friends"));
            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.FriendRequests).WithMany()
                .Map(x => x.ToTable("FriendRequests"));
            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.Posts).WithRequired(x => x.To);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Poke> Pokes { get; set; }
    }
}