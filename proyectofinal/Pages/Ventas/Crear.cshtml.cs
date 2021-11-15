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
    public class CrearModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public CrearVentaVM VentaVM { get; set; }

        [BindProperty]
        public IEnumerable<Models.Cliente> Clientes { get; set; }
        public async Task<IActionResult> OnGet()
        {
            VentaVM = new CrearVentaVM()
            {
                ListaClientes = await _context.Cliente.ToListAsync(),
                Venta = new Venta()
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                VentaVM.Venta.EstadoVenta = "Realizada";
                await _context.Venta.AddAsync(VentaVM.Venta);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
