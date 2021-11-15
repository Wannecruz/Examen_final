using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectofinal.Models
{
    public class Cliente
    {
        [Key]
        public int CodigoCliente { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Nombres")]
        public string NombresCliente { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Apellidos")]
        public string ApellidosCliente { get; set; }
        [Display(Name = "NIT")]
        public string NITCliente { get; set; }
        [Display(Name = "Dirección")]
        public string DireccionCliente { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Categoría")]
        public string CategoriaCliente { get; set; }
        [Display(Name = "Estado")]
        public string EstadoCliente { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de creacción")]
        public DateTime? FechaCreacion { get; set; }

    }
}
