using Xunit;

namespace Brainfuck.tests
{
    public class MemoryOutputTests
    {
        [Fact]
        public void ToString_ShouldGiveHumanReadableString()
        {
            var memoryOutput = new MemoryOutput();

            memoryOutput.Write(0x41);

            Assert.Equal("A", memoryOutput.ToString());
        }
    }
}

