using System.Web.Mvc;

namespace StronglyTypedMvcClientSideUrls.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewData["Message"] = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public string DoSomethingComplex(int id, string accountNumber, int amount)
		{
			return string.Format("id = {0}, accountNumber = {1}, amount = {2}", id, accountNumber, amount);
		}
	}
}
