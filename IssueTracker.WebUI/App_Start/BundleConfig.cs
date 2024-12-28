using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace IssueTracker.WebUI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/wwwroot/scripts/WebForms/WebForms.js",
                            "~/wwwroot/scripts/WebForms/WebUIValidation.js",
                            "~/wwwroot/scripts/WebForms/MenuStandards.js",
                            "~/wwwroot/scripts/WebForms/Focus.js",
                            "~/wwwroot/scripts/WebForms/GridView.js",
                            "~/wwwroot/scripts/WebForms/DetailsView.js",
                            "~/wwwroot/scripts/WebForms/TreeView.js",
                            "~/wwwroot/scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/wwwroot/scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/wwwroot/scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/wwwroot/scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/wwwroot/scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/wwwroot/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/wwwroot/scripts/jquery-3.4.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                            "~/wwwroot/scripts/bootstrap.min.js"));
        }
    }
}