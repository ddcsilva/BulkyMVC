using Microsoft.AspNetCore.Mvc;

namespace Bulky.Web.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}