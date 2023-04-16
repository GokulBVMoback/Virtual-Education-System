using System.Web;
using System.Web.Optimization;

namespace MVC5FullCalandarPlugin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {         

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-1.*"));

           
        }
    }
}
