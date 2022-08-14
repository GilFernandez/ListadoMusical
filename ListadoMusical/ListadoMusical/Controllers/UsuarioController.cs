using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListadoMusical.Models;
using ListadoMusical.Models.TableViewModels;
using ListadoMusical.Models.ViewModels;

namespace ListadoMusical.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<UsuarioTableViewModel> lista = null;
            using (ListadoMusicaEntities db = new ListadoMusicaEntities())
            {
                lista = (from d in db.Usuario
                        where d.estatus == 1
                        orderby d.nombreUsuario
                        select new UsuarioTableViewModel
                        {
                            Id = d.idUsuario,
                            NombreUsuario = d.nombreUsuario
                        }).ToList();
            }

            return View(lista);
        }

        [HttpGet]
        public ActionResult Agregar()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Agregar(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ListadoMusicaEntities())
            {
                Usuario oUsuario = new Usuario();
                oUsuario.estatus = 1;
                oUsuario.nombreUsuario = model.nombreUsuario;

                db.Usuario.Add(oUsuario);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Usuario/"));
        }
    }
}