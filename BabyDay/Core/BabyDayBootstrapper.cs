using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace BabyDay.Core
{
    public class BabyDayBootstrapper
    {
        public static void Initialize()
        {
            // Set the dependency resolver to be Autofac.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(BuildAutofacContainer()));
        }

        private static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();

            // Register MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            RegisterTypes(builder);
            
            var container = builder.Build();

            return container;
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {

        }
    }
}