using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
