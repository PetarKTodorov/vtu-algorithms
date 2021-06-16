using System;
using System.Collections.Generic;

namespace P15.FillStack
{
    public class StartUp
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>();

            Console.WriteLine("Enter \"end\" to finish the program.");

            Console.Write("Enter a number or type \"end\": ");
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                Console.Write("Enter a number or type \"end\": ");
                int number = int.Parse(input);

                stack.Push(number);
            }

            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
