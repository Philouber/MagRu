using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuLib {
  public class TDatabase : IDisposable {

    private bool _IsDemo {
      get {
        return Name == "MagRuDbDemo" || string.IsNullOrWhiteSpace(Name);
      }
    }
    private TItem _BlueItem;
    private TItem _GreenItem;
    private TItem _RedItem;
    private List<TItem> _TableItem;
    private TRecipe _Recipe1;
    private TRecipe _Recipe2;
    private TRecipe _Recipe3;
    private List<TRecipe> _TableRecipe;


    public string Name { get; set; }

    public TDatabase() {
      Initialize();
    }
    public TDatabase(string name) : this() {
      Name = name;
      Initialize();
    }

    public void Initialize() {
      if (_IsDemo) {
        _BlueItem = new TItem("Blue");
        _GreenItem = new TItem("Green");
        _RedItem = new TItem("Red");
        _TableItem = new List<TItem>() { _BlueItem, _GreenItem, _RedItem };

        _Recipe1 = new TRecipe("Recipe 1");
        _Recipe1.AddItem(_BlueItem);
        _Recipe2 = new TRecipe("Recipe 2");
        _Recipe2.AddItem(_GreenItem);
        _Recipe2.AddItem(_RedItem);
        _Recipe3 = new TRecipe("Recipe 3");
        _Recipe3.AddItem(_BlueItem);
        _Recipe3.AddItem(_GreenItem);
        _Recipe3.AddItem(_RedItem);
        _TableRecipe = new List<TRecipe>() { _Recipe1, _Recipe2, _Recipe3 };
      }
    }

    public IEnumerable<TItem> GetAllItems(string itemName = "") {
      if (_IsDemo) {
        if (itemName == "") {
          return _TableItem;
        } else {
          return _TableItem.Where(x => x.Name == itemName);
        }
      }

      IEnumerable<TItem> RetVal = new List<TItem>();
      return RetVal;
    }

    public IEnumerable<TRecipe> GetAllRecipes(string recipeName = "") {
      List<TRecipe> RetVal = new List<TRecipe>();
      if (_IsDemo) {
        if (recipeName == "") {
          return _TableRecipe;
        } else {
          return _TableRecipe.Where(x => x.Name == recipeName);
        }
      }
      return RetVal;
    }

    public IEnumerable<TRecipe> GetAllRecipesForItem(TItem item) {

      if (_IsDemo) {
        if (item == null) {
          yield break;
        } else {
          foreach (TRecipe RecipeItem in _TableRecipe) {
            if (RecipeItem.Items.Where(x => x.Name.ToLower() == item.Name.ToLower()).Count() > 0) {
              yield return RecipeItem;
            }
          }
        }

        //IEnumerable<TRecipe> RetVal = new List<TRecipe>();
        yield break;
      }
    }

    public void Dispose() {

    }

  }
}
