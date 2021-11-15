using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectofinal.Models
{
    public class Producto
    {
        [Key]
        public int CodigoProducto { get; set; }

        [Display(Name = "Nombre Producto")]
        public string NombreProducto { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Ubicación física")]
        public string Ubicacion { get; set; }

        [Display(Name = "Existencia Minima")]
        public double ExistenciaMinima { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha vencimiento")]
        public DateTime? FechaVencimiento { get; set; }

        [Required]
        public int ProveedorId {get; set;}

        public Proveedor CodigoProveedor { get; set; }
    }
}
