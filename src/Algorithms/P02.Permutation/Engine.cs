namespace P02.Permutation
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Engine
    {
        public Engine()
        {
            this.NumbersInFactoriel = new List<int>();
            this.Permutations = new StringBuilder();
        }

        private List<int> NumbersInFactoriel { get; set; }

        private StringBuilder Permutations { get; set; }

        public void Run()
        {
            Console.Write("Please enter a number: ");
            int number = int.Parse(Console.ReadLine());

            this.Generate(number);
        }

        private void Generate(int number)
        {
            this.FillArray(number);
            int factorial = this.CalculateFactorial(number);      

            this.RecursiveGenerator(number);
            string recursiveResult = this.Permutations.ToString().Trim();

            this.Clear();
            this.FillArray(number);

            this.NotRecursiveGenerator(number);
            string notRecursiveResult = this.Permutations.ToString().Trim();

            this.Print(number, factorial, recursiveResult, notRecursiveResult);

            this.Clear();
        }

        private void RecursiveGenerator(int number)
        {
            if (number == 1)
            {
                string permutation = String.Join(" ", this.NumbersInFactoriel);

                this.Permutations.AppendLine(permutation);
                return;
            }

            for (int index = 0; index < number - 1; index++)
            {
                this.RecursiveGenerator(number - 1);

                int indexOfOne = number % 2 == 0 ? index : 0;

                this.Swap(indexOfOne, number - 1);
            }

            this.RecursiveGenerator(number - 1);      
        }

        private void NotRecursiveGenerator(int number)
        {
            
        }

        private void Swap(int indexOfOne, int indexOfNextNumber)
        {
            int tempOneNumber = this.NumbersInFactoriel[indexOfOne];
            this.NumbersInFactoriel[indexOfOne] = this.NumbersInFactoriel[indexOfNextNumber];
            this.NumbersInFactoriel[indexOfNextNumber] = tempOneNumber;
        }

        private int CalculateFactorial(int number)
        {
            int factorial = 1;

            for (int index = 1; index <= number; index++)
            {
                factorial *= index;
            }

            return factorial;
        }

        private void Clear()
        {
            this.Permutations.Clear();
            this.NumbersInFactoriel.Clear();
        }

        private void FillArray(int number)
        {
            for (int index = 1; index <= number; index++)
            {
                this.NumbersInFactoriel.Add(index);
            }
        }

        private void Print(int number, int factorial, string recursiveResult, string notRecursiveResult)
        {
            char separatorSymbol = '-';
            int countOfPrintSeparatorSymbol = 50;

            string separatorLine = new string(separatorSymbol, countOfPrintSeparatorSymbol);

            Console.WriteLine(separatorLine);
            Console.WriteLine($"!{number} = {factorial}");

            Console.WriteLine(separatorLine);
            Console.WriteLine($"Recursive Result: {Environment.NewLine}{recursiveResult}");
            Console.WriteLine(separatorLine);

            Console.WriteLine($"Not Recursive Result: {Environment.NewLine}{notRecursiveResult}");
            Console.WriteLine(separatorLine);
        }
    }
}
