using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Simple.Class
{
    public class Person
    {
        public Person()
        {
            LastName = "Doe";
            BirthDate = DateTime.Now - TimeSpan.FromDays(50000);
        }
        public Person(string firstName, string lastName = "", DateTime? birthDate = null)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate ?? BirthDate;
        }
        string firstName = string.Empty;
        public string? FirstName { 
            get { return firstName; } 
            set { 
                firstName = value ?? string.Empty; 
                Login.Name = firstName; // Zet de statische login naam
            } 
        }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;

        public void SubtractFromBirthDate(int days) => SubtractFromBirthDate(TimeSpan.FromDays(days));
        public void SubtractFromBirthDate(TimeSpan span)
        {
            BirthDate -= span;
        }
    }
}
