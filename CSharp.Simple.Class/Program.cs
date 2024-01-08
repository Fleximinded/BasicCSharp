using System;

namespace CSharp.Simple.Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please give your name: ");
            string myName = Console.ReadLine() ?? "";
            Person mySelf = new Person(myName);
            mySelf.SubtractFromBirthDate(TimeSpan.FromDays(10000));
            Console.WriteLine($"Hallo {mySelf.FirstName} {mySelf.LastName}. You are born on {mySelf.BirthDate.ToLongDateString()}");

            Console.Write("Please give your password: ");
            string pwd = Console.ReadLine() ?? "";
            Login.Logon(pwd);
            if(Login.IsValidated)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You are loged in with user name {Login.Name}.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You are not logged in! Please give a correct password next time.");
            }
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
