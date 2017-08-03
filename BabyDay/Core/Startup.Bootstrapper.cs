using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Owin;

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

            // Register MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            RegisterTypes(builder);
            
            var container = builder.Build();

            return container;
        }

        private void RegisterTypes(ContainerBuilder builder)
        {

        }
    }
}