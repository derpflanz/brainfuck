using System;
using System.Threading;

namespace Brainfuck
{
    public class Machine
    {
        public IMemory Memory { get; set; }
        public IProcessors Processors { get; set; }
        public IOutput Output { get; set; }
        public IInput Input {get; set; }
        private byte[] _input;

        private delegate void _processStatement();

        public Machine()
        {
            _input = new byte[8];            
        }

        public void Run(Tape tape)
        {
            while(tape.HasStatements()) 
            {
                var statement = tape.GetNext(Memory.Value);
                Run(statement);

                ShowState();
                Thread.Sleep(100);
            }
        }

        private void ShowState() 
        {
            Console.Write(Memory.GetState());
            Console.Write("   ");
            Console.Write(Output.ToString() + "\r");
        }

        public void Run(Statement statement)
        {
            var processor = Processors.GetProcessor(statement);
            if (processor is IMemoryProcessor)
            {
                ((IMemoryProcessor)processor).Process(Memory);
            }
            if (processor is IOutputProcessor) 
            {
                ((IOutputProcessor)processor).Process(Memory, Output);
            }
            if (processor is IInputProcessor) 
            {
                ((IInputProcessor)processor).Process(Memory, Input);
            }
        }
    }
}