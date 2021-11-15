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
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext __context;

        public BorrarModel(ApplicationDbContext context)
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
            var ClienteDesdeDb = await __context.Cliente.FindAsync(Clientee.CodigoCliente);
            if(ClienteDesdeDb == null)
            {
                return NotFound();
            }
            __context.Cliente.Remove(ClienteDesdeDb);
            await __context.SaveChangesAsync();
            return RedirectToPage("Index");
           
        }

    }
}
