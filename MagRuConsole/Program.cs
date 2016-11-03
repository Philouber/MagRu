using BLTools.ConsoleExtension;
using MagRuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuConsole {
  class Program {
    static void Main(string[] args) {

      Console.WriteLine("Test with demo DB");
      using (IMagRuDatabase Db = new TMagRuDbDemo()) {
        TestDb(Db);
      }

      ConsoleExtension.Pause();
    }

    static void TestDb(IMagRuDatabase MagRuDatabase) {

      Console.WriteLine("Demo read all gems");
      foreach (TMagRuItem ItemItem in MagRuDatabase.GetAllItems()) {
        Console.WriteLine($"Item = {ItemItem.Name}");
      }

      Console.WriteLine("Demo read all recipes");
      foreach (TMagRuRecipe RecipeItem in MagRuDatabase.GetAllRecipes()) {
        Console.WriteLine($"Item = {RecipeItem.Name}");
      }

      Console.WriteLine("Demo read all recipes with details");
      foreach (TMagRuRecipe RecipeItem in MagRuDatabase.GetAllRecipes()) {
        Console.WriteLine($"Item = {RecipeItem.GetRecipeComponentsAsText()}");
      }

      Console.WriteLine("Demo read all recipes for blue gem");
      foreach (TMagRuRecipe RecipeItem in MagRuDatabase.GetAllRecipesForItem(new TMagRuItem("Blue"))) {
        Console.WriteLine($"Item = {RecipeItem.GetRecipeComponentsAsText()}");
      }

      Console.WriteLine("Completed.");
    }
  }
}
