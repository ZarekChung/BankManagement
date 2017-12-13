using System.Web;
using System.Web.Optimization;

namespace BankManagement
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/lib").Include(
						"~/Scripts/jquery-{version}.js",
						"~/Scripts/bootstrap.js",
						"~/Scripts/respond.js",
				"~/Scripts/DataTables/jquery.dataTables.js",
				"~/Scripts/DataTables/dataTables.bootstrap.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// 使用開發版本的 Modernizr 進行開發並學習。然後，當您
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));


			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/DataTables/css/dataTables.bootstrap.css",
					  "~/Content/site.css"));
		}
	}
}
