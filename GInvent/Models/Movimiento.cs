using System.ComponentModel.DataAnnotations;

namespace GInvent.Models
{
    public class Movimiento
    {
        [Key]
        public int idMovimiento { get; set; }

        public DateTime? fechaMovimiento { get; set; }
        public int? cantidadMovimiento { get; set; }
        public string? tipoMovimiento { get; set; }
        public Producto? Producto { get; set; }
    }
}
