using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BabyDay.Models.Entity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }              

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one-to-one
            modelBuilder.Entity<Parent>().HasRequired<ApplicationUser>(s => s.UserProfile);
            //one-to-many
            modelBuilder.Entity<Child>()
                        .HasRequired<Parent>(s => s.Parent) // Child entity requires Parent 
                        .WithMany(s => s.Children); // Parent entity includes many Child entities
            base.OnModelCreating(modelBuilder);
        }
    }
}