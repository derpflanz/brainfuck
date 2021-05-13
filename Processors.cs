using System.Collections.Generic;

namespace Brainfuck
{
    public interface IProcessors
    {
        IProcessor GetProcessor(Statement statement);
    }

    public class Processors: IProcessors
    {
        private Dictionary<Statement.Types, IProcessor> _statementProcessors = new Dictionary<Statement.Types, IProcessor>() {
            { Statement.Types.Increment, new IncrementProcessor() },
            { Statement.Types.Decrement, new DecrementProcessor() },
            { Statement.Types.IncreasePointer, new IncreasePointerProcessor() },
            { Statement.Types.DecreasePointer, new DecreasePointerProcessor() },
            { Statement.Types.Write, new WriteProcessor() },
            { Statement.Types.Read, new ReadProcessor() }

        };

        public IProcessor GetProcessor(Statement statement)
        {
            return _statementProcessors[statement.Type];
        }
    }
}