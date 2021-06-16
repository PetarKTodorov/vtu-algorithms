using System;
using System.Collections.Generic;

namespace P13.MergeCollections
{
    public class StartUp
    {
        public static void Main()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            LinkedList<int> linkedList1 = new LinkedList<int>();
            LinkedList<int> linkedList2 = new LinkedList<int>();

            for (int number = 1; number <= 8; number++)
            {
                if (number <= 3)
                {
                    linkedList1.AddLast(number);
                }
                else
                {
                    linkedList2.AddLast(number);
                }
            }

            if (linkedList1.Count > linkedList2.Count)
            {
                linkedList = MergeLinkedLists(linkedList1, linkedList2);
            }
            else
            {
                linkedList = MergeLinkedLists(linkedList2, linkedList1);
            }

            Console.WriteLine("Result: " + String.Join(", ", linkedList));
        }

        private static LinkedList<int> MergeLinkedLists(LinkedList<int> bigLinkedList, LinkedList<int> smallLinkedList)
        {
            LinkedList<int> newLinkedList = new LinkedList<int>();

            LinkedListNode<int> smallLinkedListNode = smallLinkedList.First;
            LinkedListNode<int> bigLinkedListNode = bigLinkedList.First;

            while (smallLinkedListNode != null)
            {
                newLinkedList.AddLast(smallLinkedListNode.Value);
                newLinkedList.AddLast(bigLinkedListNode.Value);

                smallLinkedListNode = smallLinkedListNode.Next;
                bigLinkedListNode = bigLinkedListNode.Next;
            }

            while (bigLinkedListNode != null)
            {
                newLinkedList.AddLast(bigLinkedListNode.Value);

                bigLinkedListNode = bigLinkedListNode.Next;
            }

            return newLinkedList;
        }

    }
}
