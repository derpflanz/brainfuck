using System;

namespace Brainfuck
{
    public interface IMemory
    {
        void Increment();
        void Decrement();
        void IncreasePointer();
        void DecreasePointer();
        byte Value { get; set; }
        string GetState();
    }

    public class Memory: IMemory 
    {
        public int Pointer {
            get ;
            private set;
        }
        private byte[] _memory;
        public byte Value {
            get {
                return _memory[Pointer];
            }
            set {

            }
        }
        public Memory()
        {
            _memory = new byte[1024];
            Pointer = 0;
        }
        public void Increment()
        {
            _memory[Pointer]++;
        }
        public void Decrement() 
        {
            _memory[Pointer]--;
        }
        public void IncreasePointer() 
        {
            Pointer++;
        }
        public void DecreasePointer()
        {
            if (Pointer == 0) 
            {
                throw new IndexOutOfRangeException("Cannot decrease when 0.");
            }
            Pointer--;
        }
        public string GetState()
        {
            string s = $"ptr={Pointer}, contents=";

            for (int i = 0; i <= 7; i++) 
            {
                s += $"{_memory[i]:x2} ";
            }

            return s.Trim();
        }
    }
}