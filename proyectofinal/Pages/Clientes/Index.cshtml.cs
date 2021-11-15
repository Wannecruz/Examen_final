using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proyectofinal.Data;
using proyectofinal.Models;

namespace proyectofinal.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> Clientes { get; set; }
        public async Task OnGet()
        {
            Clientes = await _context.Cliente.ToListAsync();
        }

        /*public async Task buscarCliente(string search)
        {
            Clientes = await _context.Cliente.(search);
        }*/

    }
}
