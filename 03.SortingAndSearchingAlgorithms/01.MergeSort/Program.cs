namespace _01.MergeSort
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
            MergeSort<int>.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}