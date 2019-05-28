using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Mvc;

namespace IS3.Sample.WebUser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [ResourceAuthorize(action: "About", resources: "Home")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [ResourceAuthorize(action: "Contact", resources: "Home")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
        public ActionResult UserInfo()
        {
            var userInfo = this.User as ClaimsPrincipal;
            return View((User as ClaimsPrincipal).Claims);
        }
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("/");
        }
    }
}