using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Inheritance
{
    public class Teacher :Person
    {
        public Teacher()        {                    }
        public Teacher(string firstnm, string lastnm, string[] topics)
        {
            FirstName = firstnm;
            LastName = lastnm;
            Topics.AddRange(topics);
        }
        public List<string> Topics { get; set; } = new List<string>();

        public new string EarlyBindingPrint()
        {
            string topic = $"{base.EarlyBindingPrint()} Geeft volgende vakken:";
            string sep = string.Empty;
            foreach(var item in Topics)
            {
                topic += $"{sep}{item}";
                sep = " ,";
            }
            return topic;
        }
        public override string RealPrint() => $"Ik ben een leerkracht met volgende informatie: {Environment.NewLine} {EarlyBindingPrint()}";
       
    }
}
