using Bulky.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("Categoria");

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Ação", OrdemExibicao = 1 },
                new Categoria { Id = 2, Nome = "Ficção Científica", OrdemExibicao = 2 },
                new Categoria { Id = 3, Nome = "História", OrdemExibicao = 3 }
            );
        }
    }
}
