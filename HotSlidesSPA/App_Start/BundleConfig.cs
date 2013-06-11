using System;
using System.Web.Optimization;

namespace HotSlidesSPA
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            bundles.Add(
              new ScriptBundle("~/scripts/vendor")
                .Include("~/scripts/jquery-{version}.js")
                .Include("~/scripts/knockout-{version}.debug.js")
                .Include("~/scripts/sammy-{version}.js")
                .Include("~/scripts/toastr.js")
                .Include("~/scripts/Q.js")
                .Include("~/scripts/breeze.debug.js")
                .Include("~/scripts/bootstrap.js")
                .Include("~/scripts/modernizr-2.6.2.js")
                .Include("~/scripts/moment.js")
                .Include("~/Content/Assets/plugins/breakpoints/breakpoints.js")
              //  .Include("~/Content/Assets/scripts/app.js")
               // .Include("~/Content/Assets/plugins/uniform/jquery.uniform.min.js")

                );

            bundles.Add(
              new StyleBundle("~/Content/css")
                .Include("~/Content/ie10mobile.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/bootstrap-responsive.css")
                .Include("~/Content/durandal.css")
                .Include("~/Content/toastr.css")
                .Include("~/Content/Assets/css/themes/default.css")
                .Include("~/Content/Assets/plugins/font-awesome/css/font-awesome.min.css")
                .Include("~/Content/Assets/css/style.css")
                .Include("~/Content/Assets/css/style-metro.css")
                .Include("~/Content/Assets/plugins/uniform/css/uniform.default.css")
                .Include("~/Content/Assets/css/style-responsive.css"));
        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new ArgumentNullException("ignoreList");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");

            //ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}