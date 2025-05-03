using ApiEncode2.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEncode2.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected AppDbContext()
        {
        }
    }
}
