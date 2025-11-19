using GInvent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GInvent.Controllers
{
    public class ProveedorController : Controller
    {
        public readonly GInventDbContext _contexto;

        public ProveedorController(GInventDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var proveedor = await _contexto.Proveedor.ToListAsync();

            return View(proveedor);
        }

        [HttpPost]
        public IActionResult IngresarProv(Proveedor proveedor)
        {
            _contexto.Proveedor.Add(proveedor);
            _contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarProv(int id)
        {
            var proveedor = await _contexto.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            _contexto.Proveedor.Remove(proveedor);
            await _contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
