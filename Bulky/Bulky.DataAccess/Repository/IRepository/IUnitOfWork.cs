namespace Bulky.DataAccess.Repository.IRepository;

/// <summary>
/// Interface responsável por definir os métodos do UnitOfWork.
/// </summary>
public interface IUnitOfWork
{
    ICategoriaRepository Categoria { get; }

    void Salvar();
}
