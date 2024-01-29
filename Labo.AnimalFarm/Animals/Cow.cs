using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.AnimalFarm.Animals
{
    public class Cow :Animal
    {
        public Cow(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Execute("moe");
        }
    }
}
