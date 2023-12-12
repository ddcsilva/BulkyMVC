using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data;

/// <summary>
/// Classe que representa o contexto do banco de dados
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Representam as tabelas do banco de dados
    public DbSet<Categoria> Categorias { get; set; }

    /// <summary>
    /// Método que é executado quando o modelo é criado
    /// </summary>
    /// <param name="modelBuilder"> Construtor do modelo </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações da tabela Categoria
        // HasData: Insere dados na tabela
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nome = "Ação", OrdemExibicao = 1 },
            new Categoria { Id = 2, Nome = "Ficção Científica", OrdemExibicao = 2 },
            new Categoria { Id = 3, Nome = "História", OrdemExibicao = 3 }
        );
    }
}
