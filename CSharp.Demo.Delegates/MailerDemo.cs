using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Demo.Delegates
{
    public delegate void CustomMailMessage(string to,StringBuilder sb);   
    public class MailerDemo
    {
        public CustomMailMessage? CustomMailMessage { get; set; } = null;
        public string To { get; set; }=string.Empty;
        public MailerDemo()        {                        }
        public MailerDemo(string mailTo,CustomMailMessage? cb=null)
        {
            CustomMailMessage = cb; 
            To = mailTo;
        }
        public void Mail() {
            StringBuilder content = new StringBuilder();
            content.AppendLine($"Beste {To},");
            content.AppendLine();
            if(CustomMailMessage != null) {
                CustomMailMessage(To,content);
            }
            content.AppendLine();
            content.AppendLine("Hoogdravende groenten,");
            content.AppendLine("Den directeur");
            Console.WriteLine(content.ToString());
        }
    }
}
