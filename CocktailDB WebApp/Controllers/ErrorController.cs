using Microsoft.AspNetCore.Mvc;

namespace CocktailDB_WebApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
