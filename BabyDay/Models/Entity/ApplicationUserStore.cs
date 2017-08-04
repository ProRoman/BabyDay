using Microsoft.AspNet.Identity.EntityFramework;

namespace BabyDay.Models.Entity
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}