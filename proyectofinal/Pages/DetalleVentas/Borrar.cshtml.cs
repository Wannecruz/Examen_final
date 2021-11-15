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
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public int ventaId;

        public BorrarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]

        public CrearDetalleVentaVM DetalleVentaVM { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            
            DetalleVentaVM = new CrearDetalleVentaVM()
            {
                DetalleVenta = await _context.DetalleVenta.FindAsync(id)
            };

            System.Diagnostics.Debug.WriteLine("producto encontrado: ", id);
            //System.Diagnostics.Debug.WriteLine("producto encontrado: ", DetalleVentaVM.DetalleVenta.CodigoDetalle);
            //ventaId = DetalleVentaVM.DetalleVenta.CodigoVenta.CodigoVenta;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var producto = await _context.DetalleVenta.FindAsync(DetalleVentaVM.DetalleVenta.CodigoDetalle);
            System.Diagnostics.Debug.WriteLine("produto a borrar: ", producto);
            if (producto == null)
            {
                System.Diagnostics.Debug.WriteLine("entro al if null: ", producto);
                return NotFound();
            }

            _context.DetalleVenta.Remove(producto);
            await _context.SaveChangesAsync();
           // return RedirectToPage("Index");
            return RedirectToPage("../Ventas/Index");

        }
    }
}
