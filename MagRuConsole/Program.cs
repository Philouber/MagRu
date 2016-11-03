using BLTools.ConsoleExtension;
using MagRuLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagRuConsole {
  class Program {
    static void Main(string[] args) {

      using (IMagRuDatabase Db = new TMagRuDbDemo()) {
        TestDb("Test with demo DB", Db);
      }
      ConsoleExtension.Pause();
      Console.WriteLine();

      using (IMagRuDatabase Db = new TMagRuDbXml("data", "items.xml")) {
        TestDb("Test with XML DB", Db);
      }

      ConsoleExtension.Pause();
    }

    static void TestDb(string title, IMagRuDatabase MagRuDatabase) {

      Console.WriteLine($"== {title} ==");
      Console.WriteLine("-- Read all items");
      foreach (TMagRuItem ItemItem in MagRuDatabase.GetAllItems()) {
        Console.WriteLine($"  Item = {ItemItem.ToString()}");
      }

      Console.WriteLine("-- Read all items requesting blue item");
      foreach (TMagRuItem ItemItem in MagRuDatabase.GetAllItemsRequestingItem(new TMagRuItem("Blue"))) {
        Console.WriteLine($"  Item = {ItemItem.ToString()}");
      }

      Console.WriteLine("-- Read all items requesting red item");
      foreach (TMagRuItem ItemItem in MagRuDatabase.GetAllItemsRequestingItem(new TMagRuItem("Red"))) {
        Console.WriteLine($"  Item = {ItemItem.ToString()}");
      }

      Console.WriteLine("== Completed.");
    }
  }
}
