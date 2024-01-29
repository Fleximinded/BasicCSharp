namespace Labo.AnimalFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Farm myFarm = new Farm();
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            myFarm.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
