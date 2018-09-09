using System.Web;
using System.Web.Optimization;
using System.Web.Optimization.React; //Add this namespace  
namespace ReactFirst
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new BabelBundle("~/bundles/main").Include("~/Scripts/react/ReactFirst.jsx"));
        }
    }
}