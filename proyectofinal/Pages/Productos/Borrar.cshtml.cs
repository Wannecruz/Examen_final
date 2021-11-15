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

namespace proyectofinal.Pages.Productos
{
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BorrarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrearProductoVM ProductoVm { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            ProductoVm = new CrearProductoVM()
            {
                ListaProveedores = await _context.Proveedor.ToListAsync(),
                Producto = await _context.Producto.FindAsync(id)
            };

            System.Diagnostics.Debug.WriteLine("producto encontrado: ", id);
            System.Diagnostics.Debug.WriteLine("producto encontrado: ", ProductoVm.Producto.CodigoProducto);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var producto = await _context.Producto.FindAsync(ProductoVm.Producto.CodigoProducto);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");

        }

    }
}
