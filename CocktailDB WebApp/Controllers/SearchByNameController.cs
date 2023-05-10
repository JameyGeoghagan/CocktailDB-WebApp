
using CocktailDB_WebApp.Models;
using CocktailDB_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace CocktailDB_WebApp.Controllers
{
    public class SearchByNameController : Controller
    {
        public async Task<IActionResult> Index(string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                ViewBag.results = searchText;
                SearchByNameModel.Root drinksByName = new SearchByNameModel.Root();

                drinksByName = await ApiService.SearchByName(searchText);
                if (drinksByName.drinks != null)
                {
                    return View(drinksByName);
                }
                else
                {
                    return RedirectToAction("Index", "Error");
                }

            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

        }

        public async Task<IActionResult> DrinkByID(int id)
        {
            DrinkModel.Drink theDrink = new DrinkModel.Drink();
            DrinkModel.Root drinks = new DrinkModel.Root();
            drinks = await ApiService.GetDrinkByID(id);
            foreach (var drink in drinks.drinks)
            {

                theDrink = drink;
            }

            return View(theDrink);
        }
    }
}
