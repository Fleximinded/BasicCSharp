﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Inheritance
{
    public class Person
    {
        public string FirstName { get; set; }  =string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; } = null;

        public string EarlyBindingPrint() {
            return $"{FirstName} {LastName}";
        }
        public virtual string RealPrint() => EarlyBindingPrint();
    }
}