using Microsoft.EntityFrameworkCore;

namespace Bulky.Data;

/// <summary>
/// Classe que representa o contexto do banco de dados
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
}
