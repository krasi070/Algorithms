namespace _01.Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Knapsack
    {
        public static void Main()
        {
            int capacity = int.Parse(Console.ReadLine());
            List<Item> items = new List<Item>();
            string currLine = Console.ReadLine();
            while (currLine.ToLower() != "end")
            {
                string[] args = currLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Item currItem = new Item(args[0], int.Parse(args[1]), int.Parse(args[2]));
                items.Add(currItem);

                currLine = Console.ReadLine();
            }

            List<Item> itemsInKnapsack = FillKnapsack(items, capacity);
            Console.WriteLine($"Total Weight: {itemsInKnapsack.Sum(i => i.Weight)}");
            Console.WriteLine($"Total Value: {itemsInKnapsack.Sum(i => i.Value)}");
            Console.WriteLine(string.Join(Environment.NewLine, itemsInKnapsack.Select(i => i.Name)));
        }

        private static List<Item> FillKnapsack(IList<Item> items, int capacity)
        {
            int[,] matrix = new int[items.Count + 1, capacity + 1];
            bool[,] included = new bool[items.Count + 1, capacity + 1];
            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                int matrixRow = itemIndex + 1;
                for (int currCapacity = 1; currCapacity < matrix.GetLength(1); currCapacity++)
                {
                    int includeWeight = 0;
                    int excludeWeight = matrix[matrixRow - 1, currCapacity];
                    if (items[itemIndex].Weight <= currCapacity)
                    {
                        includeWeight = items[itemIndex].Value + matrix[matrixRow - 1, currCapacity - items[itemIndex].Weight];
                    }

                    if (includeWeight > excludeWeight)
                    {
                        included[matrixRow, currCapacity] = true;
                        matrix[matrixRow, currCapacity] = includeWeight;
                    }
                    else
                    {
                        matrix[matrixRow, currCapacity] = excludeWeight;
                    }
                }
            }
            
            return ReconstructItems(items, matrix, included);
        }

        private static List<Item> ReconstructItems(IList<Item> items, int[,] matrix, bool[,] included)
        {
            List<Item> itemsInKnapsack = new List<Item>();
            int row = items.Count;
            int col = matrix.GetLength(1) - 1;
            while (row >= 0 && col >= 0)
            {
                if (included[row, col])
                {
                    Item item = items[row - 1];
                    itemsInKnapsack.Add(item);
                    col -= item.Weight;
                }

                row--;
            }

            itemsInKnapsack.Reverse();
            
            return itemsInKnapsack;
        }
    }
}