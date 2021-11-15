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
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrearProductoVM ProductoVm { get; set; }

        [BindProperty]
        public IEnumerable<Models.Proveedor> Proveedores { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ProductoVm = new CrearProductoVM()
            {
                ListaProveedores = await _context.Proveedor.ToListAsync(),
                Producto = new Producto()
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _context.Producto.AddAsync(ProductoVm.Producto);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            } else
            {
                return Page();
            }
        }
    }
}
