using Xunit;
using NSubstitute;

namespace Brainfuck.tests
{
    public class MachineTests
    {
        [Fact]
        public void Run_ShouldGetProcessorForStatement() 
        {
            // arrange
            var processors = Substitute.For<IProcessors>();
            var machine = new Machine() {
                Processors = processors
            };
            var statement = new Statement('+');

            // act
            machine.Run(statement);

            // assert
            processors.Received().GetProcessor(statement);
        }

        [Fact]
        public void Run_ShouldCallMemoryOnMemoryProcessor() 
        {
            // arrange
            var processors = Substitute.For<IProcessors>();
            var processor = Substitute.For<IMemoryProcessor>();
            processors.GetProcessor(Arg.Any<Statement>()).Returns(processor);

            var memory = Substitute.For<IMemory>();
            var machine = new Machine() {
                Processors = processors,
                Memory = memory
            };
            var statement = new Statement('+');

            // act
            machine.Run(statement);

            // assert
            processor.Received().Process(memory);
        }

                [Fact]
        public void Run_ShouldCallOutputOnOutputProcessor() 
        {
            // arrange
            var processors = Substitute.For<IProcessors>();
            var processor = Substitute.For<IOutputProcessor>();
            var output = Substitute.For<IOutput>();
            processors.GetProcessor(Arg.Any<Statement>()).Returns(processor);

            var memory = Substitute.For<IMemory>();
            var machine = new Machine() {
                Processors = processors,
                Memory = memory,
                Output = output
            };
            var statement = new Statement('.');

            // act
            machine.Run(statement);

            // assert
            processor.Received().Process(memory, output);
        }
    }
}