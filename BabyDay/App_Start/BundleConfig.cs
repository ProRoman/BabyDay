using System.Web.Optimization;

namespace BabyDay
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js"));
           
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/jumbotron.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-jumbotron").Include(
                "~/Content/bootstrap.css",
                "~/Content/jumbotron.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-signin").Include(
                "~/Content/bootstrap.css",
                "~/Content/signin.css"));
        }
    }
}
