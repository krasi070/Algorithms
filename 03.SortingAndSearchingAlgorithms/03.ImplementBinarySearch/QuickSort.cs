namespace _03.ImplementBinarySearch
{
    using System;

    public class QuickSort<T> where T : IComparable
    {
        public static void Sort(T[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivot = Partition(arr, left, right);
            Sort(arr, left, pivot - 1);
            Sort(arr, pivot + 1, right);
        }

        private static int Partition(T[] arr, int left, int right)
        {
            if (left >= right)
            {
                return left;
            }

            int i = left;
            int j = right + 1;
            while (true)
            {
                while (arr[++i].CompareTo(arr[left]) < 0)
                {
                    if (i == right)
                    {
                        break;
                    }
                }

                while (arr[left].CompareTo(arr[--j]) < 0)
                {
                    if (j == left)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }

                T temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            T temp2 = arr[left];
            arr[left] = arr[j];
            arr[j] = temp2;

            return j;
        }
    }
}