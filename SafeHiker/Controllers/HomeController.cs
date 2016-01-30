using System.Web.Mvc;

namespace SafeHiker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //            if (String.IsNullOrEmpty(User.Identity.Name))
            //            {
            //                return View("Login");
            //            }
            return View("Index");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}