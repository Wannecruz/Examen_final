using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proyectofinal.Data;

namespace proyectofinal.Pages.Proveedores
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.Proveedor> Proveedores { get; set; }

        public async Task OnGet()
        {
            Proveedores = await _context.Proveedor.ToListAsync();
        }
    }
}
