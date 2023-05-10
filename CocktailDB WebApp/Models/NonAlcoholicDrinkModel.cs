namespace CocktailDB_WebApp.Models
{
    public class NonAlcoholicDrinkModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Drink
        {
            public string strDrink { get; set; }
            public string strDrinkThumb { get; set; }
            public string idDrink { get; set; }
        }

        public class Root
        {
            public List<Drink> drinks { get; set; }
        }


    }
}
