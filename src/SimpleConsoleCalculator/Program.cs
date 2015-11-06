using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace SimpleConsoleCalculator
{
    public class Program
    {
        public void Main(string[] args)
        {
            int counter = 0;
            Parse parse = new Parse();
            Evaluate eval = new Evaluate();
            Stack stack = new Stack();

            Console.Write("[{0}]>", counter);
            string input = Console.ReadLine();
            
            while(true)
            {
                if (input.ToLower() == "exit" || input.ToLower() == "quit")
                    break;

                try
                {
                    if (input.Contains('='))
                    {
                        parse.ExtractConstant(input);
                        stack.SaveConstant(parse.ConstantKey, parse.ConstantValue);
                    }
                    else
                    {
                        parse.ExtractValues(input);
                        eval.Calculate(parse.Int1, parse.Int2);
                    }
                }
                catch (System.ArgumentException)
                {
                    Console.WriteLine("Input entered in wrong format");
                }

                counter++;
                Console.Write("[{0}]>", counter);
                input = Console.ReadLine();
            }
            
            Console.WriteLine("Exiting program...");
            System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2)).Wait();
        }
    }
}
