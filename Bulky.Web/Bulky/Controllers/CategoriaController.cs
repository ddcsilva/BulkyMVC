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
    }
}
