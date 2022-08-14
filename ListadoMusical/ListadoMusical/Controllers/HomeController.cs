using ListadoMusical.Models.TableViewModels;
using ListadoMusical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListadoMusical.Models;
using ListadoMusical.Models.TableViewModels;
using ListadoMusical.Models.ViewModels;
using System.Collections;


namespace ListadoMusical.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<CancionTableViewModel> lista = null;
            using (ListadoMusicaEntities db = new ListadoMusicaEntities())
            {
                lista = (from d in db.vwCancionesFavoritas
                         orderby d.Titulo_de_canción
                         select new CancionTableViewModel
                         {
                             Id = d.C_,
                             Titulo = d.Titulo_de_canción,
                             Artista = d.Artista,
                             Año = d.Año,
                             Genero = d.Género,
                             UsuarioAgregado = d.Agregada_por_,
                             FechaAgregdo = d.Agregada_en_.ToString()

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
        public ActionResult Agregar(CancionViewModel model)
        {
           
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new ListadoMusicaEntities())
            {
                
                Cancion oCancion = new Cancion();
                oCancion.estatus = 1;
                oCancion.titulo = model.Titulo;
                oCancion.artista = model.Artista;
                oCancion.año = model.Año;
                oCancion.genero = model.Genero;
                oCancion.idUsuarioAgrega = Convert.ToInt32(Session["idUser"].ToString());
                oCancion.fechaAgrega = DateTime.Now;

                db.Cancion.Add(oCancion);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Home/"));
        }


        public ActionResult Editar (int Id)
        {
            EditarCancionViewModel model = new EditarCancionViewModel();


            using (var db = new ListadoMusicaEntities())
            {
                var oCancion = db.Cancion.Find(Id);
                model.Id = oCancion.idCancion;
                model.Titulo = oCancion.titulo;
                model.Artista = oCancion.artista;
                model.Año = oCancion.año;
                model.Genero = oCancion.genero;
               
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar (EditarCancionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ListadoMusicaEntities())
            {
                var oCancion = db.Cancion.Find(model.Id);
                oCancion.titulo = model.Titulo;
                oCancion.artista = model.Artista;
                oCancion.año = model.Año;
                oCancion.genero = model.Genero;


                db.Entry(oCancion).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            };

            return Redirect(Url.Content("~/Home/"));
        }

       
        public ActionResult Eliminar(int  Id)
        {

            using (var db = new ListadoMusicaEntities())
            {
                var oCancion = db.Cancion.Find(Id);
                oCancion.estatus = 0; //No se elimina de la base de datos, solo se pasa a inactivo


                db.Entry(oCancion).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            };

            return Redirect(Url.Content("~/Home/"));
        }
    }
}