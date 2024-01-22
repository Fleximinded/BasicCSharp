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
        PersonList Persons { get; set; } = new PersonList();
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
                case "seeddata":
                    SeedData();
                    Console.WriteLine($"Data is seeded with {Persons.List.Count} items");
                    break;
                case "contact":
                case "send":
                    if(parameters.Length > 1)
                    {
                        string sendMsg = rawCommand.Replace(command, "");
                        sendMsg = sendMsg.Replace(parameters[0], "").Trim(' ');
                        foreach(var message in Persons.SendMessage(sendMsg, parameters[0])) {
                            Console.WriteLine(message ?? "");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        ShowError("Gelieve een titel en boodschap mee te geven aub");
                    }
                    break;
                case "show":
                    PersonList.PersonType selectedType = PersonList.PersonType.All;
                    if(parameters.Length == 1)
                    {
                        switch(parameters[0].ToLower()) {
                            case "-e":
                            case "-employee":
                            case "-w":
                            case "-werknemer":
                                selectedType = PersonList.PersonType.Employee;
                                break;
                            case "-c":
                            case "-client":
                            case "-k":
                            case "-klant":
                                selectedType = PersonList.PersonType.Client;
                                break;
                        }
                    }
                    var showItems = Persons.Show(selectedType);
                    foreach(var item in showItems)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "find":
                    if(parameters.Length > 0)
                    {
                        var results = Persons.Find(parameters[0]);
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
            Persons.List.Clear();
            Person data = new EmployeeItem() { FirstName = "Filip", LastName = "Geens", SocialID = "1234566ABC", CallName = "Fluppe", InService = DateTime.Now - TimeSpan.FromDays(5000) };
            data.Address.Street = "Oppernederoveronderheembeekseweg";
            data.Address.City = "WilWelRijkMaarTochNie";
            data.Address.HouseNumber = "465 1/2";
            data.Address.ZipCode = "123456";
            data.Contacts.Add(new() { Address = "03 0000000", Type = Contact.ContactType.GoodOldPhone });
            data.Contacts.Add(new() { Address = "03 0000001", Type = Contact.ContactType.GoodOldPhone, Name="Als den andere niet meer werkt!" });
            data.Contacts.Add(new() { Address = "0475 101010", Type = Contact.ContactType.MobilePhone });
            data.Contacts.Add(new() { Address = "filip.geens@fleximinded.com", Type = Contact.ContactType.Email});
            Persons.List.Add(data);
            data = new ClientItem() { FirstName = "Kristof", LastName = "Mat", SocialID = "HAHA1212789", CallName = "Mat", DiscountPercentage=1 };
            data.Address.Street = "Benedensebovenweg";
            data.Address.City = "Berchem";
            data.Address.HouseNumber = "1";
            data.Address.ZipCode = "2660";
            data.Contacts.Add(new() { Address = "0475 202222", Type = Contact.ContactType.MobilePhone ,Name="1+" });
            data.Contacts.Add(new() { Address = "0475 303333", Type = Contact.ContactType.MobilePhone ,Name="Amaai mijne Apple"});
            data.Contacts.Add(new() { Address = "kristof.mat@multi.pers", Type = Contact.ContactType.Email });
            Persons.List.Add(data);
            data = new ClientItem() { FirstName = "David", LastName = "Bowie", SocialID = "MTOM12355", CallName = "Mr D", DiscountPercentage=10 };
            data.Address.Street = "Hemels plein";
            data.Address.City = "Hiernamaals";
            data.Address.HouseNumber = "15651458214";
            data.Address.ZipCode = "1";
            data.Contacts.Add(new() { Address = "david.bowie@pieter.sint", Type = Contact.ContactType.Email });
            Persons.List.Add(data);
            data = new EmployeeItem() { FirstName = "Filip", LastName = "Geubels", SocialID = "COLRUYTHAHAHA", CallName = "Geubels", InService=DateTime.Now-TimeSpan.FromDays(150), OutService=DateTime.Now+TimeSpan.FromDays(1) };
            data.Address.Street = "Tepelhofweg";
            data.Address.City = "Brussel";
            data.Address.HouseNumber = "111";
            data.Address.ZipCode = "1000";
            data.Contacts.Add(new() { Address = "02 111000", Type = Contact.ContactType.GoodOldPhone });
            data.Contacts.Add(new() { Address = "02 1110001", Type = Contact.ContactType.GoodOldPhone, Name = "Als den andere niet meer werkt!" });
            data.Contacts.Add(new() { Address = "0476 506070", Type = Contact.ContactType.MobilePhone });
            data.Contacts.Add(new() { Address = "filip.geubels@colruyt.be", Type = Contact.ContactType.Email });
            Persons.List.Add(data);
        }
    }
}
