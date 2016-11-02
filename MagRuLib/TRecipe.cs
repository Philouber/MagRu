using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuLib {
  public class TRecipe {

    public string Name { get; set; }
    public List<TItem> Items { get; set; } = new List<TItem>();

    public TRecipe() { }
    public TRecipe(string name) {
      Name = name;
    }

    public void AddItem(TItem item) {
      Items.Add(item);
    }

    public string GetRecipeComponentsAsText() {
      StringBuilder RetVal = new StringBuilder();
      RetVal.AppendLine(Name);
      foreach (TItem ItemItem in Items) {
        RetVal.AppendLine($"  => {ItemItem.Name}");
      }
      return RetVal.ToString().Trim('\n','\r');
    }

  }
}
