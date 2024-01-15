using Employee.CLI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.CLI.CLI
{
    public class EmployeeCommands
    {
        EmployeeList Employees { get; set; } = new EmployeeList();
        public static bool RunCLI(string[] args) {
            EmployeeCommands commands = new EmployeeCommands();
            return commands.Run(args);
        }
        public bool Run(string[] args)
        {
            string currentCursor = ">";
            try
            {
                while(true)
                {
                    ShowCursor(currentCursor);
                    string rawCommand = Console.ReadLine() ?? "";
                    if(!string.IsNullOrEmpty(rawCommand))
                    {
                        string[] commands = rawCommand.Split(' ');
                        if(commands?.Length > 0)
                        {
                            string cmd = commands[0];
                            if(commands.Length > 1)
                            {
                                if(Execute(rawCommand,cmd, commands.Skip(1).ToArray())) { return true; }
                            }
                            else
                            {
                                if(Execute(rawCommand, cmd, [] )) { return true; }
                            }
                            // Bovenstaande kan je vervangen door volgend script te gebruiken:
                            //   if(Execute(rawCommand,cmd, commands.Length>1? commands.Skip(1).ToArray() : []  )) { return true; }
                        }
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
        private bool Execute(string rawCommand,string command, string[] parameters)
        {
            object myEmployeeclass = Employees;
            EmployeeItem otherRef = (EmployeeItem)myEmployeeclass;
            if(string.IsNullOrEmpty(command)) return false;
            switch(command.ToLower())
            {
                case "exit":
                case "quit":
                    return true;
                case "clear":
                case "cls":
                    Console.Clear();
                    break;
                case "echo":
                    Console.WriteLine(rawCommand.Replace(command, " "));
                    break;
                case "seed":
                    SeedData();
                    Console.WriteLine($"Data is seeded with {Employees.List.Count} items");
                    break;
                case "find":
                    if(parameters.Length > 0)
                    {
                        var results = Employees.Find(parameters[0]);
                        if(results?.Count() > 0)
                        {
                            string? sepLine = null;
                            foreach(var result in results)
                            {
                                if(sepLine!=null)Console.WriteLine(sepLine);
                                Console.WriteLine(result.ToString());
                                sepLine = "**************************";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Geen enkel resultaat voldeed aan uw zoekopdracht");
                        }
                    }
                    else {
                        Console.WriteLine("Specifieer zoek data aub");
                    }
                    break;
                default:
                    ShowError($"The command '{command}' is not known in my wonderful system", ConsoleColor.DarkMagenta);
                    break;
            }
            return false;
        }
        private void ShowCursor(string currentCursor)
        {
            Console.Write(currentCursor);
        }
        void ShowError(string message, ConsoleColor errorColor = ConsoleColor.Red)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }

        void SeedData() {
            Employees.List.Clear();
            EmployeeItem data = new() {FirstName="Filip", LastName="Geens",SocialID ="1234566ABC", CallName="Fluppe"};
            data.Address.Street = "Oppernederoveronderheembeekseweg";
            data.Address.City = "WilWelRijkMaarTochNie";
            data.Address.HouseNumber = "465 1/2";
            data.Address.ZipCode = "123456";
            data.Contacts.Add(new() { Address = "03 0000000", Type = Contact.ContactType.GoodOldPhone });
            data.Contacts.Add(new() { Address = "03 0000001", Type = Contact.ContactType.GoodOldPhone, Name="Als den andere niet meer werkt!" });
            data.Contacts.Add(new() { Address = "0475 101010", Type = Contact.ContactType.MobilePhone });
            data.Contacts.Add(new() { Address = "filip.geens@fleximinded.com", Type = Contact.ContactType.Email});
            Employees.List.Add(data);
            data = new() { FirstName = "Kristof", LastName = "Mat", SocialID = "HAHA1212789", CallName = "Mat" };
            data.Address.Street = "Benedensebovenweg";
            data.Address.City = "Berchem";
            data.Address.HouseNumber = "1";
            data.Address.ZipCode = "2660";
            data.Contacts.Add(new() { Address = "0475 202222", Type = Contact.ContactType.MobilePhone ,Name="1+" });
            data.Contacts.Add(new() { Address = "0475 303333", Type = Contact.ContactType.MobilePhone ,Name="Amaai mijne Apple"});
            data.Contacts.Add(new() { Address = "kristof.mat@multi.pers", Type = Contact.ContactType.Email });
            Employees.List.Add(data);
            data = new() { FirstName = "David", LastName = "Bowie", SocialID = "MTOM12355", CallName = "Mr D" };
            data.Address.Street = "Hemels plein";
            data.Address.City = "Hiernamaals";
            data.Address.HouseNumber = "15651458214";
            data.Address.ZipCode = "1";
            data.Contacts.Add(new() { Address = "david.bowie@pieter.sint", Type = Contact.ContactType.Email });
            Employees.List.Add(data);
            data = new() { FirstName = "Filip", LastName = "Geubels", SocialID = "COLRUYTHAHAHA", CallName = "Geubels" };
            data.Address.Street = "Tepelhofweg";
            data.Address.City = "Brussel";
            data.Address.HouseNumber = "111";
            data.Address.ZipCode = "1000";
            data.Contacts.Add(new() { Address = "02 111000", Type = Contact.ContactType.GoodOldPhone });
            data.Contacts.Add(new() { Address = "02 1110001", Type = Contact.ContactType.GoodOldPhone, Name = "Als den andere niet meer werkt!" });
            data.Contacts.Add(new() { Address = "0476 506070", Type = Contact.ContactType.MobilePhone });
            data.Contacts.Add(new() { Address = "filip.geubels@colruyt.be", Type = Contact.ContactType.Email });
            Employees.List.Add(data);
        }
    }
}
