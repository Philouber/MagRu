using BLTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuLib {
  public interface IMagRuRecipe : IName, IToXml {
    List<IMagRuItem> Items { get; }
    void AddItem(IMagRuItem item);
    void AddItem(IMagRuItem item, int quantity);
  }
}
