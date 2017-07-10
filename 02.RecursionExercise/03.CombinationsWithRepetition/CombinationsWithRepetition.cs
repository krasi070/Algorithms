namespace _03.CombinationsWithRepetition
{
    using System;

    public class CombinationsWithRepetition
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            GenerateCombinations(new int[k], n);
        }

        private static void GenerateCombinations(int[] arr, int n, int currIndex = 0, int border = 1)
        {
            if (currIndex == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = border; i <= n; i++)
                {
                    arr[currIndex] = i;
                    GenerateCombinations(arr, n, currIndex + 1, i);
                }
            }
        }
    }
}