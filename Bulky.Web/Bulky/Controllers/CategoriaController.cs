using Bulky.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as categorias.
    /// </summary>
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoriaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Action responsável por listar as categorias.
        /// </summary>
        /// <returns> View com a lista de categorias. </returns>
        [HttpGet]
        public IActionResult Index()
        {
            // Busca todas as categorias do banco de dados.
            var categorias = context.Categorias.ToList();

            // Retorna a view com a lista de categorias.
            return View(categorias);
        }

        /// <summary>
        /// Action responsável por exibir o formulário de adição de categoria.
        /// </summary>
        /// <returns> View com o formulário de adição de categoria. </returns>
        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        /// <summary>
        /// Action responsável por adicionar uma categoria.
        /// </summary>
        /// <param name="categoria"> Objeto categoria preenchido com os dados do formulário. </param>
        /// <returns> Redireciona para a action Index ou retorna a view com o formulário preenchido. </returns>
        [HttpPost]
        public IActionResult Adicionar(Categoria categoria)
        {
            // Verifica se o modelo é válido
            if (ModelState.IsValid)
            {
                // Adiciona o objeto categoria ao contexto do banco de dados
                context.Add(categoria);
                // Salva as alterações no banco de dados
                context.SaveChanges();

                // Redireciona para a action Index
                return RedirectToAction(nameof(Index));
            }

            // Se o modelo não for válido, retorna a view com o formulário preenchido            
            return View();
        }

        /// <summary>
        /// Action responsável por exibir o formulário de alteração de categoria.
        /// </summary>
        /// <param name="id"> Id da categoria a ser alterada. </param>
        /// <returns> View com o formulário de alteração de categoria. </returns>
        [HttpGet]
        public IActionResult Alterar(int? id)
        {
            // Verifica se o id é nulo ou menor ou igual a zero
            if (id == null || id <= 0)
            {
                // Retorna o erro 404
                return NotFound();
            }

            // Busca a categoria no banco de dados
            Categoria categoriaParaAlterar = context.Categorias.Find(id);

            // Verifica se a categoria foi encontrada
            if (categoriaParaAlterar == null)
            {
                // Retorna o erro 404
                return NotFound();
            }

            // Retorna a view com a categoria a ser alterada
            return View(categoriaParaAlterar);
        }

        /// <summary>
        /// Action responsável por alterar uma categoria.
        /// </summary>
        /// <param name="categoria"> Objeto categoria preenchido com os dados do formulário. </param>
        /// <returns> Redireciona para a action Index ou retorna a view com o formulário preenchido. </returns>
        [HttpPost]
        public IActionResult Alterar(Categoria categoria)
        {
            // Verifica se o modelo é válido
            if (ModelState.IsValid)
            {
                // Atualiza o objeto categoria no contexto do banco de dados
                context.Update(categoria);
                // Salva as alterações no banco de dados
                context.SaveChanges();

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
                // Retorna o erro 404
                return NotFound();
            }

            // Busca a categoria no banco de dados
            Categoria categoriaParaExcluir = context.Categorias.Find(id);

            // Verifica se a categoria foi encontrada
            if (categoriaParaExcluir == null)
            {
                // Retorna o erro 404
                return NotFound();
            }

            // Retorna a view com a categoria a ser excluída
            return View(categoriaParaExcluir);
        }

        [HttpPost, ActionName("Excluir")]
        public IActionResult ExcluirRequest(int? id)
        {
            // Busca a categoria no banco de dados
            Categoria? categoriaParaExcluir = context.Categorias.Find(id);

            // Verifica se a categoria foi encontrada
            if (categoriaParaExcluir == null)
            {
                // Retorna o erro 404
                return NotFound();
            }

            // Remove a categoria do banco de dados
            context.Remove(categoriaParaExcluir);
            // Salva as alterações no banco de dados
            context.SaveChanges();

            // Redireciona para a action Index
            return RedirectToAction(nameof(Index));
        }
    }
}
