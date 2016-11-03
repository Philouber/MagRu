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
    public TMagRuRecipe(IMagRuRecipe recipe) {
      Name = recipe.Name;
      foreach(IMagRuItem ItemItem in Items) {
        Items.Add(new TMagRuItem(ItemItem));
      }
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

    #region --- Converters -------------------------------------------------------------------------------------
    public XElement ToXml() {
      XElement RetVal = base.ToXml(XML_THIS_ELEMENT);
      if (Items.Count() > 0) {
        foreach (IMagRuItem ItemItem in Items) {
          RetVal.Add(ItemItem.ToXml());
        }
      }
      return RetVal;
    }

    public override string ToString() {
      StringBuilder RetVal = new StringBuilder();
      if (Items.Count() > 0) {
        foreach (IMagRuItem ItemItem in Items) {
          RetVal.AppendLine(ItemItem.ToString());
        }
      }
      return RetVal.ToString().Trim('\n', '\r');
    } 
    #endregion --- Converters ----------------------------------------------------------------------------------

    public void AddItem(IMagRuItem item) {
      Items.Add(item);
    }
    public void AddItem(IMagRuItem item, int quantity) {
      TMagRuItem NewItem = new TMagRuItem(item, quantity);
      Items.Add(NewItem);
    }

  }
}
