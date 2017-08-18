namespace _02.SumTo13
{
    using System;
    using System.Linq;

    public class SumTo13
    {
        public static void Main()
        {
            long[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            for (int i = -1; i < 2; i += 2)
            {
                long a = i * numbers[0];
                for (int j = -1; j < 2; j += 2)
                {
                    long b = j * numbers[1];
                    for (int k = -1; k < 2; k += 2)
                    {
                        long c = k * numbers[2];
                        if (a + b + c == 13)
                        {
                            Console.WriteLine("Yes");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("No");
        }
    }
}