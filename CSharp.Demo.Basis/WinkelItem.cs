using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Basis
{
    public class WinkelItem
    {
        string _group = "";
        public string Group { get { return _group; } set { _group = value; } }
        public string Name { get; set; } = "";
        public int Quantity { get; set; }
        public double EstimatedPrice { get; set; } = 1.0;
        public double TotalEstimatedPrice { get => CalculateTotalPrice(); }
        public WinkelItem() { _group = "Droge voeding"; }
        public WinkelItem(string group,string name,int quantity) :this()
        {
            Group = group;
            Name = name;
            Quantity = quantity;         
        }
        public WinkelItem(string group, string name, string quantity) : this(group,name,0)
        {
            if(int.TryParse(quantity, out int qty))
            {
                Quantity = qty;
            }
        }
        public WinkelItem(string group, string name, int quantity, double estimatedPrice) : this(group,name,quantity)
        {
            EstimatedPrice = estimatedPrice;
        }
        public double CalculateTotalPrice(double? usePrice=null) {
            if(usePrice == null) usePrice = EstimatedPrice;
            return Quantity*usePrice.Value;
        }
    }
}
