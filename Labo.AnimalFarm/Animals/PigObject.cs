using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.AnimalFarm.Animals
{
    public class PigObject : Animal
    {
        public PigObject(string name) : base(name)
        {
        }
        public override void MakeSound()
        {
            Execute("knor","pig");
        }
    }
}
