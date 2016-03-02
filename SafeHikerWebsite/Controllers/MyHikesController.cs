using System.Web.Mvc;

namespace SafeHikerWebsite.Controllers
{
    public class MyHikesController : Controller
    {
        [AllowAnonymous]
        public ActionResult MyHikes(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}