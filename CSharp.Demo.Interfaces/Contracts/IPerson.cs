using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Interfaces.Contracts
{
    public interface IPerson
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public DateTime? BirthDate { get; set; }
        public string Print();
    }
}
