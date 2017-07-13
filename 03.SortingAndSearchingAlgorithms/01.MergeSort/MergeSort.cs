namespace _01.MergeSort
{
    using System;

    public class MergeSort<T> where T : IComparable
    {
        private static T[] aux;

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int mid = (right + left) / 2;
            Sort(arr, left, mid);
            Sort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }

        private static void Merge(T[] arr, int left, int mid, int right)
        {
            if (arr[mid].CompareTo(arr[mid + 1]) < 0)
            {
                return;
            }

            for (int index = left; index <= right; index++)
            {
                aux[index] = arr[index];
            }

            int i = left;
            int j = mid + 1;
            for (int k = left; k <= right; k++)
            {
                if (i > mid)
                {
                    arr[k] = aux[j++];
                }
                else if (j > right)
                {
                    arr[k] = aux[i++];
                }
                else if (aux[i].CompareTo(aux[j]) < 0)
                {
                    arr[k] = aux[i++];
                }
                else
                {
                    arr[k] = aux[j++];
                }
            }
        }
    }
}