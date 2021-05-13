using System.Linq;
using System;
using System.Collections.Generic;

namespace Brainfuck
{
    public class Tape
    {
        private int _tapePointer;
        private List<Statement> _statements;
        public Tape(string program) 
        {            
            _tapePointer = 0;
            _statements = new List<Statement>();
            foreach(char s in program) 
            {
                _statements.Add(new Statement(s));
            }
        }

        public bool HasStatements() 
        {
            bool result = true;
            try
            {
                _ = _statements[_tapePointer];
            } catch (ArgumentOutOfRangeException) 
            {
                result = false;
            }

            return result;
        }
        public Statement GetNext(byte value) 
        {
            try
            {
                ProcessWhile(value);
                ProcessEndWhile(value);
                return _statements[_tapePointer++];
            } catch (ArgumentOutOfRangeException) 
            {
                throw new IndexOutOfRangeException("End of tape reached.");
            }
        }

        private void ProcessWhile(byte value) 
        {
            if (_statements[_tapePointer].Type == Statement.Types.While)
            {
                while (value == 0 && _statements[_tapePointer].Type != Statement.Types.EndWhile) 
                {
                    _tapePointer++;
                }
                _tapePointer++;
            }
        }
        private void ProcessEndWhile(byte value) 
        {
            if (_statements[_tapePointer].Type == Statement.Types.EndWhile) 
            {
                while (value != 0 && _statements[_tapePointer].Type != Statement.Types.While) 
                {
                    _tapePointer--;
                }
                _tapePointer++;
            }
        }
    }
}