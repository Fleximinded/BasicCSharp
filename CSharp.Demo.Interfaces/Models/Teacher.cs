using CSharp.Demo.Interfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Interfaces.Models
{
    public class Teacher : IPerson
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }

        public List<string> Topics { get; set; } = new List<string>();
        public string Print()
        {
            return $"Teacher is Mister {LastName}";
        }
    }
}
