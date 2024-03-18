using Syntra.Cli.Ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.Cli.Runtime
{
    public class CliCommand : ICliCommand
    {
        public static string OptionSeperator { get; set; } = "--";
        public string Command { get; protected set; } = "";
        public List<ICliCommandParameter> Parameters { get; private set; } = [];

        public string RawCommand { get; protected set; } = "";
        protected CliCommand() { }
        public static CliCommand Parse(string? command)
        {
            CliCommand cmd = new();
            if(!string.IsNullOrEmpty(command))
            {
                cmd.RawCommand = command;
                string[] cmdParts = command.Split(' ');
                if(cmdParts.Length > 0)
                {
                    cmd.Command = cmdParts[0].ToLower();
                    for(int i = 1; i < cmdParts.Length; i++)
                    {
                        CliCommandParameter parameter = new CliCommandParameter();
                        if(cmdParts[i].StartsWith(OptionSeperator))
                        {
                            parameter.Option = cmdParts[i];
                            if(i + 1 < cmdParts.Length && cmdParts[i + 1].StartsWith(OptionSeperator) == false)
                            {
                                parameter.Value = cmdParts[i + 1];
                                i++;
                            }

                        }
                        else
                        {
                            parameter.Value += cmdParts[i];
                        }
                        if(parameter.HasValue || parameter.HasOption)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                }
            }
            return cmd;
        }

        public ICliCommandParameter? FindOption(string optionName, bool useCase = false)
            => Parameters.Where(p => !useCase ? p.Option.ToLower() == optionName.ToLower() : p.Option == optionName).FirstOrDefault();
        
    }
}
