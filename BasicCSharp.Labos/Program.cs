﻿using System.ComponentModel;
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
    }
}