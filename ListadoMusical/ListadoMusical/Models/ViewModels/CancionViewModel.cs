using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ListadoMusical.Models.ViewModels
{
    public class CancionViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Título de la canción")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre del artista")]
        public string Artista { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Año")]
        public string Año { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Género")]
        public string Genero { get; set; }

       

    }

    public class EditarCancionViewModel
    {
        public int Id { get; set; }


        [Required]
        [StringLength(200, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Título de la canción")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre del artista")]
        public string Artista { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Año")]
        public string Año { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Género")]
        public string Genero { get; set; }
    }

    public class EliminarCancionViewModel
    {
        public int Id { get; set; }

        
     
    }
}