using System.ComponentModel;
using System.Drawing;

namespace BasicCSharp.Labos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            string currentCursor = ">";
            ConsoleColor currentCursorColor = ConsoleColor.Green;
            ConsoleColor backgroundColor = ConsoleColor.Black;
            ConsoleColor foregroundColor = ConsoleColor.White;
            while(isRunning)
            {
                ShowCursor(currentCursor, currentCursorColor);
                string input = Console.ReadLine() ?? "";
                switch(input.ToLower())
                {
                    case "exit":
                    case "quit":
                        isRunning = false;
                        break;
                    case "clear":
                    case "cls":
                        Console.Clear();
                        break;
                    case "echo":
                        Console.WriteLine($"You wrote '{input}' ");
                        break;
                    case "setcursor":
                        currentCursor = SetCursor(currentCursor);
                        break;
                    case "setcursorcolor":
                        currentCursorColor = SetCursorColor(currentCursorColor, backgroundColor);
                        break;
                    case "setbackgroundcolor":
                        backgroundColor = SetBackgroundColor(backgroundColor, foregroundColor);
                        break;
                    case "setforegroundcolor":
                        foregroundColor = SetForegroundColor(foregroundColor,backgroundColor);
                        break;
                    case "telop":
                    case "addnumbers":
                        AddDecimalNumbers();
                        break;
                    case "birthday":
                    case "verjaardag":
                        CalculateBirthdayInfo();
                        break;
                    default:
                        ShowError($"The command '{input}' is not known in my wonderful system", ConsoleColor.DarkMagenta);
                        break;
                }
            }
        }
        private static ConsoleColor SetCursorColor(ConsoleColor currentCursorColor, ConsoleColor backgroundColor)
        {
            Console.Write("Enter the new cursor color: ");
            string color = Console.ReadLine() ?? "";
            if(string.IsNullOrEmpty(color)!=true)
            {
                if(Enum.TryParse<ConsoleColor>(color, true,out ConsoleColor newColor)) {
                    return newColor;
                }
            }
            ShowError($"The value '{color}' is not a valid color");
            return currentCursorColor;
        }

        private static void ShowCursor(string currentCursor, ConsoleColor currentCursorColor)
        {
            ConsoleColor current=Console.ForegroundColor;
            Console.ForegroundColor = currentCursorColor;
            Console.Write(currentCursor);
            Console.ForegroundColor = current;
        }

        static void ShowError(string message,ConsoleColor errorColor= ConsoleColor.Red)
        {
            ConsoleColor oldColor=Console.ForegroundColor;
            Console.ForegroundColor = errorColor;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }
        static string SetCursor(string currentCursor)
        {
            Console.Write("Enter the new cursor: ");
            string cursor = Console.ReadLine() ?? "";
            if(string.IsNullOrEmpty(cursor) || char.IsLetterOrDigit(cursor, cursor.Length - 1))
            {
                ShowError($"The cursor '{cursor}' is not valid. The last character may not be a number or letter");
                return currentCursor;
            }
            Console.Clear();
            return cursor;
        }
        static ConsoleColor SetBackgroundColor(ConsoleColor currentColor,ConsoleColor foreColor) {
            Console.Write("Enter the new background color: ");
            string color = Console.ReadLine() ?? "";
            if(Enum.TryParse<ConsoleColor>(color, true, out ConsoleColor newColor) && newColor != foreColor)
            {
                Console.BackgroundColor = newColor;
                Console.Clear();
                return newColor;
            }
            else
            {
                Console.WriteLine($"The color '{color}' is not valid ");
            }
            return currentColor;
        }
        static ConsoleColor SetForegroundColor(ConsoleColor foreColor, ConsoleColor backgroundColor)
        {
            Console.Write("Enter the new forground color: ");
            string color = Console.ReadLine() ?? "";
            if(Enum.TryParse<ConsoleColor>(color, true, out ConsoleColor newColor) && newColor != backgroundColor)
            {
                Console.ForegroundColor = newColor;
                Console.Clear();
                return newColor;
            }
            return foreColor;
        }
        static void AddDecimalNumbers() {
            double number1 = GetUserInputAsDouble("Geef een eerste getal","Opgepast, foute ingave. Het getal wordt 0");
            double number2 = GetUserInputAsDouble("Geef een tweede getal", "Opgepast, foute ingave. Het getal wordt 0");
            Console.WriteLine($"Het resultaat van {number1} + {number2} = {(number1 + number2).ToString("N2")}");
        }

        private static void CalculateBirthdayInfo()
        {
            int day = GetUserInputAsInt("Geef uw geboortedag");
            DateTime birtday = new DateTime(GetDateInput("jaar", 2023), GetDateInput("maand", 12), GetDateInput("dag", 31));
            TimeSpan calculation = DateTime.Now - birtday;
            Console.WriteLine($"U leefde reeds {(int)calculation.TotalHours} uren of {(long)calculation.TotalSeconds} seconden");
        }
        static int GetDateInput(string msg,int max, string errorMsg = "De waarde is niet geldig")
        {
            int result = GetUserInputAsInt($"Geef uw {msg}", errorMsg);
            if(result>0 && result<=max) { return result; }
            return 1;   
        }
        static int GetUserInputAsInt(string msg = "Give a Int", string errorMsg = "Error")
        {
            int userinput = 0;
            Console.Write($"{msg} : ");
            string input = Console.ReadLine() ?? "";
            if(int.TryParse(input, out userinput))
            {
                return userinput;
            }
            ShowError(errorMsg);
            return 0;
        }
      
        static double GetUserInputAsDouble(string msg="Give a double",string errorMsg="Error")
        {
            double userinput = 0;   
            Console.Write($"{msg} : ");
            string input = Console.ReadLine() ?? "";   
            if(double.TryParse(input,out userinput) )
            {
                return userinput;
            }
            ShowError(errorMsg);
            return 0;
        }
    }
}