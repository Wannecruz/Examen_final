using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proyectofinal.Data;
using proyectofinal.Models;

namespace proyectofinal.Pages.Clientes
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Cliente.EstadoCliente = "Activo";
                Cliente.FechaCreacion = new DateTime().ToLocalTime();
                await _context.Cliente.AddAsync(Cliente);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            } else
            {
                return Page();
            }
        }
    }
}
