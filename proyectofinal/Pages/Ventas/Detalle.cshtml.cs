using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proyectofinal.Data;
using proyectofinal.Models;
using proyectofinal.Models.ViewModels;

namespace proyectofinal.Pages.Ventas
{
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public int ventaId { get; set; }

        public DetalleModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Venta Venta { get; set; }

        public IEnumerable<Models.DetalleVenta> DetallesVenta { get; set; }

        public async Task OnGet(int id)
        {
            ventaId = id;
            ventaId = id;
            Venta = await _context.Venta
                .Where(c => c.CodigoVenta == id)
                .Include(c => c.CodigoCliente)
                .FirstOrDefaultAsync();

            DetallesVenta = await _context.DetalleVenta
                .Where(c => c.CodigoVenta.CodigoVenta == id)
                .Include(c => c.CodigoProducto)
                .Include(c => c.CodigoVenta)
                .Include(c => c.CodigoProducto.CodigoProveedor)
                .ToArrayAsync();
        }


    }
}
