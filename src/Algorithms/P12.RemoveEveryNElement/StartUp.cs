namespace P12.RemoveEveryNElement
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            for (int number = 1; number <= 10; number++)
            {
                linkedList.AddLast(number);
            }

            Console.WriteLine("List: " + String.Join(", ", linkedList));


            Console.Write("Enter a n to delete: ");
            int n = int.Parse(Console.ReadLine());

            LinkedListNode<int> node = linkedList.First;
            int count = 1;

            while (node != null)
            {
                LinkedListNode<int> nextNode = node.Next;

                if (count == n)
                {
                    linkedList.Remove(node);
                    count = 0;
                }

                count++;
                node = nextNode;
            }

            Console.WriteLine("Result: " + String.Join(", ", linkedList));
        }
    }
}
