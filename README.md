# BrainFuck++
Esoteric Programming Language that Expands on BrainFuck

## Description
BrainFuck++ (or BF++) is an esoteric programming language that
builds and expands on the programming language BrainFuck. All
programs that run in BrainFuck are compatable with BF++ and will
continue to run as normal. The expansions are mainly focused
around the addition of the stack to the language, which allows
for more flexible development and possibilities. In addition,
the instructions, double cell, halve cell, set pointer to cell,
set cell to pointer, set character mode, and set integer mode
have been incorporated.

## So how does this all work?
In both BrainFuck and BF++, the interpreter includes memory
in the form of an array of cells. Each cell is a 32-bit integer
and there are 0xFFF cells, although future functionality will
include expandable memory. The interpreter has a 32-bit integer
which points towards the current cell in memory being used by
the program. Now in BF++, there is also a Stack<Int32>, the
stack which gets used by many of the instructions in BF++.

## Breakdown of Instructions

Instruction Token     |    Source    |    Description                           |
-----------------     |    ------    |    ------------------------------------  |
Increment Pointer     |    ```>```   |    Increments the cell pointer.           |
Decrement Pointer     |    ```<```   |    Decrements the cell pointer.           |
Increment Cell        |    ```+```   |    Increments the value of the current cell. |
Decrement Cell        |    ```-```   |    Decrements the value of the current cell. |
Double Cell           |    ```*```   |    Doubles the value of the current cell. |
Halve Cell            |    ```/```   |    Divides the value of the current cell by two. |
Push Cell             |    ```}```   |    Pushes the value of the current cell to the top of the stack. |
Pop Cell              |    ```{```   |    Pops the value on top of the stack into the current cell. |
Begin Pointer Loop    |    ```[```   |    Starts a while loop, that continues until the value at the current cell pointer is 0. |
End Pointer Loop      |    ```]```   |    Ends a while loop, that will go back to the start unless the value at the current cell pointer is 0. |
Begin Stack Loop      |    ```(```   |    Starts a while loop, that continues until the value at the top of the stack is 0. |
End Stack Loop        |    ```)```   |    Ends a while loop, that will go back to the start unless the value at the top of the stack is 0.
Set Pointer to Cell Value  |   ```&```   |   Sets the cell pointer to the value of the cell at the cell pointer.   |
Set Cell to Pointer Value  |   ```|```   |   Sets the value of the cell at the call pointer to the cell pointer.   |
Duplicate Stack.      |    ```:```   |    Pushes the value at the top of the stack to the top of the stack. Same as ```{}}```   |
Swap Stack            |    ```;```   |    Swaps the top two values of the stack.   |
Print.                |    ```.```   |    Writes to stdout the value of the cell at the cell pointer.  |
Read.                 |    ```,```   |    Reads a single char from stdin and writes this value to to the cell at the cell pointer.  |
Turn Char Mode On     |    ```c```   |    Turns on character mode, so that the print instruction writes the value of the current cell as an ASCII character.
Turn Integer Mode On  |    ```i```   |    Turns on integer mode, so that the print instruction writes the value of the current cell literally.
