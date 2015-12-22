using System.Web;
using System.Web.Optimization;

namespace Technica
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scriptTop").Include(
                "~/Scripts/libs/modernizr.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/scriptIE8").Include(
                "~/Scripts/plugins/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/scriptBottom").Include(
                "~/Scripts/libs/jquery-1.11.1.min.js",
                "~/Scripts/libs/jquery-ui-1.10.4.custom.min.js",
                "~/Scripts/libs/jquery.easing.min.js",
                "~/Scripts/plugins/*.js",
                "~/Scripts/scripts.js"));


            bundles.Add(new StyleBundle("~/bundles/style").Include(
                "~/Content/masterslider/style/masterslider.css", 
                "~/Content/css/styles.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
