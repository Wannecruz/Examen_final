using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectofinal.Models.ViewModels
{
    public class CrearDetalleVentaVM
    {
        public List<Venta> ListaVentas { get; set; }
        public List<Producto> ListaProductos { get; set; }
        public DetalleVenta DetalleVenta { get; set; }
    }
}
