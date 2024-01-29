using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.AnimalFarm.Animals
{
    public class Horse : Animal
    {
        public Horse(string name) : base(name)
        {
        }
        public override void MakeSound()
        {
            Execute("hinnik", "Pjeid");
        }
    }
}
