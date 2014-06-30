using System.Web;
using System.Web.Optimization;

namespace LeMoulinDaCote
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/fotorama.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/fonts/font-awesome/css/font-awesome.css",
                      "~/Content/fotorama.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                    "~/Content/bootstrapAdmin.css",
                    "~/fonts/font-awesome/css/font-awesome.css",
                    "~/Content/plugins/morris/morris-0.4.3.min.css",
                    "~/Content/plugins/timeline/timeline.css",
                    "~/Content/sb-admin.css"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/AdminScript").Include(
                    "~/Scripts/plugins/metisMenu/jquery.metisMenu.js",
                    "~/Scripts/sb-admin.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
