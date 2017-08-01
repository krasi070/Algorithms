namespace _03.DividingPresents
{
    using System;
    using System.Linq;

    public class DividingPresents
    {
        public static void Main()
        {
            int[] presents = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int total = presents.Sum();
            int[] sums = new int[total + 1];
            for (int i = 1; i < sums.Length; i++)
            {
                sums[i] = -1;
            }

            for (int i = 0; i < presents.Length; i++)
            {
                for (int j = total; j >= 0; j--)
                {
                    if (sums[j] >= 0 && sums[j + presents[i]] < 0)
                    {
                        sums[j + presents[i]] = i;
                    }
                }
            }

            int half = total / 2;
            int index = 0;
            for (int i = half; i >= 0; i--)
            {
                if (sums[i] >= 0)
                {
                    index = i;
                    Console.WriteLine($"Difference: {total - 2 * index}");
                    Console.WriteLine($"Alan:{index} Bob:{total - index}");
                    break;
                }
            }

            Console.Write("Alan takes:");
            while (index > 0)
            {
                Console.Write(" " + presents[sums[index]]);
                index -= presents[sums[index]];
            }

            Console.WriteLine();
            Console.WriteLine("Bob takes the rest.");
        }
    }
}