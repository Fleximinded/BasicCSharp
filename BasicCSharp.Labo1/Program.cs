namespace BasicCSharp.Labo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double getal1 = 4.2;
            double getal2 = 5.8;
            Console.WriteLine(getal1 + getal2);
            Console.Write("Geef een tekst in: ");
            string tekst1 = Console.ReadLine();
            Console.Write("Dit is uw tekst : ");
            Console.WriteLine(tekst1);
            Console.ReadKey();
        }
    }
}