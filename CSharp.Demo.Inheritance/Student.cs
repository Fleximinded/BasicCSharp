﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Inheritance
{
    public class Student : Person
    {
        public Student() { }
        public Student(string firstName, string lastName,Dictionary<string,double> points)
        {
            FirstName = firstName;
            LastName = lastName;
            Results = points;
        }
        public Dictionary<string, double> Results { get; set; } = new();

        public new string ShowProperties()
        {
            string results = base.ShowProperties();
            foreach(var item in Results)
            {
                results += $" Vak {item.Key} = {item.Value.ToString()} / 10";
            }
            return results;            
        }


        public override string ToString()
        {
            string results = base.ToString();  
            foreach(var item in Results)
            {
                results += $" Vak {item.Key} = {item.Value.ToString()} / 10";
            }
            return results;
        }
    }
}
