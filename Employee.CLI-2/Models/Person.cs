using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.CLI.Models
{
    public abstract class Person
    {
        public Person() { }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CallName { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public string ShowContacts()
        {
            string contacts = "";
            string sep = "";
            foreach(Contact contact in Contacts)
            {
                contacts += $"{sep}{contact.ToString()}";
                sep = ",";
            }
            return contacts;
        }
        public string SocialID { get; set; } = string.Empty;

        public string SendMessage(string message, string? title = null) { 
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Aan {FirstName} {LastName}");
            stringBuilder.AppendLine($"{Address.Street} {Address.HouseNumber}");
            stringBuilder.AppendLine($"{Address.ZipCode} {Address.City}");
            stringBuilder.AppendLine($"{Address.Country}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Beste {title ?? ""} {FirstName},");
            stringBuilder.AppendLine(message);
            return stringBuilder.ToString();        
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} adres: {Address.ToString()} contacts:  {ShowContacts()}";
        }
    }
}
