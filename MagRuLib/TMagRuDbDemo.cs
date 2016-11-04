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
    protected IMagRuItem _WarriorLevel2;
    protected IMagRuItem _WarriorLevel3;
    protected IMagRuItem _WarriorLevel4;
    protected List<IMagRuItem> _TableItem;
    

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

      _WarriorLevel2 = new TMagRuItem("Warrior Level 2");
      _WarriorLevel2.Recipe.AddItem(_BlueItem, 10000);

      _WarriorLevel3 = new TMagRuItem("Warrior Level 3");
      _WarriorLevel3.Recipe.AddItem(_BlueItem, 10000);
      _WarriorLevel3.Recipe.AddItem(_GreenItem, 15000);

      _WarriorLevel4 = new TMagRuItem("Warrior Level 4");
      _WarriorLevel4.Recipe.AddItem(_BlueItem, 10000);
      _WarriorLevel4.Recipe.AddItem(_GreenItem, 15000);
      _WarriorLevel4.Recipe.AddItem(_RedItem, 20000);

      _TableItem = new List<IMagRuItem>() { _BlueItem, _GreenItem, _RedItem, _WarriorLevel2, _WarriorLevel3, _WarriorLevel4 };
     
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

    public override IEnumerable<IMagRuItem> GetAllItemsRequestingItem(IMagRuItem item) {

      if (item == null) {
        yield break;
      } else {
        foreach (IMagRuItem ItemItem in _TableItem) {
          if (ItemItem.Recipe.Items.Where(x => x.Name.ToLower() == item.Name.ToLower()).Count() > 0) {
            yield return ItemItem;
          }
        }

        yield break;
      }
    }

    public override void Dispose() {
      _TableItem.Clear();
      _TableItem = null;
    }

  }
}
