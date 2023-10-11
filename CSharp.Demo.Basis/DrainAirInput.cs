using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Basis
{
    public class DrainAir
    {
        static string? fistName;
        static string? lastName;
        static DateTime? FlightTime = DateTime.Now;
        static int passangerCount = 0;
        static double price = 0.0;
        static Random rand = new Random();
        public static bool DrainAirInput()
        {
            Console.Write("Geef je voornaam in: ");
            fistName = Console.ReadLine();
            Console.Write("Geef je achternaam in: ");
            lastName = Console.ReadLine();
            Console.Write("Geef je vluchttijd in: ");
            string? input = Console.ReadLine();
            if(DateTime.TryParse(input,CultureInfo.CreateSpecificCulture("nl-BE") ,out DateTime result))
            {
                FlightTime = result;
            }
            else
            {
                Console.WriteLine("Foutieve datum");
                return false;
            }
            Console.Write("Geef het aantal passagiers in: ");

            input = Console.ReadLine();
            if(int.TryParse(input, out passangerCount))
            {
                Console.WriteLine($"Je selecteerde {passangerCount} passagiers");
            }
            else
            {
                Console.WriteLine("Foutief aantal passagiers");
                return false;
            }   
            Console.Write("Geef de max prijs in: ");
            input = Console.ReadLine();
            if(double.TryParse(input, out price))
            {
                price = rand.Next((int)(price / 2), (int)price);
                Console.WriteLine($"De prijs per ticket is {price.ToString("C2")}");   
                Console.WriteLine($"De totale prijs is {(price * (double)passangerCount).ToString("C2")} ");
            }
            else
            {
                Console.WriteLine("Foutieve prijs");
                return false;
            }

            return true;
        }
        public static void ShowYourelection()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Je selecteerde de volgende vlucht:");
            Console.WriteLine($"Je voornaam is {fistName}");
            Console.WriteLine($"Je achternaam is {lastName}");
            Console.WriteLine($"Je vluchttijd is {FlightTime}");
            Console.WriteLine($"Je selecteerde {passangerCount} passagiers");
            Console.WriteLine($"De totale prijs is {(price * (double)passangerCount).ToString("C2")} ");
            Console.WriteLine("-------------------------------------------");
        }


    }
}
