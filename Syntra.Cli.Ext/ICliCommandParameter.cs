namespace Syntra.Cli.Ext
{
    public interface ICliCommandParameter
    {
        bool HasOption { get; }
        bool HasValue { get; }
        string Option { get; set; }
        string Value { get; set; }
    }
}