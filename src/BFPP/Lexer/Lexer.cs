using System;
using System.Collections.Generic;

namespace BFPP.Lexer
{
    public class Lexer
    {
        private string code;
        private int position;
        private List<Instruction> result;

        private int currentJumpPosition = 1;

        public List<Instruction> Scan(string source)
        {
            code = source;
            position = 0;
            result = new List<Instruction>();

            while (position < code.Length)
            {
                if (Instruction.InstructionTypes.ContainsKey((char)peekChar()))
                {
                    Instruction instruction = new Instruction(Instruction.InstructionTypes[(char)readChar()]);
                    if (instruction.InstructionType == InstructionType.BeginPointerLoop || instruction.InstructionType == InstructionType.BeginStackLoop)
                        instruction.JumpPosition = ++currentJumpPosition;
                    if (instruction.InstructionType == InstructionType.EndPointerLoop || instruction.InstructionType == InstructionType.EndStackLoop)
                        instruction.JumpPosition = currentJumpPosition--;
                    result.Add(instruction);
                }
            }

            return result;
        }

        private int peekChar(int n = 0)
        {
            return position + n < code.Length ? code[position + n] : -1;
        }
        private int readChar()
        {
            return position < code.Length ? code[position++] : -1;
        }
    }
}

