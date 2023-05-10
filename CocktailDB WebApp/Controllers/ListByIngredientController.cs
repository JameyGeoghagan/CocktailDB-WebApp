using CocktailDB_WebApp.Models;
using CocktailDB_WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CocktailDB_WebApp.Controllers
{
    public class ListByIngredientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                ViewBag.results = searchText;
                ListByIngredientModel.Root drinks = new ListByIngredientModel.Root();
                drinks = await ApiService.GetListByIngredient(searchText);
                if (drinks.drinks != null)
                {
                    return View(drinks);
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
    }
}
