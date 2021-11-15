using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proyectofinal.Data;
using proyectofinal.Models;

namespace proyectofinal.Pages.Productos
{
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetalleModel(ApplicationDbContext context) => _context = context;

        public Producto Producto { get; set; }
        public async void OnGet(int id)
        {
            Producto = await _context.Producto
                .Where(c => c.CodigoProducto == id)
                .Include(c => c.CodigoProveedor)
                .FirstOrDefaultAsync();
        }
    }
}
