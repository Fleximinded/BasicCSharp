using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.CLI.Models
{
    public class Contact
    {
        string? _name = null;
        public enum ContactType { MobilePhone, PrivatePhone, GoodOldPhone, Email, Fax }
        public string Name { get { return _name ?? Type.ToString(); } set { _name = value; } }
        public ContactType Type { get; set; } = ContactType.MobilePhone;
        public string Address { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{Name}({Type}): {Address}";
        }
    }
}
