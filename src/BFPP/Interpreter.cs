using System;
using System.Collections;
using System.Collections.Generic;

using BFPP.Lexer;

namespace BFPP
{
    public class Interpreter
    {
        private int[] cells = new int[0xFFF];
        private int pointer = 0;
        private Stack<int> stack = new Stack<int>();
        private bool charMode = true;

        public void Execute(List<Instruction> instructions)
        {
            for (int position = 0; position < instructions.Count; position++)
            {
                int jumpPosition = 0;
                switch (instructions[position].InstructionType)
                {
                    case InstructionType.IncrementPointer:
                        pointer++;
                        break;
                    case InstructionType.DecrementPointer:
                        pointer--;
                        break;
                    case InstructionType.IncrementCell:
                        cells[pointer]++;
                        break;
                    case InstructionType.DecrementCell:
                        cells[pointer]--;
                        break;
                    case InstructionType.DoubleCell:
                        cells[pointer] *= 2;
                        break;
                    case InstructionType.HalveCell:
                        cells[pointer] /= 2;
                        break;
                    case InstructionType.PushCell:
                        stack.Push(cells[pointer]);
                        break;
                    case InstructionType.PopCell:
                        cells[pointer] = stack.Pop();
                        break;
                    case InstructionType.BeginPointerLoop:
                        jumpPosition = instructions[position].JumpPosition;
                        if (cells[pointer] == 0)
                            while (instructions[++position].JumpPosition != jumpPosition)
                                ;
                        break;
                    case InstructionType.EndPointerLoop:
                        jumpPosition = instructions[position].JumpPosition;
                        if (cells[pointer] != 0)
                            while (instructions[--position].JumpPosition != jumpPosition)
                                ;
                        break;
                    case InstructionType.BeginStackLoop:
                        jumpPosition = instructions[position].JumpPosition;
                        if (stack.Peek() == 0)
                            while (instructions[++position].JumpPosition != jumpPosition)
                                ;
                        break;
                    case InstructionType.EndStackLoop:
                        jumpPosition = instructions[position].JumpPosition;
                        if (stack.Peek() != 0)
                            while (instructions[--position].JumpPosition != jumpPosition)
                                ;
                        break;
                    case InstructionType.SetPointerToCell:
                        pointer = cells[pointer];
                        break;
                    case InstructionType.SetCellToPointer:
                        cells[pointer] = pointer;
                        break;
                    case InstructionType.DuplicateStack:
                        stack.Push(stack.Peek());
                        break;
                    case InstructionType.SwapStack:
                        int one = stack.Pop();
                        int two = stack.Pop();
                        stack.Push(one);
                        stack.Push(two);
                        break;
                    case InstructionType.Print:
                        if (charMode)
                            Console.Write(Convert.ToChar(cells[pointer]));
                        else
                            Console.Write(cells[pointer]);
                        break;
                    case InstructionType.Read:
                        cells[pointer] = Console.Read();
                        break;
                    case InstructionType.SetCharMode:
                        charMode = true;
                        break;
                    case InstructionType.SetIntMode:
                        charMode = false;
                        break;
                }
            }
        }
    }
}