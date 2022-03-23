using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // necesario para definir las Anotaciones, características de cada campo de la tabla

namespace EjemploMVC.Models
{
    public class Libro
    {
        // PROPIEDADES: 
        [Key]
        public int Id { get; set;  }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(50, ErrorMessage ="El título debe tener como máximo 50 caracteres")]
        [Display(Name ="Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(60, ErrorMessage = "La descripción debe tener como máximo 60 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Publicación")]
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        [StringLength(40, ErrorMessage = "El autor debe tener como máximo 40 caracteres")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El Precio es obligatorio")]
        public int Precio { get; set; }

    }
}
