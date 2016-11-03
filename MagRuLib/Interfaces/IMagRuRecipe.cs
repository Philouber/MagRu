using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuLib {
  public interface IMagRuRecipe : IName {
    List<IMagRuItem> Items { get; }

    void AddItem(IMagRuItem item);
  }
}
