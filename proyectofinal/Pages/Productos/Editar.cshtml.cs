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

namespace proyectofinal.Pages.Productos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrearProductoVM ProductoVm { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            ProductoVm = new CrearProductoVM()
            {
                ListaProveedores = await _context.Proveedor.ToListAsync(),
                Producto = await _context.Producto.FindAsync(id)
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ProductoDesdeDb = await _context.Producto.FindAsync(ProductoVm.Producto.CodigoProducto);
                ProductoDesdeDb.NombreProducto = ProductoVm.Producto.NombreProducto;
                ProductoDesdeDb.Descripcion = ProductoVm.Producto.Descripcion;
                ProductoDesdeDb.Ubicacion = ProductoVm.Producto.Ubicacion;
                ProductoDesdeDb.ExistenciaMinima = ProductoVm.Producto.ExistenciaMinima;
                ProductoDesdeDb.FechaVencimiento = ProductoVm.Producto.FechaVencimiento;
                ProductoDesdeDb.ProveedorId = ProductoVm.Producto.ProveedorId;
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
