namespace _03.InversionCount
{
    using System;

    public class MergeSort<T> where T : IComparable
    {
        private static T[] aux;

        public static int Sort(T[] arr)
        {
            aux = new T[arr.Length];
            return Sort(arr, 0, arr.Length - 1);
        }

        private static int Sort(T[] arr, int left, int right)
        {
            int inversionCount = 0;
            if (left < right)
            {
                int mid = (right + left) / 2;
                inversionCount += Sort(arr, left, mid);
                inversionCount += Sort(arr, mid + 1, right);
                inversionCount += Merge(arr, left, mid, right);
            }

            return inversionCount;
        }

        private static int Merge(T[] arr, int left, int mid, int right)
        {
            int inversionCount = 0;
            if (arr[mid].CompareTo(arr[mid + 1]) < 0)
            {
                return inversionCount;
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
                    inversionCount += (mid - 1);
                }
                else if (aux[i].CompareTo(aux[j]) < 0)
                {
                    arr[k] = aux[i++];
                }
                else
                {
                    arr[k] = aux[j++];
                    inversionCount += (mid - 1);
                }
            }

            return inversionCount;
        }
    }
}