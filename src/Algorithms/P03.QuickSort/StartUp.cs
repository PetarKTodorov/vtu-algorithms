namespace P03.QuickSort
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int[] array = new int[] { 6, 2, 9, 3, 7, 1, 8, 5, 4 };

            int leftBorder = 0;
            int rightBorder = array.Length - 1;

            QuickSort(array, leftBorder, rightBorder);

            Console.WriteLine(String.Join(", ", array));
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Sorts an array by using the quick sort algorithm
        /// </summary>
        /// <param name="array">The array that should be sorted</param>
        /// <param name="leftBorder">The left border of the subarray that is being sorted</param>
        /// <param name="rightBorder">The right border of the subarray that is being sorted</param>
        public static void QuickSort(int[] array, int leftBorder, int rightBorder)
        {
            int i = leftBorder, j = rightBorder;
            int middleElementValue = array[(leftBorder + rightBorder) / 2];

            while (i <= j)
            {
                Console.WriteLine($"Mid element: {middleElementValue}");
                // Find an element smaller than the middle element value on the left
                while (array[i] < middleElementValue)
                {
                    Console.WriteLine($"{String.Join(' ', array)} \t {array[i]} \t i={i + 1} \t j={j + 1}");
                    i++;
                }
                // Find an element bigger than the middle element value on the right
                while (array[j] > middleElementValue)
                {
                    Console.WriteLine($"{String.Join(' ', array)} \t {array[j]} \t j={j + 1} \t i={i + 1}");
                    j--;
                }


                Console.WriteLine($"{String.Join(' ', array)} \t {array[i]} <-> {array[j]} \t i={i + 1} \t j={j + 1}");

                if (i <= j)
                {
                    // Swap the two elements
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            };

            if (leftBorder < j) QuickSort(array, leftBorder, j); // Call quick sort for the left subarray
            if (i < rightBorder) QuickSort(array, i, rightBorder); // Call quick sort for the right subarray
        }
    }
}
