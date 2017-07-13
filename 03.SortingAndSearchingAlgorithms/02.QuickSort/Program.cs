namespace _02.QuickSort
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            QuickSort<int>.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}