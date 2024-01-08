using System.Text;

namespace CSharp.Demo.Basis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            WinkelLijst? winkelLijst = null;
            while(true)
            {
                Console.Write(">");
                string[]? command=Console.ReadLine()?.Split(" ") ?? [];
                if(command?.Length >= 0)
                {
                    switch(command[0].ToLower()) {
                        case "new":
                            winkelLijst = new WinkelLijst(); 
                            break;
                        case "add": {
                            if(command.Length > 2)
                            {
                                if(winkelLijst != null)
                                {
                                    winkelLijst.Add(command[1], command[2], command[3]);
                                }
                                else {
                                    Console.WriteLine("Maak eerst een lijst aan");
                                }
                            }
                            else {
                                Console.WriteLine($"de add moet parameters bevatten voor de groep, product en hoeveelheid");
                            }
                            break;
                        }
                    }

                }

            }
            //Console.OutputEncoding = Encoding.Unicode;
            //if(DrainAir.DrainAirInput())
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    DrainAir.ShowYourelection();
            //}
            //else
            //{
            //    Console.Clear();
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Shit, verkeerd!");
            //}

            //Console.ReadKey();
        }
    }
}