using System;
using System.Collections.Generic;

namespace BFPP.Lexer
{
    /// <summary>
    /// Instruction.
    /// </summary>
    public class Instruction
    {
        /// <summary>
        /// Gets or sets the jump position.
        /// </summary>
        /// <value>The jump position.</value>
        public int JumpPosition { get; set; }
        /// <summary>
        /// Gets the type of the instruction.
        /// </summary>
        /// <value>The type of the instruction.</value>
        public InstructionType InstructionType { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MM.Instruction"/> class.
        /// </summary>
        /// <param name="instructionType">Instruction type.</param>
        public Instruction(InstructionType instructionType)
        {
            JumpPosition = 0;
            InstructionType = instructionType;
        }

        public static Dictionary<char, InstructionType> InstructionTypes = new Dictionary<char, InstructionType>()
        {
            { '>', InstructionType.IncrementPointer },
            { '<', InstructionType.DecrementPointer },
            { '+', InstructionType.IncrementCell },
            { '-', InstructionType.DecrementCell },
            { '*', InstructionType.DoubleCell },
            { '/', InstructionType.HalveCell },
            { '}', InstructionType.PushCell },
            { '{', InstructionType.PopCell },
            { '[', InstructionType.BeginPointerLoop },
            { ']', InstructionType.EndPointerLoop },
            { '(', InstructionType.BeginStackLoop },
            { ')', InstructionType.EndStackLoop },
            { '&', InstructionType.SetPointerToCell },
            { '|', InstructionType.SetCellToPointer },
            { ':', InstructionType.DuplicateStack },
            { ';', InstructionType.SwapStack },
            { '.', InstructionType.Print },
            { ',', InstructionType.Read },
            { 'c', InstructionType.SetCharMode },
            { 'i', InstructionType.SetIntMode }
        };
    }

    public enum InstructionType
    {
        IncrementPointer,
        DecrementPointer,
        IncrementCell,
        DecrementCell,
        DoubleCell,
        HalveCell,
        PushCell,
        PopCell,
        BeginPointerLoop,
        EndPointerLoop,
        BeginStackLoop,
        EndStackLoop,
        SetPointerToCell,
        SetCellToPointer,
        DuplicateStack,
        SwapStack,
        Print,
        Read,
        SetCharMode,
        SetIntMode
    }
}