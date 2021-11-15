using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectofinal.Models.ViewModels
{
    public class CrearVentaVM
    {
        public List<Cliente> ListaClientes { get; set; }
        public Venta Venta { get; set; }
    }
}
