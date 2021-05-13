using System;

namespace Brainfuck
{
    public interface IInput
    {
        byte Read();
    }

    public class MemoryInput : IInput
    {
        byte[] _input;
        int Pointer;
        public MemoryInput(string input) 
        {
            _input = System.Text.Encoding.ASCII.GetBytes(input);            
        }

        public byte Read()
        {
            return _input[Pointer++];
        }
    }
}