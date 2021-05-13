using Xunit;

namespace Brainfuck.tests
{
    public class MemoryInputTests
    {
        [Fact]
        public void Read_ShouldGetConsecutiveAsciiBytes()
        {
            var input = new MemoryInput("Hello World!");

            // 0x48 is ASCII 'H', 0x65 is 'e'
            var b = input.Read();
            Assert.Equal(0x48, b);

            b = input.Read();
            Assert.Equal(0x65, b);
        }
    }
}

