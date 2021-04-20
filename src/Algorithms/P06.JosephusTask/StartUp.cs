namespace P06.JosephusTask
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Console.Write("Enter n: ");
            int countOfNumbers = int.Parse(Console.ReadLine());

            Console.Write("Enter k: ");
            int removeIndex = int.Parse(Console.ReadLine());

            string separatorLine = Environment.NewLine + new string('-', 30) + Environment.NewLine;
            Console.WriteLine(separatorLine);

            int lastRemainingNumber = JosephusTask(countOfNumbers, removeIndex);
            Console.WriteLine($"Last remaining number: {lastRemainingNumber}");
        }

        private static int JosephusTask(int n, int k)
        {
            Queue<int> queue = FillQueue(1, n);

            int queueRemoveIndex = k - 1;
            Queue<int> josephusCycleResult = JosephusMethod(queue, queueRemoveIndex);

            string lastRemainingNumbers = String.Join(", ", josephusCycleResult);
            Console.WriteLine($"Last remaining numbers: {lastRemainingNumbers}");

            int lastRemainingNumber = JosephusMethod(josephusCycleResult, queueRemoveIndex, 1).Dequeue();

            return lastRemainingNumber;
        }

        private static Queue<int> JosephusMethod(Queue<int> queue, int iterationCycleOfRemoveIndex, int countOfRemainingElements = 0)
        {
            countOfRemainingElements = countOfRemainingElements == 0 ? iterationCycleOfRemoveIndex : countOfRemainingElements;

            var newQueue = new Queue<int>(queue);

            while (newQueue.Count != countOfRemainingElements)
            {
                for (int index = 0; index < iterationCycleOfRemoveIndex; index++)
                {
                    newQueue.Enqueue(newQueue.Dequeue());
                }

                newQueue.Dequeue();
            }

            return newQueue;
        }

        private static Queue<int> FillQueue(int minNumber, int maxNumber)
        {
            Queue<int> queue = new Queue<int>();

            for (int number = minNumber; number <= maxNumber; number++)
            {
                queue.Enqueue(number);
            }

            return queue;
        }
    }
}
