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
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext __context;

        public BorrarModel(ApplicationDbContext context)
        {
            __context = context;
        }

        [BindProperty]
        public Proveedor Proveedor { get; set; }
        public async void OnGet(int id)
        {
            Proveedor = await __context.Proveedor.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var ProveedorDesdeDb = await __context.Proveedor.FindAsync(Proveedor.CodigoProveedor);
            if(ProveedorDesdeDb == null)
            {
                return NotFound();
            }
            __context.Proveedor.Remove(ProveedorDesdeDb);
            await __context.SaveChangesAsync();
            return RedirectToPage("Index");
           
        }

    }
}
