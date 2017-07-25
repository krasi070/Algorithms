namespace _01.IterativePermutationsWithoutRepetitions
{
    using System;
    using System.Linq;

    public class IterativePermutationsWithoutRepetitions
    {
        public static void Main()
        {
            string[] arr = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            PrintPermutations(arr);
        }

        private static void PrintPermutations(string[] arr)
        {
            int[] p = new int[arr.Length + 1];
            for (int index = 0; index < p.Length; index++)
            {
                p[index] = index;
            }

            Console.WriteLine(string.Join(" ", arr));
            int i = 1;
            int j = 0;
            while (i < arr.Length)
            {
                p[i]--;
                j = i % 2 * p[i];
                Swap(arr, i, j);
                Console.WriteLine(string.Join(" ", arr));
                i = 1;
                while (p[i] == 0)
                {
                    p[i] = i;
                    i++;
                }
            }
        }

        private static void Swap(string[] arr, int i, int j)
        {
            string temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}