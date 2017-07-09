namespace _01.RecursiveArray
{
    using System;
    using System.Linq;

    public class RecursiveArray
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(SumArray(arr));
        }

        private static int SumArray(int[] arr, int index = 0)
        {
            if (index == arr.Length - 1)
            {
                return arr[index];
            }

            return arr[index] + SumArray(arr, index + 1);
        }
    }
}