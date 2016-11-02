using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuLib {
  public class TItem {

    public string Name { get; set; }
    
    public TItem() { }
    public TItem(string name) {
      Name = name;
    }
  }
}
