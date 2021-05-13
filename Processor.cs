

namespace Brainfuck
{
    public interface IProcessor
    {
    }
    public interface IMemoryProcessor : IProcessor
    {
        void Process(IMemory memory);
    }
    public interface IOutputProcessor : IProcessor
    {
        void Process(IMemory memory, IOutput output);
    }

    public class WriteProcessor: IOutputProcessor
    {
        public void Process(IMemory memory, IOutput output)
        {
            output.Write(memory.Value);
        }
    }

    public class IncrementProcessor: IMemoryProcessor
    {
        public void Process(IMemory memory) 
        {
            memory.Increment();
        } 
    }

    public class DecrementProcessor:IMemoryProcessor
    {
        public void Process(IMemory memory) 
        {
            memory.Decrement();
        }
    }

    public class IncreasePointerProcessor: IMemoryProcessor
    {
        public void Process(IMemory memory)
        {
            memory.IncreasePointer();
        }
    }
    public class DecreasePointerProcessor: IMemoryProcessor
    {
        public void Process(IMemory memory)
        {
            memory.DecreasePointer();
        }
    }
}