

namespace Syntra.Cli.Ext
{
    public interface ICliCommand
    {
        string Command { get; }
        List<ICliCommandParameter> Parameters { get; }
        ICliCommandParameter? FindOption(string parameterName,bool useCase=false);
        string RawCommand { get; }
    }
}