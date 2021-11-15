using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectofinal.Models
{
    public class Proveedor
    {
        [Key]
        public int CodigoProveedor { get; set; }
        [Display(Name = "Nombre del Proveedor")]
        public string NombreProveedor { get; set; }
    }
}
