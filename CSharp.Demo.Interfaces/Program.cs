
using CSharp.Demo.Interfaces.Contracts;
using CSharp.Demo.Interfaces.Models;

namespace CSharp.Demo.Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo();
        }

        private static void Demo()
        {
            List<IPerson> list = [
                new Teacher() { FirstName = "Billy", LastName = "The Kid", Topics = ["Robery", "Killing"] },
                new Student() { FirstName = "John", LastName = "Doe", Results = new Dictionary<string, double> { { "C#", 5.0 }, { "Huishoudkunde", 8.0 } } }];
            //                new Teacher("Frits", "Rits", ["Economie", "Wiskunde"])];
            foreach(IPerson person in list)
            {
                Console.WriteLine(person.Print());
            }
        }
    }
}
