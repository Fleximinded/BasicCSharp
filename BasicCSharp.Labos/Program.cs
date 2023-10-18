using System.ComponentModel;

namespace BasicCSharp.Labos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Write(">");
                string input = Console.ReadLine() ?? "";
                switch(input.ToLower())
                {
                    case "exit":
                    case "quit":
                        isRunning = false;
                        break;
                    case "echo":
                        Console.WriteLine($"You wrote '{input}' ");
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}