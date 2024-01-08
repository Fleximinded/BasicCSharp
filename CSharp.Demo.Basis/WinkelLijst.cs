using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Basis
{
    public class WinkelLijst
    {
        public Dictionary<string, WinkelItem> ShoppingList { get; } = new Dictionary<string, WinkelItem>();
        
        public void Add(WinkelItem item) => ShoppingList.Add(item.Name.ToLower(),item);
        public void Add(string group, string name, int quantity, double estimatedPrice=0.0) {
           Add(new WinkelItem(group, name, quantity, estimatedPrice));
        }
        public void Add(string group, string name, string quantity)
        {
            Add(new WinkelItem(group, name, quantity));
        }
        public bool Remove(string itemName) {
            if(ShoppingList.ContainsKey(itemName.ToLower())) { ShoppingList.Remove(itemName); return true; }
            return false;
        }
    }
}
