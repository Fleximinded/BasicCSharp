using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.GenericTypes
{
    public class PersonData
    {
        public PersonData() { }
        public PersonData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
