using System.ComponentModel.DataAnnotations;

namespace ApiEncode2.DTOs
{
    public class ProductoCreateDTO
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }


        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public int CategoriaId { get; set; }
    }
}
