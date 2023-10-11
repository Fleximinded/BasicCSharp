using System.Text;

namespace CSharp.Demo.Basis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            if(DrainAir.DrainAirInput())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                DrainAir.ShowYourelection();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Shit, verkeerd!");
            }

            Console.ReadKey();
        }
    }
}