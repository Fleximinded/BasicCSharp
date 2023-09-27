namespace BasicCSharp.Labo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float Pi = 3.14f;
            Console.Write("Pi = ");
            Console.WriteLine(Pi);
            // Oef 2
            decimal getal = 2500.25M;
            Console.Write("getal = ");
            Console.WriteLine(getal);
            // Oef 3
            int maxInt = int.MaxValue;
            Console.Write("maxInt = ");
            Console.WriteLine(maxInt);
            Console.Write("maxInt + 1 = "); 
            Console.WriteLine(++maxInt);
            // Oef 4
            ushort maxUShort = ushort.MaxValue;
            Console.Write("maxUShort = ");  
            Console.WriteLine(++maxUShort);
        }
    }
}