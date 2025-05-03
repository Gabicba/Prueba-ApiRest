namespace ApiEncode2.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string CategoriaNombre { get; set; }

    }
}
