using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuLib {
  public interface IMagRuDatabase : IDisposable {
    IEnumerable<IMagRuItem> GetAllItems();
    IMagRuItem GetItem(string name);
    IEnumerable<IMagRuRecipe> GetAllRecipes();
    IMagRuRecipe GetRecipe(string name);
    IEnumerable<IMagRuRecipe> GetAllRecipesForItem(IMagRuItem item);
  }
}
