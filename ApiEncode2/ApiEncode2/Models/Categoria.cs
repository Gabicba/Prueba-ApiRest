using System.ComponentModel.DataAnnotations;

namespace ApiEncode2.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Nombre { get; set; }

        public List<Producto> Productos { get; set; }

    }
}
