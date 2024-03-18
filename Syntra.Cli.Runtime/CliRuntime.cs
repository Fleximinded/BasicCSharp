using Syntra.Cli.Ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.Cli.Runtime
{
    public class CliRuntime : ICliRuntime
    {
        public bool DoExit { get; private set; }
        public string Cursor { get; set; } = "$";
        public void Exit() { DoExit = true; }
        public Dictionary<string, ICliExecutable> Executors { get; private set; } = [];

        public CliRuntime()
        {
            AddExecutor(new BasicExecution());
        }

        public bool AddExecutor(ICliExecutable executable)
        {
            if(!Executors.ContainsKey(executable.Name))
            {
                Executors.Add(executable.Name, executable);
                return true;
            }
            return false;
        }

        public void Execute()
        {
            while(!DoExit)
            {
                Console.Write(Cursor);
                var rawCmd = Console.ReadLine();
                var command = CliCommand.Parse(rawCmd);
                foreach( var exe in Executors.Values ) {
                    if(exe.Execute(this, command))
                    {
                        break;
                    }
                
                }
            }



        }

        public static void Run(string[]? args = null)
        {
            CliRuntime runtime = new CliRuntime();
            runtime.Execute();
        }


    }
}
