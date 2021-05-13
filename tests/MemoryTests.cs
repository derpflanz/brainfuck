using Xunit;
using System;

namespace Brainfuck.tests
{
    public class MemoryTests
    {
        [Fact]
        public void Value_ShouldReturnValueUnderPointer()
        {
            // arrange
            var memory = new Memory();

            // assert
            Assert.Equal(0, memory.Value);
        }

        [Fact]
        public void Value_SetShouldSetValue() 
        {
            var memory = new Memory();

            memory.Value = 0xbf;

            Assert.Equal(0xbf, memory.Value);
        }

        [Fact]
        public void ShowState_ShouldReturnState() 
        {
            // arrange
            var memory = new Memory();

            // act
            var state = memory.GetState();

            // assert
            Assert.Equal("ptr=0, contents=00 00 00 00 00 00 00 00", state);
        }

        [Fact]
        public void Increment_ShouldIncreaseValue()
        {
            // arrange
            var memory = new Memory();

            // act
            memory.Increment();

            // assert
            Assert.Equal(1, memory.Value);
        }

        [Fact]
        public void Decrement_ShouldDecreaseValue()
        {
            // arrange
            var memory = new Memory();

            // act
            memory.Decrement();

            // assert
            Assert.Equal(255, memory.Value);
        }

        [Fact]
        public void IncreasePointer_ShouldIncreasePointer()
        {
            // arrange
            var memory = new Memory();

            // act
            memory.IncreasePointer();

            // assert
            Assert.Equal(1, memory.Pointer);
        }
        [Fact]
        public void DecreasePointer_ShouldDecreasePointer()
        {
            // arrange
            var memory = new Memory();

            // act
            memory.IncreasePointer();
            memory.DecreasePointer();

            // assert
            Assert.Equal(0, memory.Pointer);
        }

        [Fact]
        public void DecreasePointer_ShouldRaiseWhenGoingUnderZero()
        {
            // arrange
            var memory = new Memory();

            // act + assert
            Assert.Throws<IndexOutOfRangeException>(() => memory.DecreasePointer());
        }
    }
}