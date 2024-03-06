using Syntra.Cli.Ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.Cli.Runtime
{
    public class BasicExecution : ICliExecutable
    {
        public string Name => GetType().FullName ?? "BasicExecution";
        public string Description { get => "Basic CLI command executor"; }

        public bool Execute(ICliRuntime owner, ICliCommand parameters)
        {
            switch(parameters.Command)
            {
                case "exit":
                    owner.Exit();
                    break;
                case "cls":
                    Console.Clear();
                    break;
                default:
                    return false;



            }
            return true;
        }
    }
}
