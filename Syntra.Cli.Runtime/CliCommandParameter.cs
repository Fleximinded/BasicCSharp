using Syntra.Cli.Ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.Cli.Runtime
{
    public class CliCommandParameter : ICliCommandParameter
    {
        public CliCommandParameter() { }
        public CliCommandParameter(string option, string value)
        {
            Option = option;
            Value = value;
        }
        public string Option { get; set; } = "";
        public string Value { get; set; } = "";
        public bool HasOption => string.IsNullOrWhiteSpace(Option) == false;
        public bool HasValue => string.IsNullOrWhiteSpace(Value) == false;
    }
}
