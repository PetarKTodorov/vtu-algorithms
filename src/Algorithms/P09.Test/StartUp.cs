namespace P09.Test
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Console.Write("Enter start number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            queue.Enqueue(firstNumber);

            while (queue.Count != 0)
            {
                int oldNumber = queue.Dequeue();

                if (oldNumber % 3 == 0)
                {
                    break;
                }

                int newNumber = oldNumber * 2;
                queue.Enqueue(newNumber);

                oldNumber = oldNumber - 1;

                if (oldNumber % 3 == 0)
                {
                    newNumber = oldNumber / 3;
                    queue.Enqueue(newNumber);
                }

                Console.WriteLine("Row " + String.Join(", ", queue));
            }

            Console.WriteLine(String.Join(", ", queue));
        }
    }
}
