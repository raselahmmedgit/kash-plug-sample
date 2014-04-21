using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RnD.KashPlugSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //LogIn
        public ActionResult LogIn()
        {
            return View();
        }

        //Register
        public ActionResult Register()
        {
            return View();
        }

        //ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}
