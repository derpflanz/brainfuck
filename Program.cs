using System;

namespace Brainfuck
{
    class Program
    {
        static void Main(string[] args)
        {
            Processors processors = new Processors();
            Memory memory = new Memory();
            IOutput output = new MemoryOutput();
            IInput input = new MemoryInput("ABCD");
            Machine machine = new Machine() {
                Memory = memory,
                Processors = processors,
                Output = output,
                Input = input
            };
            machine.Run(new Tape(",.,.,.,."));

            Console.WriteLine("\n\nDone.");
        }
    }
}
