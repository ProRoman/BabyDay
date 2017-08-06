using Autofac;
using Autofac.Integration.Mvc;
using BabyDay.Models.Entity;
using BabyDay.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Owin;
using System.Web;
using System.Web.Mvc;

namespace BabyDay
{
    public partial class Startup
    {
        public void InitializeDIContainer(IAppBuilder app)
        {
            var container = BuildAutofacContainer();

            // Set the dependency resolver to be Autofac.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // OWIN MVC SETUP:

            // Register the Autofac middleware FIRST, then the Autofac MVC middleware.
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }

        private IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();

            RegisterTypes(builder);

            // Register MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);            
            
            var container = builder.Build();

            return container;
        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>().InstancePerRequest();
        }
    }
}