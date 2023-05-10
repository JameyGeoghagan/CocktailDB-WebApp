
using CocktailDB_WebApp.Models;
using Newtonsoft.Json;

namespace CocktailDB_WebApp.Services
{
    public class ApiService
    {
        //Lets set up the api call for the end point search by the cocktail name
        public static async Task<SearchByNameModel.Root> SearchByName(string name)
        {
            SearchByNameModel.Root myDeserializedClass = new SearchByNameModel.Root();
            HttpClient client = new HttpClient();
            var url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={name}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                myDeserializedClass = JsonConvert.DeserializeObject<SearchByNameModel.Root>(await response.Content.ReadAsStringAsync());
            }

            return myDeserializedClass;
        }

        // Setting up the api end point to get the drink by the drink id
        public static async Task<DrinkModel.Root> GetDrinkByID(int id)
        {
            HttpClient client = new HttpClient();
            DrinkModel.Root drink = new DrinkModel.Root();
            var url = $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                drink = JsonConvert.DeserializeObject<DrinkModel.Root>(await response.Content.ReadAsStringAsync());
            }
            return drink;
        }
        // setting up the random drink api call
        public static async Task<DrinkModel.Root> GetARandomDrink()
        {
            HttpClient client = new HttpClient();
            DrinkModel.Root drink = new DrinkModel.Root();
            var url = "https://www.thecocktaildb.com/api/json/v1/1/random.php";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                drink = JsonConvert.DeserializeObject<DrinkModel.Root>(await response.Content.ReadAsStringAsync());
            }

            return drink;
        }

        // setting up the list by inggreadient api call
        public static async Task<ListByIngredientModel.Root> GetListByIngredient(string searchTerm)
        {
            HttpClient client = new HttpClient();
            ListByIngredientModel.Root root = new ListByIngredientModel.Root();
            var url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?i={searchTerm}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                root = JsonConvert.DeserializeObject<ListByIngredientModel.Root>(await response.Content.ReadAsStringAsync());
            }

            return root;
        }

        //setting up the api call to get a list of drinks by the first letter 
        public static async Task<SearchByLetterModel.Root> GetDrinksByLetter(string searchTerm)
        {
            HttpClient client = new HttpClient();
            SearchByLetterModel.Root drinks = new SearchByLetterModel.Root();
            var url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?f={searchTerm}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                drinks = JsonConvert.DeserializeObject<SearchByLetterModel.Root>(await response.Content.ReadAsStringAsync());
            }

            return drinks;
        }

        //setting up the non alcoholic drink api call
        public static async Task<NonAlcoholicDrinkModel.Root> GetNonAlcoholicDrinks()
        {
            HttpClient client = new HttpClient();
            NonAlcoholicDrinkModel.Root drinks = new NonAlcoholicDrinkModel.Root();
            var url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?a=non%20Alcoholic";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                drinks = JsonConvert.DeserializeObject<NonAlcoholicDrinkModel.Root>(await response.Content.ReadAsStringAsync());
            }

            return drinks;

        }
    }
}
