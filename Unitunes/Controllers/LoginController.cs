using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Unitunes.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        public ActionResult Login()
        {

            return View();
        }

        // POST: VerifyLogin
        [HttpPost]
        public ActionResult VerifyLogin()
        {
            ViewBag.login = Request["login"];
            ViewBag.password = Request["password"];
            return View();
        }

        
    }
}