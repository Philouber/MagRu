using BLTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MagRuLib {
  public abstract class TNamedItem : IName {

    public const string XML_THIS_ELEMENT_BASE = "(named item)";
    public const string XML_ATTRIBUTE_NAME = "Name";

    public string Name { get; set; }

    public TNamedItem (string name = "") {
      Name = name;
    }

    public TNamedItem (XElement namedItemElement) {
      if (namedItemElement==null) {
        return;
      }
      Name = namedItemElement.SafeReadAttribute<string>(XML_ATTRIBUTE_NAME, "");
    }

    //public abstract XElement ToXml();

    public virtual XElement ToXml(XName elementName) {
      XElement RetVal = new XElement(elementName);
      RetVal.SetAttributeValue(XML_ATTRIBUTE_NAME, Name);
      return RetVal;
    }

  }
}
