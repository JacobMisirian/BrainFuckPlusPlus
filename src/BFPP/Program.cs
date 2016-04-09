using System;

using BFPP.Lexer;

namespace BFPP
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Lexer.Lexer lexer = new Lexer.Lexer();
            Interpreter interpreter = new Interpreter();

            while (true)
                interpreter.Execute(lexer.Scan(Console.ReadLine()));
        }
    }
}
