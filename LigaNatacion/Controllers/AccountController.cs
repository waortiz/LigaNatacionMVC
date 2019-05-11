using LigaNatacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LigaNatacion.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if(login.UserName.ToLower() == "wortiz" && login.Password == "123")
            {
                FormsAuthentication.SetAuthCookie(login.UserName, false);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Mensaje = "Usuario o contraseña no válidos";

            return View("Login");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return View("Login");
        }
    }
}
