namespace _02.LongestZigzagSubsequence
{
    using System;
    using System.Linq;

    public class LongestZigzagSubsequence
    {
        private static int[] memoBigger;
        private static int[] memoSmaller;
        private static int[] nextBigger;
        private static int[] nextSmaller;

        public static void Main()
        {
            int[] sequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            memoBigger = new int[sequence.Length];
            memoSmaller = new int[sequence.Length];
            nextBigger = new int[sequence.Length];
            nextSmaller = new int[sequence.Length];

            for (int i = 0; i < sequence.Length; i++)
            {
                LongestZigzagSequence(sequence, i, true);
                LongestZigzagSequence(sequence, i, false);
            }

            PrintLongestZigzagSequence(sequence);
        }

        private static int LongestZigzagSequence(int[] sequence, int index = 0, bool bigger = true)
        {
            if (bigger && memoBigger[index] != 0)
            {
                return memoBigger[index];
            }
            else if (!bigger && memoSmaller[index] != 0)
            {
                return memoSmaller[index];
            }

            int maxLength = 1;
            int nextIndex = -1;
            for (int i = index + 1; i < sequence.Length; i++)
            {
                if ((bigger && sequence[index] < sequence[i]) ||
                    (!bigger && sequence[index] > sequence[i]))
                {
                    int length = LongestZigzagSequence(sequence, i, !bigger);
                    if (length >= maxLength)
                    {
                        maxLength = length + 1;
                        nextIndex = i;
                    }
                }
            }

            if (bigger)
            {
                nextBigger[index] = nextIndex;
                memoBigger[index] = maxLength;

                return memoBigger[index];
            }
            else
            {
                nextSmaller[index] = nextIndex;
                memoSmaller[index] = maxLength;

                return memoSmaller[index];
            }
        }

        private static void PrintLongestZigzagSequence(int[] sequnce)
        {
            var pair = GetStartIndex();
            bool bigger = pair.Item1;
            int index = pair.Item2;

            while (index != -1)
            {
                Console.Write(sequnce[index] + " ");
                if (bigger)
                {
                    index = nextBigger[index];
                }
                else
                {
                    index = nextSmaller[index];
                }

                bigger = !bigger;
            }

            Console.WriteLine();
        }

        private static Tuple<bool, int> GetStartIndex()
        {
            int bigIndex = 0;
            for (int i = 1; i < memoBigger.Length; i++)
            {
                if (memoBigger[bigIndex] < memoBigger[i])
                {
                    bigIndex = i;
                }
            }

            int smallIndex = 0;
            for (int i = 1; i < memoSmaller.Length; i++)
            {
                if (memoSmaller[smallIndex] < memoSmaller[i])
                {
                    smallIndex = i;
                }
            }

            if (memoBigger[bigIndex] > memoSmaller[smallIndex])
            {
                return new Tuple<bool, int>(true, bigIndex);
            }
            else if (memoBigger[bigIndex] == memoSmaller[smallIndex])
            {
                return bigIndex < smallIndex ? new Tuple<bool, int>(true, bigIndex) : new Tuple<bool, int>(false, smallIndex);
            }
            else
            {
                return new Tuple<bool, int>(false, smallIndex);
            }
        }
    }
}