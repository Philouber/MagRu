using BLTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MagRuLib {
  public class TMagRuDbXml : TMagRuDbBase {

    public string Location { get; set; }
    public string FullFilename {
      get {
        return Path.Combine(Location, Name);
      }
    }
    public bool IsDataSourceOk {
      get {
        if (string.IsNullOrWhiteSpace(FullFilename)) {
          return false;
        }
        if (!File.Exists(FullFilename)) {
          return false;
        }
        return true;
      }
    }

    public TMagRuDbXml() : base("") { }
    public TMagRuDbXml(string location, string name) : base(name) {
      Location = location;
    }

    public override IEnumerable<IMagRuItem> GetAllItems() {
      XElement Root = _GetRootData();
      if (Root == null) {
        yield break;
      }

      IEnumerable<XElement> ElementItems = Root.Elements(TMagRuItem.XML_THIS_ELEMENT);
      if (ElementItems.Count() > 0) {
        foreach (XElement ElementItem in ElementItems) {
          yield return new TMagRuItem(ElementItem);
        }
      }
    }

    public override IMagRuItem GetItem(string name) {
      return GetAllItems().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
    }

    public override IEnumerable<IMagRuItem> GetAllItemsRequestingItem(IMagRuItem item) {
      foreach (IMagRuItem ItemItem in GetAllItems()) {
        if (ItemItem.Recipe == null || ItemItem.Recipe.Items.Count() == 0) {
          continue;
        }
        if (ItemItem.Recipe.Items.Where(x => x.Name.ToLower() == item.Name.ToLower()).Count() > 0) {
          yield return ItemItem;
        }
      }
      yield break;
    }




    private XElement _GetRootData() {
      if (!IsDataSourceOk) {
        return null;
      }
      try {
        XDocument MagRuDatabase = XDocument.Load(FullFilename);
        return MagRuDatabase.Element("root");
      } catch (Exception ex) {
        Trace.WriteLine($"Error reading XML database {FullFilename} : {ex.Message}");
        return null;
      }

    }
  }
}
