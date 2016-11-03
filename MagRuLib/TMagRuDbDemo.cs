using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuLib {
  public class TMagRuDbDemo : TMagRuDbBase {

    protected IMagRuItem _BlueItem;
    protected IMagRuItem _GreenItem;
    protected IMagRuItem _RedItem;
    protected List<IMagRuItem> _TableItem;
    protected IMagRuRecipe _Recipe1;
    protected IMagRuRecipe _Recipe2;
    protected IMagRuRecipe _Recipe3;
    protected List<IMagRuRecipe> _TableRecipe;

    #region --- Constructor(s) ---------------------------------------------------------------------------------
    public TMagRuDbDemo() {
      _Initialize();
    }
    public TMagRuDbDemo(string name) : base(name) {
      _Initialize();
    }
    #endregion --- Constructor(s) ------------------------------------------------------------------------------

    private void _Initialize() {
      _BlueItem = new TMagRuItem("Blue");
      _GreenItem = new TMagRuItem("Green");
      _RedItem = new TMagRuItem("Red");
      _TableItem = new List<IMagRuItem>() { _BlueItem, _GreenItem, _RedItem };

      _Recipe1 = new TMagRuRecipe("Recipe 1");
      _Recipe1.AddItem(_BlueItem);
      _Recipe2 = new TMagRuRecipe("Recipe 2");
      _Recipe2.AddItem(_GreenItem);
      _Recipe2.AddItem(_RedItem);
      _Recipe3 = new TMagRuRecipe("Recipe 3");
      _Recipe3.AddItem(_BlueItem);
      _Recipe3.AddItem(_GreenItem);
      _Recipe3.AddItem(_RedItem);
      _TableRecipe = new List<IMagRuRecipe>() { _Recipe1, _Recipe2, _Recipe3 };
    }

    public override IEnumerable<IMagRuItem> GetAllItems() {
      return _TableItem;
    }
    public override IMagRuItem GetItem(string itemName = "") {
      if (itemName == "") {
        return null;
      } else {
        return _TableItem.FirstOrDefault(x => x.Name == itemName);
      }
    }
    public override IEnumerable<IMagRuRecipe> GetAllRecipes() {
        return _TableRecipe;
    }
    public override IMagRuRecipe GetRecipe(string recipeName = "") {
      if (recipeName == "") {
        return null;
      } else {
        return _TableRecipe.FirstOrDefault(x => x.Name == recipeName);
      }
    }
    public override IEnumerable<IMagRuRecipe> GetAllRecipesForItem(IMagRuItem item) {

      if (item == null) {
        yield break;
      } else {
        foreach (IMagRuRecipe RecipeItem in _TableRecipe) {
          if (RecipeItem.Items.Where(x => x.Name.ToLower() == item.Name.ToLower()).Count() > 0) {
            yield return RecipeItem;
          }
        }

        yield break;
      }
    }

    public override void Dispose() {
      _TableItem.Clear();
      _TableItem = null;
      _TableRecipe.Clear();
      _TableRecipe = null;
    }

  }
}
