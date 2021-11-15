using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proyectofinal.Data;
using proyectofinal.Models;

namespace proyectofinal.Pages.Proveedores
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proveedor Proveedor { get; set; }
        public async void OnGet(int id)
        {
            Proveedor = await _context.Proveedor.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ProveedorDesdeDb = await _context.Proveedor.FindAsync(Proveedor.CodigoProveedor);
                ProveedorDesdeDb.NombreProveedor = Proveedor.NombreProveedor;
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
