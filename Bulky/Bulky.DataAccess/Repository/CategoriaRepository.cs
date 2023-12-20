using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    // Representa o contexto do banco de dados
    private readonly BulkyContext _context;

    public CategoriaRepository(BulkyContext context) : base(context)
    {
        _context = context;
    }

    public void Salvar()
    {
        // Salva as alterações no banco de dados
        _context.SaveChanges();
    }

    public void Atualizar(Categoria entidade)
    {
        // Atualiza a entidade de Categoria no DbSet
        _context.Update(entidade);
    }
}
