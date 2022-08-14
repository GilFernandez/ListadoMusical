using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListadoMusical.Controllers
{
    public class CerrarSesionController : Controller
    {
        public ActionResult LogOut()
        {
            Session["User"] = null;

            return RedirectToAction("Index", "Login");

        }
    }
}