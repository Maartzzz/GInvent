using Microsoft.EntityFrameworkCore;

namespace GInvent.Models
{
    public class GInventDbContext : DbContext {
        public GInventDbContext(DbContextOptions<GInventDbContext> options) : base(options){
        }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
    }
}
