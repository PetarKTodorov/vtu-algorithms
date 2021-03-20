namespace P01.BinaryReflectedGrayCode
{
    using System;
    using System.Text;

    public static class Engine
    {
        private static StringBuilder stringBuilder = new StringBuilder();

        public static void Run()
        {
            Console.Write("Please enter a number: ");
            int depth = int.Parse(Console.ReadLine());

            Generate(depth);
        }

        private static void Generate(int depth)
        {
            RecursiveGenerator(1, string.Empty, depth);

            Console.WriteLine(stringBuilder.ToString());
        }

        private static void RecursiveGenerator(int number, string prevValue, int limit)
        {
            if (number > limit)
            {
                return;
            }

            prevValue += string.Empty + number + string.Empty + prevValue;

            stringBuilder.AppendLine(prevValue.Trim());
            number++;

            RecursiveGenerator(number, prevValue, limit);
        }
    }
}
