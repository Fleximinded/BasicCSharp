using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.Cli.Ext
{
    public interface ICliExecutable
    {
        string Name { get; }    
        string Description { get; }
        bool Execute(ICliRuntime owner,ICliCommand command);
    }
}
