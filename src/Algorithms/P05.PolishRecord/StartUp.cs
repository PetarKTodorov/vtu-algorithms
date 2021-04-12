namespace P05.ReversePolishNotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            // Example for first exercise: (9/(5-6/2)-1)*2+8/(7-3)

            Console.Write("Enter normal mathematical expression: ");
            string input = Console.ReadLine();

            string[] tokens = SplitInput(input);

            var outputQueue = new Queue<string>();

            outputQueue = GenerateReversePolishNotation(tokens);

            Console.WriteLine($"Reverse polish notation expression: {String.Join(' ', outputQueue)}");

            Console.WriteLine($"Result: {CalculateReversePolishNotation(outputQueue)}");
        }

        private static string[] SplitInput(string input)
        {
            string regexPattern = @"(([0-9]+[.]*)?[0-9]+)|\(|\)|\+|\/|\*|-";
            Regex regex = new Regex(regexPattern);

            string[] tokens = regex.Matches(input)
                .Select(x => x.ToString())
                .ToArray();

            return tokens;
        }

        private static Queue<string> GenerateReversePolishNotation(string[] symbols)
        {
            Stack<string> operatorStack = new Stack<string>();
            Queue<string> outputQueue = new Queue<string>();

            for (int index = 0; index < symbols.Length; index++)
            {
                string symbol = symbols[index];

                FillOutputQueue(operatorStack, outputQueue, symbol);
            }

            // Add last operators 
            while (operatorStack.Count != 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue;
        }

        private static void FillOutputQueue(Stack<string> operatorStack, Queue<string> outputQueue, string symbol)
        {
            if (isNumber(symbol))
            {
                outputQueue.Enqueue(symbol);
            }
            else if (symbol == "^")
            {
                operatorStack.Push(symbol);
            }
            else if (OperatorPrecedence(symbol) != -1)
            {

                while (operatorStack.Count != 0 && OperatorPrecedence(operatorStack.Peek()) >= OperatorPrecedence(symbol))
                {
                    outputQueue.Enqueue(operatorStack.Pop());
                }

                operatorStack.Push(symbol);
            }
            else if (symbol == "(")
            {
                operatorStack.Push(symbol);
            }
            else if (symbol == ")")
            {
                while (!(operatorStack.Peek() == "("))
                {
                    outputQueue.Enqueue(operatorStack.Pop());
                }

                operatorStack.Pop();
            }
        }

        private static bool isNumber(string input)
        {
            double number;

            bool isNumeric = double.TryParse(input, out number);

            return isNumeric;
        }

        private static int OperatorPrecedence(string mathOperator)
        {
            int precedence = -1;

            char mathOperatorAsChar = char.Parse(mathOperator);

            switch (mathOperatorAsChar)
            {
                case '+':
                case '-':
                    precedence = 2;
                    break;
                case '*':
                case '/':
                    precedence = 3;
                    break;
                case '^':
                    precedence = 4;
                    break;
            }

            return precedence;
        }

        private static double CalculateReversePolishNotation(Queue<string> inputQueue)
        {
            Stack<string> outputStack = new Stack<string>();

            while (inputQueue.Count != 0)
            {
                string symbol = inputQueue.Dequeue();

                if (isNumber(symbol))
                {
                    outputStack.Push(symbol);
                }
                else
                {
                    double value1 = double.Parse(outputStack.Pop());
                    double value2 = double.Parse(outputStack.Pop());
                    double result = 0.0;

                    if (symbol == "+")
                    {
                        result = AddValues(value1, value2);
                    }
                    else if (symbol == "-")
                    {
                        result = SubtractValues(value1, value2);
                    }
                    else if (symbol == "*")
                    {
                        result = MultiplyValues(value1, value2);
                    }
                    else if (symbol == "/")
                    {
                        result = DivideValues(value1, value2);
                    }
                    else if (symbol == "^")
                    {
                        result = ExponentValues(value1, value2);
                    }

                    outputStack.Push(result.ToString());
                }
            }

            double outcome = double.Parse(outputStack.Pop());

            return outcome;
        }

        private static double SubtractValues(double a, double b)
        {
            double difference = b - a;

            return difference;
        }

        private static double AddValues(double a, double b)
        {
            double sum = a + b;

            return sum;
        }

        private static double DivideValues(double a, double b)
        {
            double quotient = b / a;

            return quotient;
        }

        private static double MultiplyValues(double a, double b)
        {
            double product = a * b;

            return product;
        }

        private static double ExponentValues(double a, double b)
        {
            double product = Math.Pow(b, a);

            return product;
        }
    }
}
