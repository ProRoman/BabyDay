using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BabyDay.Models.Entity
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
        }

        public DbSet<Parent> Parents
        {
            get
            {
                ApplicationDbContext context = (ApplicationDbContext)Context;
                return context.Parents;
            }
        }

        public Parent FindParentByUserId(string id)
        {
            ApplicationDbContext context = (ApplicationDbContext)Context;
            return context.Parents.First(p => p.UserProfile.Id == id);
        }

        public void SaveOrUpdate()
        {
            ApplicationDbContext context = (ApplicationDbContext)Context;
            context.SaveChanges();
        }
    }
}