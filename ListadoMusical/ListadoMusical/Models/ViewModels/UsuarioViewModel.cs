using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ListadoMusical.Models.ViewModels
{
    public class UsuarioViewModel
    {

      

        [Required]
        [StringLength (200, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display (Name = "Nombre de usuario")]
        public string nombreUsuario { get; set; }

    }
}