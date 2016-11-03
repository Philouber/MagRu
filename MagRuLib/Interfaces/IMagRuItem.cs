using BLTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuLib {
  public interface IMagRuItem : IName, IToXml {
    string ItemType { get; }
    int Quantity { get; }
    IMagRuRecipe Recipe { get; }
  }
}
