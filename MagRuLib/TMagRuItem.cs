using BLTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MagRuLib {
  public class TMagRuItem : TNamedItem, IMagRuItem, IToXml {

    #region --- XML constants ----------------------------------------------------------------------------------
    public const string XML_THIS_ELEMENT = "Item";
    public const string XML_ATTRIBUTE_ITEMTYPE = "Type";
    public const string XML_ATTRIBUTE_QUANTITY = "Quantity";
    public const string XML_ELEMENT_RECIPE = "Recipe";
    #endregion --- XML constants -------------------------------------------------------------------------------

    public string ItemType { get; set; }
    public int Quantity { get; set; } = 0;
    public IMagRuRecipe Recipe { get; set; } = new TMagRuRecipe();

    #region --- Constructor(s) ---------------------------------------------------------------------------------
    public TMagRuItem() { }
    public TMagRuItem(string name, string itemType = "Rune") : base(name) {
      ItemType = itemType;
    }
    public TMagRuItem(IMagRuItem item, int quantity = 0) {
      if (item == null) {
        return;
      }
      Name = item.Name;
      ItemType = item.ItemType;
      if (Recipe != null && Recipe.Items.Count() > 0) {
        Recipe = new TMagRuRecipe(Recipe);
      }
      Quantity = quantity;
    }

    public TMagRuItem(XElement itemElement) : base(itemElement) {
      if (itemElement == null) {
        return;
      }
      ItemType = itemElement.SafeReadAttribute<string>(XML_ATTRIBUTE_ITEMTYPE, "");
      Quantity = itemElement.SafeReadAttribute<int>(XML_ATTRIBUTE_QUANTITY, 0);
      if (itemElement.Elements(XML_ELEMENT_RECIPE).Count() > 0) {
        Recipe = new TMagRuRecipe(itemElement.Elements(XML_ELEMENT_RECIPE).First());
      }
    }
    #endregion --- Constructor(s) ------------------------------------------------------------------------------

    #region --- Converters -------------------------------------------------------------------------------------
    public XElement ToXml() {
      XElement RetVal = base.ToXml(XML_THIS_ELEMENT);
      RetVal.SetAttributeValue(XML_ATTRIBUTE_ITEMTYPE, ItemType);
      if (Quantity > 0) {
        RetVal.SetAttributeValue(XML_ATTRIBUTE_QUANTITY, Quantity);
      }
      if (Recipe != null && Recipe.Items.Count() > 0) {
        RetVal.Add(Recipe.ToXml());
      }
      return RetVal;
    }
    public override string ToString() {
      StringBuilder RetVal = new StringBuilder();
      RetVal.Append(Name);
      RetVal.Append($" => {ItemType}");
      if (Quantity > 0) {
        RetVal.Append($", {Quantity}");
      }
      if (Recipe != null && Recipe.Items.Count() > 0) {
        RetVal.AppendLine();
        RetVal.AppendLine("    Recipe");
        Recipe.ToString().Split('\n').ToList().ForEach(x => RetVal.AppendLine($"      {x}"));
      }
      return RetVal.ToString().Trim('\n', '\r');
    } 
    #endregion --- Converters ----------------------------------------------------------------------------------

  }
}
