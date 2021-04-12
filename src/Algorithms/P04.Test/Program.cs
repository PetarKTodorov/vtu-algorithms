namespace P04.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var linkedList = new LinkedList<int>();

            FillLinkedList(linkedList);

            int intMinPositiveNumber = int.MaxValue;
            int intMaxNegativeNumber = int.MinValue;

            var node = linkedList.First;
            while (node != linkedList.Last)
            {
                if (node.Value > 0)
                {
                    intMinPositiveNumber = Math.Min(node.Value, intMinPositiveNumber);
                } 
                else
                {
                    intMaxNegativeNumber = Math.Max(node.Value, intMaxNegativeNumber);
                }

                node = node.Next;
            }

            int average = (int)Math.Round((intMinPositiveNumber + intMaxNegativeNumber) / 2d);

            Console.WriteLine($"Original LinkedList: {String.Join(", ", linkedList)}");
            Console.WriteLine($"Min positive number: {intMinPositiveNumber}");
            Console.WriteLine($"Max negative number: {intMaxNegativeNumber}");
            Console.WriteLine($"Rounded Average: {average}");

            RemoveElementsSmallerThanNumber(linkedList, average);

            Console.WriteLine($"LinkedList: {String.Join(", ", linkedList)}");

        }

        private static void FillLinkedList(LinkedList<int> linkedList)
        {
            int input;
            while ((input = int.Parse(Console.ReadLine())) != 0)
            {
                linkedList.AddLast(input);
            }
        }

        private static void RemoveElementsSmallerThanNumber(LinkedList<int> linkedList, int averageNumber)
        {
            var currentNode = linkedList.First;
            while (currentNode != null)
            {
                var nextNode = currentNode.Next;

                if (currentNode.Value < averageNumber)
                {
                    linkedList.Remove(currentNode);
                }

                currentNode = nextNode;
            }
        }

    }
}
