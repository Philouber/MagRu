using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MagRuLib {
  public abstract class TMagRuDbBase : TNamedItem, IMagRuDatabase, IDisposable {

    public TMagRuDbBase() { }
    public TMagRuDbBase(string name) : base(name) {

    }

    public virtual void Dispose() {
      Name = null;
    }

    public abstract IEnumerable<IMagRuItem> GetAllItems();

    public abstract IEnumerable<IMagRuRecipe> GetAllRecipes();

    public abstract IEnumerable<IMagRuRecipe> GetAllRecipesForItem(IMagRuItem item);

    public abstract IMagRuItem GetItem(string name);

    public abstract IMagRuRecipe GetRecipe(string name);

    
  }
}
