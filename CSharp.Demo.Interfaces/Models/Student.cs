using CSharp.Demo.Interfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Interfaces.Models
{
    public class Student : IPerson
    {
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }

        public Dictionary<string, double> Results { get; set; } = new();
        public string Print()
        {
           return $"{FirstName} {LastName}";    
        }
    }
}
