using Syntra.Cli.Runtime;

namespace Cli.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ParseRawCommandTest()
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
    }
}