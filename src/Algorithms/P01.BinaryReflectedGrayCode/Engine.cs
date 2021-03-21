namespace P01.BinaryReflectedGrayCode
{
    using System;
    using System.Text;

    public class Engine
    {
        private const int DEFAULT_INITIAL_VALUE = 1;

        public void Run()
        {
            Console.Write("Please enter a number: ");
            int depth = int.Parse(Console.ReadLine());

            this.Generate(depth);
        }

        private void Generate(int depth)
        {
            string recursiveResult = this.RecursiveGenerator(DEFAULT_INITIAL_VALUE, string.Empty, depth);

            string notRecursiveResult = this.NotRecursiveGenerator(depth);

            this.Print(recursiveResult, notRecursiveResult);
        }

        private string RecursiveGenerator(int number, string prevValue, int limit)
        {
            bool isReachBottomOfRecursion = number > limit;
            if (isReachBottomOfRecursion)
            {
                return prevValue;
            }

            prevValue = prevValue + number + prevValue;

            number++;

            return this.RecursiveGenerator(number, prevValue, limit);
        }

        private string NotRecursiveGenerator(int limit)
        {
            string result = string.Empty;

            for (int number = DEFAULT_INITIAL_VALUE; number <= limit; number++)
            {
                result += number + result;
            }

            return result;
        }

        private void Print(string recursiveResult, string notRecursiveResult)
        {
            char separatorSymbol = '-';
            int countOfPrintSeparatorSymbol = 50;

            string separatorLine = new string(separatorSymbol, countOfPrintSeparatorSymbol);

            Console.WriteLine(separatorLine);
            Console.WriteLine($"Recursive Result: {Environment.NewLine}{recursiveResult}{Environment.NewLine}");

            Console.WriteLine($"Not Recursive Result: {Environment.NewLine}{notRecursiveResult}{Environment.NewLine}");
            Console.WriteLine(separatorLine);
        }
    }
}
