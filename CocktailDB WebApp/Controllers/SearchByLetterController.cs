
using CocktailDB_WebApp.Models;
using CocktailDB_WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CocktailDB_WebApp.Controllers
{
    public class SearchByLetterController : Controller
    {
        public async Task<IActionResult> Index(string letter)
        {
            SearchByLetterModel.Root drinks = new SearchByLetterModel.Root();
            drinks = await ApiService.GetDrinksByLetter(letter);

            return View(drinks);
        }
    }
}
