using System.ComponentModel.DataAnnotations;

namespace GInvent.Models
{
    public class Proveedor
    {
        [Key]
        public int idProveedor { get; set; }

        public string? nombreProveedor { get; set; }
        public int? contactoProveedor { get; set; }
    }
}
