using Employee.CLI.CLI;

namespace Employee.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeCommands.RunCLI(args);
        }
    }
}
