

using System.Text;

namespace CSharp.Demo.Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MailerDemo myDemo = new("John");
            myDemo.CustomMailMessage += MakeCustomMessage;
            myDemo.CustomMailMessage += MakePositiveMessage;
            myDemo.Mail();
            Console.WriteLine();
            Console.WriteLine("Druk een toets om te eindigen");
            Console.ReadKey();
        }

        private static void MakeCustomMessage(string to,StringBuilder sb)
        {
            sb.AppendLine($"Om besparingsredenen zal de volgende 4 maanden uw loon gehalveerd worden, maar omdat jij, {to}, zo'n fantastische werknemer bent die tot 's avonds laat op kantoor blijft zal dit zeker geen probleem zijn.");
            sb.Append(Environment.NewLine);
        }


        private static void MakePositiveMessage(string to,StringBuilder sb)
        {
            sb.AppendLine($"Omdat jij zo'n goede werknemer bent {to}, hoef je nooit meer terug te komen. Uw loon zal zonder meer doorgestort worden tot aan uw pensioen.");
        }
    }
}
;