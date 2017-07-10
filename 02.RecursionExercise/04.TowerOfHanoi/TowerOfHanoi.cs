﻿namespace _04.TowerOfHanoi
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class TowerOfHanoi
    {
        private static int stepsTaken = 0;
        private static Stack<int> source;
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();

        public static void Main()
        {
            int numberOfDisks = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
            PrintInfo();
            MoveDisks(numberOfDisks, source, spare, destination);
        }

        private static void MoveDisks(int numberOfDisks, Stack<int> source, Stack<int> spare, Stack<int> destination)
        {
            if (numberOfDisks == 1)
            {
                stepsTaken++;
                int movedDisk = source.Pop();
                destination.Push(movedDisk);
                Console.WriteLine($"Step #{stepsTaken}: Moved disk {movedDisk}");
                PrintInfo();
            }
            else
            {
                MoveDisks(numberOfDisks - 1, source, destination, spare);
                MoveDisks(1, source, spare, destination);
                MoveDisks(numberOfDisks - 1, spare, source, destination);
            }
        }

        private static void PrintInfo()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }
    }
}