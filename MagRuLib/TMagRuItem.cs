using BLTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MagRuLib {
  public class TMagRuItem : TNamedItem, IMagRuItem, IToXml {

    public const string XML_THIS_ELEMENT = "Item";
    public const string XML_ATTRIBUTE_ITEMTYPE = "Type";
    public const string XML_ATTRIBUTE_QUANTITY = "Quantity";
    
    public string ItemType { get; set; }
    public int Quantity { get; set; }

    #region --- Constructor(s) ---------------------------------------------------------------------------------
    public TMagRuRecipe Recipe { get; set; }

    public TMagRuItem() { }
    public TMagRuItem(string name) : base(name) {
    }

    public TMagRuItem(XElement itemElement) : base(itemElement) {
      if (itemElement == null) {
        return;
      }
      ItemType = itemElement.SafeReadAttribute<string>(XML_ATTRIBUTE_ITEMTYPE, "");
      Quantity = itemElement.SafeReadAttribute<int>(XML_ATTRIBUTE_QUANTITY, 0);
    } 
    #endregion --- Constructor(s) ------------------------------------------------------------------------------

    public XElement ToXml() {
      XElement RetVal = base.ToXml(XML_THIS_ELEMENT);
      RetVal.SetAttributeValue(XML_ATTRIBUTE_ITEMTYPE, ItemType);
      RetVal.SetAttributeValue(XML_ATTRIBUTE_QUANTITY, Quantity);
      return RetVal;
    }
  }
}
