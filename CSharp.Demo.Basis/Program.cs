using System.Text;

namespace CSharp.Demo.Basis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;            
            DrainAir.DrainAirInput();
            DrainAir.ShowYourelection();
            Console.ReadKey();
        }
    }
}