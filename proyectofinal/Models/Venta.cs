using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectofinal.Models
{
    public class Venta
    {
        [Key]
        public int CodigoVenta { get; set; }

        [Display(Name = "Estado de la venta")]
        public string EstadoVenta { get; set; }

        [Display(Name = "Tipo de venta")]
        public string TipoVenta { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha venta")]
        public DateTime? FechaVenta { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente CodigoCliente { get; set; }
    }
}
