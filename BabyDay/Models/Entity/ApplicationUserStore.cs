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

        public TEntity FindEntityById<TEntity, TId>(TId id) where TEntity : class, IEntityModel<TId>
        {
            ApplicationDbContext context = (ApplicationDbContext)Context;
            return context.Set<TEntity>().First(p => p.Id.Equals(id));
        }

        public void SaveOrUpdate()
        {
            ApplicationDbContext context = (ApplicationDbContext)Context;
            context.SaveChanges();
        }
    }
}