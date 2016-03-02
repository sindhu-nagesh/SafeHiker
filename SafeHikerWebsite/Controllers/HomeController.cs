using SafeHikerWebsite.Models;
using System;
using System.Web.Mvc;

namespace SafeHikerWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(User.Identity.Name))
            {
                return View("Login");
            }

            //if no details in table,
            // return View("EnterUserDetails");
            return View("Index", new User { Name = User.Identity.Name });
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