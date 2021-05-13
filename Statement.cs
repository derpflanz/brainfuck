
using System.Linq;
using System;
using System.Collections.Generic;

namespace Brainfuck
{
    public class Statement
    {
        private static Dictionary<char, Types> _statement_list = new Dictionary<char, Types>() {
            { '+', Types.Increment },
            { '-', Types.Decrement },
            { '<', Types.DecreasePointer },
            { '>', Types.IncreasePointer },
            { '[', Types.While },
            { ']', Types.EndWhile },
            { '.', Types.Write },
            { ',', Types.Read }
        };

        public enum Types 
        {
            IncreasePointer, DecreasePointer, Increment, Decrement, Write, Read, While, EndWhile
        }

        public Types Type { get; private set; }

        public Statement(char statement) 
        {
            try 
            {
                Type = _statement_list[statement];
            } catch (KeyNotFoundException) 
            {
                throw new ArgumentException($"Character {statement} is not a valid Brainfuck statement.");
            }
        }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}