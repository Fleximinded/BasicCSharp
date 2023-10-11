using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Basis
{
    public class TextDemo
    {
        public static void ShowChar() {            
            short chValue = 68;
            char ch = (char)chValue;
            Console.WriteLine(ch);
            ch= '\u0279';
            Console.WriteLine(ch);
        }
        public static void ShowString()
        {
            string tekst = "Hallo iedereen";
            string copyVanTekst = tekst;    
            tekst="Nieuwe tekst";   
            Console.WriteLine(copyVanTekst);
            Console.WriteLine(tekst);
            tekst = "We declareren een tekst op deze manier: \"Dit is een tekst\". Goed hé!";

            Console.WriteLine(tekst);
        }
        public static void ShowText()
        {
            Console.Write("Geef een tekst in : ");
            string? yourText=Console.ReadLine();
            string showText = "Je tekst is: " + yourText;
            Console.WriteLine(showText);
            showText = $"Je tekst is: {yourText}";   
            Console.WriteLine(showText);
        }
        public static void ShowCoolText()
        {
            Console.Write("Geef een tekst in : ");
            string? yourText = Console.ReadLine();
            yourText = yourText?.ToUpper().Trim(':');
            string showText = $"Je tekst is: {yourText}";
            Console.WriteLine(showText);
        }
    }
}
