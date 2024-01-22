using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Interfaces.Contracts
{
    public interface IPerson
    {
        public string FirstName { get;  } 
        public string LastName { get;  } 
        public DateTime? BirthDate { get;  }
        public string Print();
    }
}
