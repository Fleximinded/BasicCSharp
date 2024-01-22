using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Employee.CLI.Models
{
    public class EmployeeItem :Person
    {
        public EmployeeItem()
        {
            
        }
        public bool IsInService
        {
            get => OutService == null; 
            set { 
                if(value==false) {
                    OutService = DateTime.Now;
                } 
            }
        }   
        public DateTime InService { get; set; }= DateTime.Now;
        public DateTime? OutService { get; set; } = null;
        public override string ToString()
        {
            string outPut= $"{base.ToString()} {Environment.NewLine} In Service from : {InService.ToShortDateString()}";
            if(!IsInService) outPut += $" and left the company on {OutService?.ToShortDateString() ?? ""}";
            return outPut;
        }
    }
  
}
