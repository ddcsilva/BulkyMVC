﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Web.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as categorias.
    /// </summary>
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        /// <summary>
        /// Action responsável por listar as categorias.
        /// </summary>
        /// <returns> View com a lista de categorias. </returns>
        [HttpGet]
        public IActionResult Index()
        {
            // Busca todas as categorias do banco de dados.
            var categorias = _categoriaRepository.ObterTodos().ToList();

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
                _categoriaRepository.Adicionar(categoria);
                // Salva as alterações no banco de dados
                _categoriaRepository.Salvar();
                // Adiciona uma mensagem de sucesso na sessão
                TempData["MensagemSucesso"] = "Categoria adicionada com sucesso.";

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
            Categoria categoriaParaAlterar = _categoriaRepository.Obter(c => c.Id == id);

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
                _categoriaRepository.Atualizar(categoria);
                // Salva as alterações no banco de dados
                _categoriaRepository.Salvar();
                // Adiciona uma mensagem de sucesso na sessão
                TempData["MensagemSucesso"] = "Categoria alterada com sucesso.";

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
            Categoria categoriaParaExcluir = _categoriaRepository.Obter(c => c.Id == id);

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
            Categoria? categoriaParaExcluir = _categoriaRepository.Obter(c => c.Id == id);

            // Verifica se a categoria foi encontrada
            if (categoriaParaExcluir == null)
            {
                // Retorna o erro 404
                return NotFound();
            }

            // Remove a categoria do banco de dados
            _categoriaRepository.Remover(categoriaParaExcluir);
            // Salva as alterações no banco de dados
            _categoriaRepository.Salvar();
            // Adiciona uma mensagem de sucesso na sessão
            TempData["MensagemSucesso"] = "Categoria excluída com sucesso.";

            // Redireciona para a action Index
            return RedirectToAction(nameof(Index));
        }
    }
}
