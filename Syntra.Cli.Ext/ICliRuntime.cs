namespace Syntra.Cli.Ext
{
    public interface ICliRuntime
    {
        string Cursor { get; set; }

        void Exit();
    }
}