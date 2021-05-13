using Xunit;
using NSubstitute;

namespace Brainfuck.tests
{
    public class ProcessorsTests
    {
        IMemory _memory;
        IProcessors _processors;
        IOutput _output;

        public ProcessorsTests() 
        {
            _processors = new Processors();
            _memory = Substitute.For<IMemory>();
            _output = Substitute.For<IOutput>();
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
        public void Output_ShouldPutValueToOutput() 
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
    }    
}