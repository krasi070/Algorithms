namespace _02.Search
{
    using System;
    using System.Linq;

    public class Search
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int element = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch(arr, element));
        }

        private static int BinarySearch(int[] arr, int target)
        {
            return BinarySearch(arr, target, 0, arr.Length - 1);
        }

        private static int BinarySearch(int[] arr, int target, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }

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