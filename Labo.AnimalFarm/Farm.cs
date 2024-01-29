using Labo.AnimalFarm.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.AnimalFarm
{
    public class Farm
    {
        public Farm()
        {
            Animals.Add(new Dog("Scooby"));
            Animals.Add(new Chicken("Rooster"));
            Animals.Add(new Cow("Fifi"));
            Animals.Add(new Cow("Bella"));
            Animals.Add(new PigObject("Peppa"));
            Animals.Add(new Horse("Buddy"));
        }
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public void Start()
        {
            foreach(var animal in Animals)
            {
                animal.MakeSound();
            }
        }
    }
}
