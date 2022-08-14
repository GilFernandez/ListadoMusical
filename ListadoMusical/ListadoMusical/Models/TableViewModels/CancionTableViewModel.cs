using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListadoMusical.Models.TableViewModels
{
    public class CancionTableViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Artista { get; set; }

        public string Año { get; set; }

        public string Genero { get; set; }

        public string UsuarioAgregado { get; set; }

        public string FechaAgregdo { get; set; }
        public string UsuarioEditado { get; set; }

        public string FechaEditado { get; set; }

    }
}