using System.Web;
using System.Web.Optimization;

namespace BankLocations
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {   
            bundles.Add(new ScriptBundle("~/bundles/vendor")
                .Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",                 
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-route.min.js",
                        "~/Scripts/ui-bootstrap-tpls-2.5.0.min.js",
                        "~/Scripts/jstree/jstree.min.js"
                      ));

            //~/Bundles/App/Main/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/js")                    
                    .IncludeDirectory("~/App", "*.js", true)
                );

            bundles.Add(new StyleBundle("~/Content/css")
                
                .Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css")
                        .Include("~/Scripts/jstree/themes/default/style.min.css", new CssRewriteUrlTransform())
                        .Include("~/Scripts/jstree/themes/proton/style.css", new CssRewriteUrlTransform())
                      );
        }
    }
}
