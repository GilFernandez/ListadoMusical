using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListadoMusical.Models;
using ListadoMusical.Models.TableViewModels;
using ListadoMusical.Models.ViewModels;

namespace ListadoMusical.Controllers
{
    public class LoginController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter (string user)
        {
            try
            {

                using (ListadoMusicaEntities db = new ListadoMusicaEntities())
                {
                    var lista = from d in db.Usuario
                                where d.nombreUsuario == user
                                select d;

                    var lista2 = from d in db.Usuario
                                where d.nombreUsuario == user
                                select d.idUsuario;
                    if (lista.Count() > 0)
                    {
                        Session["User"] = lista.First();
                        Session["idUser"] = lista2.First();
                        int a = Convert.ToInt32(Session["idUser"].ToString());
                        return Content("1");
                    }
                    else
                    {
                        return Content("El usuario no existe");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error " + ex.Message);
            }
        }

       

    }
}