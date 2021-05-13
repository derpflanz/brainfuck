using Xunit;
using System;

namespace Brainfuck.tests 
{
    public class StatementTests
    {
        [Fact]
        public void Constructor_ShouldThrowOnInvalidStatement()
        {
            // assert
            Assert.Throws<ArgumentException>(() => new Statement('A'));
        }

        [Fact]
        public void Constructor_ShouldGenerateIncreasePointerStatement()
        {
            // arrange + act
            var statement = new Statement('>');

            // assert
            Assert.Equal(Statement.Types.IncreasePointer, statement.Type);
        }

        [Fact]
        public void Constructor_ShouldGenerateDecreasePointerStatement()
        {
            // arrange + act
            var statement = new Statement('<');

            // assert
            Assert.Equal(Statement.Types.DecreasePointer, statement.Type);
        }

        [Fact]
        public void Constructor_ShouldGenerateWhileStatement()
        {
            // arrange + act
            var statement = new Statement('[');

            // assert
            Assert.Equal(Statement.Types.While, statement.Type);
        }

        [Fact]
        public void Constructor_ShouldGenerateEndWhileStatement()
        {
            // arrange + act
            var statement = new Statement(']');

            // assert
            Assert.Equal(Statement.Types.EndWhile, statement.Type);
        }

        [Fact]
        public void Constructor_ShouldGenerateReadStatement()
        {
            // arrange + act
            var statement = new Statement(',');

            // assert
            Assert.Equal(Statement.Types.Read, statement.Type);
        }

        [Fact]
        public void ToString_ShouldGiveHumanReadableString()
        {
            // arrange
            var statement = new Statement('+');

            // act
            var str = statement.ToString();

            // assert
            Assert.Equal("Increment", str);
        }
    } 
}