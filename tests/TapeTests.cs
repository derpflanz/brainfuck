using Xunit;
using System;

namespace Brainfuck.tests 
{
    public class TapeTests 
    {
        [Fact]
        public void Constructor_ShouldThrowOnInvalidStatement() 
        {
            // assert
            Assert.Throws<ArgumentException>(() => new Tape("A"));
        }

        [Fact]
        public void FirstGetNext_ShouldReturnFirstStatement() 
        {
            // arrange
            Tape tape = new Tape(">");

            // act
            var s = tape.GetNext(0);

            // assert
            Assert.Equal(Statement.Types.IncreasePointer, s.Type);
        }

        [Fact]
        public void SecondGetNext_ShouldReturnSecondStatement() 
        {
            // arrange
            Tape tape = new Tape("+-");

            // act
            _ = tape.GetNext(0);
            var s = tape.GetNext(0);

            // assert
            Assert.Equal(Statement.Types.Decrement, s.Type);
        }

        [Fact]
        public void GetNext_ShouldThrowWhenNoStatementsLeft() 
        {
            // arrange
            Tape tape = new Tape("+");

            // act
            _ = tape.GetNext(0);

            // assert
            Assert.Throws<IndexOutOfRangeException>(() => tape.GetNext(0));
        }

        [Fact]
        public void HasStatements_ReturnsFalseOnEmptyTape() 
        {
            // arrange
            Tape tape = new Tape("");

            // act
            var b = tape.HasStatements();

            // assert
            Assert.False(b);
        }

        [Fact]
        public void HasStatements_ReturnsTrueOnNonEmptyTape() 
        {
            // arrange
            Tape tape = new Tape(">>");

            // act
            var b = tape.HasStatements();

            // assert
            Assert.True(b);
        }

        [Fact]
        public void GetNext_ReturnsNextAfterWhileWhenValueIsZero()
        {
            // arrange
            Tape tape = new Tape("[----].");

            // act
            var statement = tape.GetNext(0);

            // assert
            Assert.Equal(Statement.Types.Write, statement.Type);
        }

        [Fact]
        public void GetNext_ReturnsNextInsideWhileWhenValueIsOne() 
        {
            // arrange
            Tape tape = new Tape("[----].");

            // act
            var statement = tape.GetNext(1);

            // assert
            Assert.Equal(Statement.Types.Decrement, statement.Type);
        }

        [Fact]
        public void GetNext_ReturnsFirstOfLoopWhenValueIsNonZeroAtEnd() 
        {
            // arrange
            Tape tape = new Tape("[-].");

            // act
            var statement = tape.GetNext(1);
            Assert.Equal(Statement.Types.Decrement, statement.Type);
 
            statement = tape.GetNext(3);

            Assert.Equal(Statement.Types.Decrement, statement.Type);
        }
 
         [Fact]
        public void GetNext_ReturnsFirstAfterLoopWhenValueIsZeroAtEnd() 
        {
            // arrange
            Tape tape = new Tape("[-].");

            // act
            var statement = tape.GetNext(1);
            Assert.Equal(Statement.Types.Decrement, statement.Type);
 
            statement = tape.GetNext(0);

            Assert.Equal(Statement.Types.Write, statement.Type);
        }

    }
}