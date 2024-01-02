using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Web.Areas.Admin.Controllers;

/// <summary>
/// Controller responsável por gerenciar os produtos.
/// </summary>
[Area("Admin")]
public class ProdutoController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProdutoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Action responsável por listar os produtos.
    /// </summary>
    /// <returns> View com a lista de produtos. </returns>
    [HttpGet]
    public IActionResult Index()
    {
        // Busca todos os produtos do banco de dados.
        var produtos = _unitOfWork.Produto.ObterTodos().ToList();

        // Retorna a view com a lista de produtos.
        return View(produtos);
    }

    /// <summary>
    /// Action responsável por exibir o formulário de adição de produto.
    /// </summary>
    /// <returns> View com o formulário de adição de produto. </returns>
    [HttpGet]
    public IActionResult Adicionar()
    {
        return View();
    }

    /// <summary>
    /// Action responsável por adicionar um produto.
    /// </summary>
    /// <param name="produto"> Objeto produto preenchido com os dados do formulário. </param>
    /// <returns> Redireciona para a action Index ou retorna a view com o formulário preenchido. </returns>
    [HttpPost]
    public IActionResult Adicionar(Produto produto)
    {
        // Verifica se o modelo é válido
        if (ModelState.IsValid)
        {
            // Adiciona o objeto produto ao contexto do banco de dados
            _unitOfWork.Produto.Adicionar(produto);
            // Salva as alterações no banco de dados
            _unitOfWork.Salvar();
            // Adiciona uma mensagem de sucesso na sessão
            TempData["MensagemSucesso"] = "Produto adicionado com sucesso.";

            // Redireciona para a action Index
            return RedirectToAction(nameof(Index));
        }

        // Se o modelo não for válido, retorna a view com o formulário preenchido
        return View(produto);
    }

    /// <summary>
    /// Action responsável por exibir o formulário de alteração de produto.
    /// </summary>
    /// <param name="id"> Id do produto a ser alterado. </param>
    /// <returns> View com o formulário de alteração de produto. </returns>
    [HttpGet]
    public IActionResult Alterar(int? id)
    {
        // Verifica se o id é nulo ou menor ou igual a zero
        if (id == null || id <= 0)
        {
            // Retorna um erro HTTP 404
            return NotFound();
        }

        // Busca o produto no banco de dados
        var produtoParaAlterar = _unitOfWork.Produto.Obter(p => p.Id == id);

        // Verifica se o produto foi encontrado
        if (produtoParaAlterar == null)
        {
            // Retorna um erro HTTP 404
            return NotFound();
        }

        // Retorna a view com o produto a ser alterado
        return View(produtoParaAlterar);
    }

    /// <summary>
    /// Action responsável por alterar um produto.
    /// </summary>
    /// <param name="produto"> Objeto produto preenchido com os dados do formulário. </param>
    /// <returns> Redireciona para a action Index ou retorna a view com o formulário preenchido. </returns>
    [HttpPost]
    public IActionResult Alterar(Produto produto)
    {
        // Verifica se o modelo é válido
        if (ModelState.IsValid)
        {
            // Atualiza o produto no contexto do banco de dados
            _unitOfWork.Produto.Atualizar(produto);
            // Salva as alterações no banco de dados
            _unitOfWork.Salvar();
            // Adiciona uma mensagem de sucesso na sessão
            TempData["MensagemSucesso"] = "Produto alterado com sucesso.";

            // Redireciona para a action Index
            return RedirectToAction(nameof(Index));
        }

        // Se o modelo não for válido, retorna a view com o formulário preenchido
        return View();
    }

    [HttpGet]
    public IActionResult Excluir(int? id)
    {
        // Verifica se o id é nulo ou menor ou igual a zero
        if (id == null || id <= 0)
        {
            // Retorna um erro HTTP 404
            return NotFound();
        }

        // Busca o produto no banco de dados
        var produtoParaExcluir = _unitOfWork.Produto.Obter(p => p.Id == id);

        // Verifica se o produto foi encontrado
        if (produtoParaExcluir == null)
        {
            // Retorna um erro HTTP 404
            return NotFound();
        }

        // Retorna a view com o produto a ser excluído
        return View(produtoParaExcluir);
    }

    /// <summary>
    /// Action responsável por excluir um produto.
    /// </summary>
    /// <param name="id"> Id do produto a ser excluído. </param>
    /// <returns> Redireciona para a action Index ou retorna a view com o formulário preenchido. </returns>
    [HttpPost, ActionName("Excluir")]
    public IActionResult ConfirmarExclusao(int? id)
    {
        // Busca o produto no banco de dados
        var produtoParaExcluir = _unitOfWork.Produto.Obter(p => p.Id == id);

        // Verifica se o produto foi encontrado
        if (produtoParaExcluir == null)
        {
            // Retorna um erro HTTP 404
            return NotFound();
        }

        // Remove o produto do contexto do banco de dados
        _unitOfWork.Produto.Remover(produtoParaExcluir);
        // Salva as alterações no banco de dados
        _unitOfWork.Salvar();
        // Adiciona uma mensagem de sucesso na sessão
        TempData["MensagemSucesso"] = "Produto excluído com sucesso.";

        // Redireciona para a action Index
        return RedirectToAction(nameof(Index));
    }
}
