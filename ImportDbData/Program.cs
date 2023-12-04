using ImportDbData.Domain;

namespace ImportDbData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Import File: ");
            var path = Console.ReadLine();
            Console.WriteLine("Table Name: ");
            var table = Console.ReadLine();
            Console.WriteLine("Export To: ");
            var export = Console.ReadLine();
            
            if(JsonToSql.TryImportTo(table,path,out string script)) {
                File.WriteAllText(export, script);
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }
            Console.ReadKey();
        }
    }
}
