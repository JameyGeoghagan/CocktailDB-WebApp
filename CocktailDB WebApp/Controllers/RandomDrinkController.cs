using CocktailDB_WebApp.Models;
using CocktailDB_WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CocktailDB_WebApp.Controllers
{
    public class RandomDrinkController : Controller
    {
        public async Task<IActionResult> Index()
        {
            DrinkModel.Drink drink = new DrinkModel.Drink();
            DrinkModel.Root drinks = new DrinkModel.Root();
            drinks = await ApiService.GetARandomDrink();

            foreach (var drinkToUse in drinks.drinks)
            {
                drink = drinkToUse;
            }

            return View(drink);
        }
    }
}
