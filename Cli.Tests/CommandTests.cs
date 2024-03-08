using Syntra.Cli.Runtime;

namespace Cli.Tests
{
    public class CommandTests
    {
        [Fact]
        public void ParseRawCommandTest1()
        {
            string rawCmd = @"Copy --src c:\mydir\file.txt --n --a";
            var result=CliCommand.Parse(rawCmd);
            Assert.NotNull(result);
            Assert.True(result.Command == "copy");
            Assert.True(result.Parameters.Count== 3);
            Assert.True(result.Parameters[0].Option == "--src");
            Assert.True(result.Parameters[0].Value == @"c:\mydir\file.txt");
            Assert.True(result.Parameters[1].Option == "--n");
            Assert.True(result.Parameters[2].Option == "--a");

        }
        [Fact]
        public void ParseRawCommandTest2()
        {
            string rawCmd = @"Copy c:\mydir\file.txt c:\outdir\file.txt --n --a";
            var result = CliCommand.Parse(rawCmd);
            Assert.NotNull(result);
            Assert.True(result.Command == "copy");
            Assert.True(result.Parameters.Count == 4);
            Assert.True(string.IsNullOrEmpty(result.Parameters[0].Option));
            Assert.True(result.Parameters[0].Value == @"c:\mydir\file.txt");
            Assert.True(string.IsNullOrEmpty(result.Parameters[1].Option));
            Assert.True(result.Parameters[1].Value == @"c:\outdir\file.txt");
            Assert.True(result.Parameters[2].Option == "--n");
            Assert.True(result.Parameters[3].Option == "--a");

        }
    }
}