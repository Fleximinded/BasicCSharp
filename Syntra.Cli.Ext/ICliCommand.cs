

namespace Syntra.Cli.Ext
{
    public interface ICliCommand
    {
        string Command { get; }
        List<ICliCommandParameter> Parameters { get; }
        string RawCommand { get; }
    }
}