namespace P11.SelectionSort
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int[] array = new int[] { 2, 7, 9, 5, 0, 4, 9, -4, 1, 0 };

            //SelectionSort(array);
            //PrintArray("SelectionSort", array);

            //BubbleSort(array);
            //PrintArray("BubbleSort", array);

            //InsertationSort(array);
            //PrintArray("InsertationSort", array);
        }

        private static void InsertationSort(int[] array)
        {
            // O(n^2)

            int N = array.Length;
            int i = 0;

            for (int index = 1; index < N; index++)
            {
                int currentValue = array[index];

                for (i = index; i > 0 && array[i-1] > currentValue; i--)
                {
                    array[i] = array[i-1];
                }

                array[i] = currentValue;
            }
        }

        private static void BubbleSort(int[] array)
        {
            // O(n^2)

            int N = array.Length;

            for (int index = 0; index < N-1; index++) {
                for (int i = N - 1; i > index; i--)
                {
                    int prevIndex = i - 1;
                    if (array[prevIndex] > array[i])
                    {
                        Swap(array, prevIndex, i);
                    }
                }
            }
        }

        private static void SelectionSort(int[] array)
        {
            // O(n^2)

            int N = array.Length;

            for (int index = 0; index < N - 1; index++)
            {
                int minNumber = array[index];
                int minIndex = index;

                for (int i = index + 1; i < N; i++)
                {
                    if (array[i] < minNumber)
                    {
                        minNumber = array[i];
                        minIndex = i;
                    }
                }

                if (minIndex != index)
                {
                    Swap(array, index, minIndex);
                }
            }
        }

        private static void Swap(int[] array, int fisrtArrayIndex, int secondArrayIndex)
        {
            int temp = array[fisrtArrayIndex];
            array[fisrtArrayIndex] = array[secondArrayIndex];
            array[secondArrayIndex] = temp;
        }

        private static void PrintArray(string typeArray, int[] array)
        {
            string result = $"{typeArray}: {String.Join(", ", array)}";

            Console.WriteLine(result);
        }
    }
}
