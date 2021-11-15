using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectofinal.Models
{
    public class DetalleVenta
    {
        [Key]
        public int CodigoDetalle { get; set; }

        [Display(Name = "Estado producto")]
        public string EstadoProductoVenta { get; set; }

        [Required]
        public int VentaId { get; set; }
        public Venta CodigoVenta { get; set; }

        [Required]
        public int ProductoId { get; set; }
        public Producto CodigoProducto { get; set; }
    }
}
