using CocktailDB_WebApp.Models;
using CocktailDB_WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CocktailDB_WebApp.Controllers
{
    public class NonAlcoholicDrinkController : Controller
    {
        public async Task<IActionResult> Index()
        {
            NonAlcoholicDrinkModel.Root drinks = new NonAlcoholicDrinkModel.Root();
            drinks = await ApiService.GetNonAlcoholicDrinks();

            return View(drinks);
        }
    }
}
