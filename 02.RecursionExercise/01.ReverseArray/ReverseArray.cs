namespace _01.ReverseArray
{
    using System;
    using System.Linq;

    public class ReverseArray
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            PrintReversedArray(arr, arr.Length);
        }

        private static void PrintReversedArray(int[] arr, int length)
        {
            if (length <= 0)
            {
                Console.WriteLine();
                return;
            }

            Console.Write(arr[length - 1] + " ");
            PrintReversedArray(arr, length - 1);
        }
    }
}