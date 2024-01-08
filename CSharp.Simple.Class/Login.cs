using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Simple.Class
{
    static public class Login
    {
        public static string Name { get; set; } = string.Empty;
        public static bool IsValidated { get; private set; } = false;
        public static bool Logon(string pwd)
        {
            IsValidated = Name.Length > 2 && pwd?.Length > 5 && pwd?.Contains('s') == true;
            return IsValidated;
        }
    }
}
