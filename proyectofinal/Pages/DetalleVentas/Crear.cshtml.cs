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

namespace proyectofinal.Pages.DetalleVentas
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private int ventaId;

        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrearDetalleVentaVM DetalleVentaVM { get; set; }

        [BindProperty]
        public IEnumerable<Models.Producto> Productos { get; set; }

        public IEnumerable<Models.Venta> Ventas { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            ventaId = id;
            DetalleVentaVM = new CrearDetalleVentaVM()
            {
                ListaProductos = await _context.Producto.ToListAsync(),
                ListaVentas = await _context.Venta.ToListAsync(),
                DetalleVenta = new DetalleVenta()
            };

            DetalleVentaVM.DetalleVenta.VentaId = ventaId;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                DetalleVentaVM.DetalleVenta.EstadoProductoVenta = "Vendido";
                await _context.DetalleVenta.AddAsync(DetalleVentaVM.DetalleVenta);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Ventas/Detalle", new { id = DetalleVentaVM.DetalleVenta.VentaId });
            }
            else
            {
                return Page();
            }
        }
    }
}
