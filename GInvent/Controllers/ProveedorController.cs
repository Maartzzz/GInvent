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

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> BuscarProv(int id)
        {
            var proveedor = await _contexto.Proveedor.FindAsync(id);
            if (proveedor == null)
                return NotFound();

            return Json(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> EditarProv(Proveedor nuevoprov)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try{ 
                _contexto.Proveedor.Update(nuevoprov);
                await _contexto.SaveChangesAsync();
                return Ok(new { success = true, message = "Proveedor actualizado con éxito." });
            }
            catch (DbUpdateConcurrencyException){
                if (await _contexto.Proveedor.FindAsync(nuevoprov) == null)
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}
