using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BLTools;

namespace MagRuLib {
  public class TMagRuRecipe : TNamedItem, IMagRuRecipe {

    public const string XML_THIS_ELEMENT = "Recipe";

    public List<IMagRuItem> Items { get; set; } = new List<IMagRuItem>();

    #region --- Constructor(s) ---------------------------------------------------------------------------------
    public TMagRuRecipe() { }
    public TMagRuRecipe(string name) : base(name) {
    }

    public TMagRuRecipe(XElement recipeElement) : base(recipeElement) {
      if (recipeElement == null) {
        return;
      }
      IEnumerable<XElement> Components = recipeElement.Elements(TMagRuItem.XML_THIS_ELEMENT);
      if (Components.Count() == 0) {
        return;
      }
      foreach (XElement ComponentItem in Components) {
        Items.Add(new TMagRuItem(ComponentItem));
      }
    } 
    #endregion --- Constructor(s) ------------------------------------------------------------------------------

    public XElement ToXml() {
      XElement RetVal = base.ToXml(XML_THIS_ELEMENT);
      foreach(TMagRuItem ItemItem in Items) {
        RetVal.Add(ItemItem.ToString());
      }
      return RetVal;
    }

    public void AddItem(IMagRuItem item) {
      Items.Add(item);
    }

    public string GetRecipeComponentsAsText() {
      StringBuilder RetVal = new StringBuilder();
      RetVal.AppendLine(Name);
      foreach (TMagRuItem ItemItem in Items) {
        RetVal.AppendLine($"  => {ItemItem.Name}");
      }
      return RetVal.ToString().Trim('\n','\r');
    }

  }
}
