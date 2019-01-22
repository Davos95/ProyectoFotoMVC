using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ProyectoFotoMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/materializeJS").Include(
                "~/Scripts/jquery-3.3.1.min.js",
                "~/Scripts/materialize.min.js",
                "~/Scripts/menuDropdown.js"
                ));

            bundles.Add(new StyleBundle("~/bundle/materializeCSS").Include(
                      "~/Content/materialize.css",
                      "~/Content/custom.css"
                      ));
        }
    }
}