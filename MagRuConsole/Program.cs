using MagRuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuConsole {
  class Program {
    static void Main(string[] args) {

      Console.WriteLine("Demo read all gems");
      using (TDatabase Db = new TDatabase()) {
        List<TItem> Items = Db.GetAllItems().ToList();
        foreach(TItem ItemItem in Items) {
          Console.WriteLine($"Item = {ItemItem.Name}");
        }
      }

      Console.WriteLine("Demo read all recipes");
      using (TDatabase Db = new TDatabase("MagRuDbDemo")) {
        List<TRecipe> Recipes = Db.GetAllRecipes().ToList();
        foreach (TRecipe RecipeItem in Recipes) {
          Console.WriteLine($"Item = {RecipeItem.Name}");
        }
      }

      Console.WriteLine("Demo read all recipes with details");
      using (TDatabase Db = new TDatabase("MagRuDbDemo")) {
        List<TRecipe> Recipes = Db.GetAllRecipes().ToList();
        foreach (TRecipe RecipeItem in Recipes) {
          Console.WriteLine($"Item = {RecipeItem.GetRecipeComponentsAsText()}");
        }
      }

      Console.WriteLine("Demo read all recipes for blue gem");
      using (TDatabase Db = new TDatabase("MagRuDbDemo")) {
        List<TRecipe> Recipes = Db.GetAllRecipesForItem(new TItem("Blue")).ToList();
        foreach (TRecipe RecipeItem in Recipes) {
          Console.WriteLine($"Item = {RecipeItem.GetRecipeComponentsAsText()}");
        }
      }

      Console.WriteLine("Completed.");

    }
  }
}
