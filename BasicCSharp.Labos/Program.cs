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
                            currentCursorColor=SetCursorColor(currentCursorColor,backgroundColor);
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
            Console.ForegroundColor = currentCursorColor;
            Console.Write(currentCursor);
            Console.ResetColor();
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
    }
}