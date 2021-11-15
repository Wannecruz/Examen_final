using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectofinal.Models.ViewModels
{
    public class CrearProductoVM
    {
        public List<Proveedor> ListaProveedores { get; set; }
        public Producto Producto { get; set; }
    }
}
