namespace _03.ImplementBinarySearch
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
            int element = int.Parse(Console.ReadLine());
            QuickSort<int>.Sort(arr);
            Console.WriteLine(BinarySearch(arr, element));
        }

        private static int BinarySearch(int[] arr, int target)
        {
            return BinarySearch(arr, target, 0, arr.Length - 1);
        }

        private static int BinarySearch(int[] arr, int target, int left, int right)
        {
            int mid = (left + right) / 2;
            if (arr[mid] == target)
            {
                return mid;
            }
            else if (arr[mid] > target)
            {
                return BinarySearch(arr, target, left, mid - 1);
            }
            else if (arr[mid] < target)
            {
                return BinarySearch(arr, target, mid + 1, right);
            }

            return -1;
        }
    }
}