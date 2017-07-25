namespace _01.FractionalKnapsackProblem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class FractionalKnapsackProblem
    {
        public static void Main()
        {
            double capacity = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            double numberOfItems = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            List<Item> items = new List<Item>();
            for (int i = 0; i < numberOfItems; i++)
            {
                double[] itemArgs = Console.ReadLine()
                    .Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                Item currItem = new Item(itemArgs[0], itemArgs[1]);
                items.Add(currItem);
            }

            Dictionary<Item, double> knapsack = PlaceItemsInKnapsack(items, capacity);
            foreach (var item in knapsack)
            {
                if (item.Value == 100)
                {
                    Console.WriteLine($"Take 100% of item with price {item.Key.Price:F2} and weight {item.Key.Weight:F2}");
                }
                else
                {
                    Console.WriteLine($"Take {item.Value:F2}% of item with price {item.Key.Price:F2} and weight {item.Key.Weight:F2}");
                }
            }

            double totalPrice = knapsack.Sum(i => i.Key.Price * (i.Value * 0.01));
            Console.WriteLine($"Total price: {totalPrice:F2}");
        }

        private static Dictionary<Item, double> PlaceItemsInKnapsack(IList<Item> items, double capacity)
        {
            Dictionary<Item, double> result = new Dictionary<Item, double>();

            var sortedItems = items
                .OrderByDescending(i => i.PricePerKg)
                .ToList();

            double currWeight = 0;
            for (int i = 0; i < sortedItems.Count; i++)
            {
                var currItem = sortedItems[i];
                double available = capacity - currWeight;
                if (currItem.Weight > available)
                {
                    double percentage = available / currItem.Weight * 100;
                    result.Add(currItem, percentage);
                    break;
                }
                else
                {
                    result.Add(currItem, 100);
                    currWeight += currItem.Weight;
                }
            }

            return result;
        }
    }
}