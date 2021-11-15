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
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext __context;

        public EditarModel(ApplicationDbContext context)
        {
            __context = context;
        }

        [BindProperty]
        public Cliente Clientee { get; set; }
        public async void OnGet(int id)
        {
            Clientee = await __context.Cliente.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ClienteDesdeDb = await __context.Cliente.FindAsync(Clientee.CodigoCliente);
                ClienteDesdeDb.NombresCliente = Clientee.NombresCliente;
                ClienteDesdeDb.ApellidosCliente = Clientee.ApellidosCliente;
                ClienteDesdeDb.DireccionCliente = Clientee.DireccionCliente;
                ClienteDesdeDb.NITCliente = Clientee.NITCliente;
                ClienteDesdeDb.CategoriaCliente = Clientee.CategoriaCliente;
                await __context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
