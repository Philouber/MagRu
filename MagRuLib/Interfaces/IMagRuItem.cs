﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuLib {
  public interface IMagRuItem : IName {
    string ItemType { get; }
    int Quantity { get; }
  }
}
