using System;
using System.IO;

using BFPP.Lexer;

namespace BFPP
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Lexer.Lexer lexer = new Lexer.Lexer();
            Interpreter interpreter = new Interpreter();

            if (args.Length > 0)
                interpreter.Execute(lexer.Scan(File.ReadAllText(args[0])));
            else
                while (true)
                    interpreter.Execute(lexer.Scan(Console.ReadLine()));
        }
    }
}
