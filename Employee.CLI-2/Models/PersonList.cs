using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Employee.CLI.Models
{
    public class PersonList
    {
        public enum PersonType {Employee,Client, All };
        public PersonList() { }
        public List<Person> List { get; private set; } = new List<Person>();
        public List<Person> Show(PersonType who=PersonType.All) {
            List<Person> list = new List<Person>();
            foreach(var item in List)
            {
                if(item is EmployeeItem && (who == PersonType.Employee || who == PersonType.All))
                {
                    list.Add(item);
                }
                if(item is ClientItem && (who == PersonType.Client || who == PersonType.All))
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public List<Person> Find(string data) {
            List<Person> list = new List<Person>();
            foreach(var item in List) {
                if((item.FirstName.Contains(data, StringComparison.CurrentCultureIgnoreCase)) ||
                    (item.LastName.Contains(data, StringComparison.CurrentCultureIgnoreCase)) ||
                    (item.SocialID.Contains(data, StringComparison.CurrentCultureIgnoreCase)))
                {
                    list.Add(item);
                }
                else {
                    foreach(var contact in item.Contacts) {
                        if(contact.Address.Contains(data, StringComparison.CurrentCultureIgnoreCase)){
                            list.Add(item);
                        }
                    }

                }
            }
            return list;
        }
        public string[] SendMessage(string sendMsg, string? title=null)
        {
            List<string> result = new List<string>();
            foreach(var contact in List)
            {
                result.Add(contact.SendMessage(sendMsg, title));
            }
            return result.ToArray();
        }
    }
}
