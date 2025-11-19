using System.ComponentModel.DataAnnotations;
namespace GInvent.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }

        public string? nombreProducto { get; set; }
        public double? precioProducto { get; set; }
        public int? stockProducto { get; set; }
        public Proveedor? Proveedor { get; set; }
    }
}
