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
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetalleModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proveedor Proveedor { get; set; }
        public async Task OnGet(int id)
        {
            Proveedor = await _context.Proveedor.FindAsync(id);
        }
    }
}
