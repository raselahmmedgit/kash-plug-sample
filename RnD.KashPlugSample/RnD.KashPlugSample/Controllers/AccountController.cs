using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.KashPlugSample.Helpers;
using RnD.KashPlugSample.Models;
using System.Data;
using RnD.KashPlugSample.ViewModels;

namespace RnD.KashPlugSample.Controllers
{
    public class AccountController : Controller
    {
        #region Action

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

        #endregion

        #region Methods

        #endregion
    }
}
