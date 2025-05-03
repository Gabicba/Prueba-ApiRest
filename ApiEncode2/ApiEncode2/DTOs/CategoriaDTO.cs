using System.ComponentModel.DataAnnotations;

namespace ApiEncode2.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;
       
    }
    
}
