using Bulky.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoriaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var categorias = context.Categorias.ToList();
            return View(categorias);
        }

        public IActionResult Adicionar()
        {
            return View();
        }
    }
}
