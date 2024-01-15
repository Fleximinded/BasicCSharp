using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.CLI.Models
{
    public class EmployeeList
    {
        public EmployeeList() { }
        public List<EmployeeItem> List { get; private set; } = new List<EmployeeItem>();

        public List<EmployeeItem> Find(string data) {
            List<EmployeeItem> list = new List<EmployeeItem>();
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
    }
}
