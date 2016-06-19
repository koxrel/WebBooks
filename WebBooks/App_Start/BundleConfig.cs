using System.Web;
using System.Web.Optimization;

namespace WebBooks
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/assets/css").Include(
                "~/assets/bootstrap/css/bootstrap.css",
                "~/assets/css/stylesheet.css",
                "~/assets/css/skins.css",
                "~/assets/font-awesome/css/font-awesome.min.css"
                ));

            bundles.Add(new ScriptBundle("~/assets/jquery").Include(
                "~/assets/js/jquery-2.0.3.min.js",
                "~/assets/js/jquery-migrate-1.2.1.min.js"
                ));

            bundles.Add(new StyleBundle("~/assets/plugins").Include(
                "~/assets/UItoTop/css/ui.totop.css",
                "~/assets/prettyPhoto/css/prettyPhoto.css"
                ));

            bundles.Add(new StyleBundle("~/assets/rs-plugin/css").Include(
                "~/assets/rs-plugin/css/settings.css"
                ));

            bundles.Add(new ScriptBundle("~/assets/bootstrap").Include(
                "~/assets/bootstrap/js/bootstrap.min.js"
                ));
            
            bundles.Add(new ScriptBundle("~/assets/revolution").Include(
                "~/assets/rs-plugin/js/jquery.themepunch.tools.min.js",
                "~/assets/rs-plugin/js/jquery.themepunch.revolution.min.js",
                "~/assets/carouFredSel-6.2.1/jquery.carouFredSel-6.2.1.js",
                "~/assets/prettyPhoto/js/jquery.prettyPhoto.js",
                "~/assets/jflickrfeed/jflickrfeed.min.js",
                "~/assets/UItoTop/js/easing.js",
                "~/assets/UItoTop/js/jquery.ui.totop.min.js",
                "~/assets/isotope-site/jquery.isotope.min.js",
                "~/assets/FitVids.js/jquery.fitvids.js"
                ));
        }
    }
}
