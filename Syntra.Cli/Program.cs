using Syntra.Cli.Runtime;
using Syntra.MyProject.Lib;

namespace Syntra.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CliRuntime cliRuntime = new CliRuntime();
            cliRuntime.AddExecutor(new GreekAccents());
            cliRuntime.Execute();
        }
    }
}
