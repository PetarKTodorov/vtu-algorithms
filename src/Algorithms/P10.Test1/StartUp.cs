namespace P10.Test1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            // добавяне на 10 и изтриване на елементите 
            var list = new List<int>();

            CreateList(list);
            PrintList(list);

            int x = -1;

            while (list.Contains(x) == false)
            {
                Console.Write("Enter a number that is contained in the list: ");
                x = int.Parse(Console.ReadLine());
            }

            list = list.Where(number => number <= x).ToList();

            int indexOfLastXElement = list.LastIndexOf(x);

            list.Insert(indexOfLastXElement + 1, 10);

            PrintList(list);
        }

        private static void CreateList(List<int> list)
        {
            var random = new Random();
            int minNumber = 1;
            int maxNumber = 100;

            for (int index = 0; index < 10; index++)
            {
                int number = random.Next(minNumber, maxNumber);

                list.Add(number);
            }
        }

        private static void PrintList(List<int> list)
        {
            string separator = ", ";
            string listAsString = String.Join(separator, list);

            Console.WriteLine(listAsString);
        }
    }
}
