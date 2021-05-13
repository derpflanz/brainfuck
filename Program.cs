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
            Machine machine = new Machine() {
                Memory = memory,
                Processors = processors,
                Output = output
            };
            //machine.Run(new Tape("++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>."));
            machine.Run(new Tape("++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>."));

//            machine.Run(new Tape("+++.[>+++++>++++++<<-].>.>.>."));
        }
    }
}
