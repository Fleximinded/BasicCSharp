using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.AnimalFarm.Animals
{
    public class Dog :Animal
    {
        public Dog(string name) : base(name) { }
        public override void MakeSound()
        {
            Execute("bark");
        }
    }
}
