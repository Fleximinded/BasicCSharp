using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Employee.CLI.Models
{
    public class EmployeeItem
    {
        public EmployeeItem()       {                        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CallName { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public string ShowContacts() {
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
        public override string ToString()
        {
            return $"{FirstName} {LastName} adres: {Address.ToString()} contacts:  {ShowContacts()}";
        }
    }
}
