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

### Cells
As it said in the description, a cell is a 32 bit integer and BF++
has an array of cells that are used by the program. The cell pointer
is the index in this array that is used by instructions to modify or
read from the current cell.

Each cell starts with an initial value of 0. Take the following program:
```
i.
```

The code starts with an i to set it to integer mode, so it will print the
literal number value. The main program is just a single print ```.```
instruction that prints the value of the cell at index 0, the initial
pointer. Now let's modify the cell:
```
i+++.
```

This increments the initial cell one time with each ```+``` instruction, for
a total of three, before printing that number to the screen. Take the following:
```
i+++.--.++++.
```

This program prints ```315``` to the screen as it manipulates the initial
cell using ```+``` and ```-``` to increment and decrement the cell.

Now there are plenty of cells to use, and to access all of them requires the
use of ```>``` and ```<```, to increment and decrement the cell pointer to
move around in the array. Take this code:
```
i+++.>++.<.>.
```

This code increments cells[0] (initial cell) three times and prints, increments
cell[1] twice and prints, prints cell[0], and prints cell[1].

## Loops
BF++ has two types of while loop, a pointer loop and a stack loop. Both execute
their code body until either the pointer or the top of stack is equal to 0. Both
of these loops operate in the same way with the instructions ```[```, ```]```, ```(```, ```)```.
Here is an example of a pointer loop with square brackets:
```
i+++++[-.]
```

This code prints ```43210```, it starts with ```+++++```, counting to five in
the initial cell. Then the opening square bracket begins the while loop, which
subtracts one from the initial cell and prints it. Once the cell value reaches
0, the while loop ceases to execute and the program terminates.

Stack based loops are similar, here is the same program with a curly brace stack
loop:
```
i+++++}({-}.)
```

The program increments the cell to five, and pushes that number to the top of
the stack. From there the loop begins, it pops the value off the top of the
stack, subtracts it, pushes it back onto the stack, and then prints it to the screen.
