using System;
using System.Collections.Generic;
using System.Linq;

namespace P14.SwapTwoElements
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Console.WriteLine("List: " + String.Join(", ", linkedList));

            LinkedListNode<int> firstNode = linkedList.First;
            LinkedListNode<int> secondNode = firstNode.Next;

            Swap(firstNode, secondNode);

           Console.WriteLine("After Swap: " + String.Join(", ", linkedList));
        }

        private static void Swap(LinkedListNode<int> firstNode, LinkedListNode<int> secondNode)
        {
            int temp = firstNode.Value;

            firstNode.Value = secondNode.Value;
            secondNode.Value = temp;
        }
    }
}
