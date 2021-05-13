using Xunit;
using NSubstitute;

namespace Brainfuck.tests
{
    public class ProcessorsTests
    {
        IMemory _memory;
        IProcessors _processors;
        IOutput _output;
        IInput _input;

        public ProcessorsTests() 
        {
            _processors = new Processors();
            _memory = Substitute.For<IMemory>();
            _output = Substitute.For<IOutput>();
            _input = Substitute.For<IInput>();
        }

        [Fact]
        public void Increment_ShouldIncrementMemory()
        {
            var statement = new Statement('+');
            var processor = _processors.GetProcessor(statement);

            // act
            ((IMemoryProcessor)processor).Process(_memory);

            // assert
            _memory.Received().Increment();
        }

        [Fact]
        public void Decrement_ShouldDecrementMemory()
        {
            var statement = new Statement('-');
            var processor = _processors.GetProcessor(statement);

            // act
            ((IMemoryProcessor)processor).Process(_memory);

            // assert
            _memory.Received().Decrement();
        }

        [Fact]
        public void Increase_ShouldIncreasePointer()
        {
            var statement = new Statement('>');
            var processor = _processors.GetProcessor(statement);

            // act
            ((IMemoryProcessor)processor).Process(_memory);

            // assert
            _memory.Received().IncreasePointer();
        }

        [Fact]
        public void Decrease_ShouldIncreasePointer()
        {
            var statement = new Statement('<');
            var processor = _processors.GetProcessor(statement);

            // act
            ((IMemoryProcessor)processor).Process(_memory);

            // assert
            _memory.Received().DecreasePointer();
        }

        [Fact]
        public void Write_ShouldReadMemoryValueToOutput() 
        {
            // arrange
            var statement = new Statement('.');
            var processor = _processors.GetProcessor(statement);

            // act
            ((IOutputProcessor)processor).Process(_memory, _output);

            // assert
            var value = _memory.Received().Value;
            _output.Received().Write(value);
        }

        [Fact]
        public void Read_ShouldStoreValueInMemory() 
        {
            // arrange
            var statement = new Statement(',');
            var processor = _processors.GetProcessor(statement);
            _input.Read().Returns<byte>(0xbf);

            // act
            ((IInputProcessor)processor).Process(_memory, _input);

            // assert
            _memory.Received().Value = 0xbf;
        }
    }    
}