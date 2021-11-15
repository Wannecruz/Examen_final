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
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BorrarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]

        public CrearVentaVM VentaVm { get; set; }

        public Venta Venta { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Venta = await _context.Venta
                .Where(c => c.CodigoVenta == id)
                .Include(c => c.CodigoCliente)
                .FirstOrDefaultAsync();

            VentaVm = new CrearVentaVM()
            {
                Venta = await _context.Venta.FindAsync(id)
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var venta = await _context.Venta.FindAsync(VentaVm.Venta.CodigoVenta);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Venta.Remove(venta);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}
