using System;

namespace Brainfuck
{
    public interface IOutput
    {
        void Write(byte b);
        string ToString();
    }

    public class ConsoleOutput: IOutput 
    {
        public void Write(byte b) 
        {
            Console.Write(Convert.ToChar(b));
        }

        public override string ToString() 
        {
            return "[Console already written]";
        }
    }

    public class MemoryOutput: IOutput
    {
        private byte[] _output = new byte[1024];
        private int _pointer = 0;

        public void Write(byte b) 
        {
            _output[_pointer++] = b;
        }

        public override string ToString()
        {
            return System.Text.Encoding.ASCII.GetString(_output, 0, _pointer);
        }
    }
}