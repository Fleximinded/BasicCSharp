using Employee.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.CLI.Models
{
    public class ClientItem: Person
    {
        public ClientItem() { }
        public byte DiscountPercentage { get; set; } = 0;
        public override string ToString()
        {
            return $"{base.ToString()} {Environment.NewLine} This client gets a discount of : {DiscountPercentage.ToString()}%";
        }
    }
}
