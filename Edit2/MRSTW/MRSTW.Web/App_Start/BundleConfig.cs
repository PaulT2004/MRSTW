using System.Web;
using System.Web.Optimization;

namespace MRSTW.Web
{
     public class BundleConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {
              
               bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.js"));

               bundles.Add(new StyleBundle("~/Home/css").Include(
                    "~/Home/bootstrap.css",
                    "~/Home/Style.css"));

          }
     }
}