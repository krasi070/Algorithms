namespace _01.StarsInTheCube
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StarsInTheCube
    {
        public static void Main()
        {
            SortedDictionary<char, int> numberOfStarsByLetter = new SortedDictionary<char, int>();
            int numberOfStars = 0;
            int size = int.Parse(Console.ReadLine());
            char[,,] cube = new char[size, size, size];
            for (int depth = 0; depth < size; depth++)
            {
                char[] layer = Console.ReadLine()
                    .Split(new[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                ReadCubeLayer(cube, size, depth, layer);
            }

            for (int row = 1; row < size - 1; row++)
            {
                for (int col = 1; col < size - 1; col++)
                {
                    for (int depth = 1; depth < size - 1; depth++)
                    {
                        if (CheckIfStarExists(cube, row, col, depth, cube[row, col, depth]))
                        {
                            numberOfStars++;
                            if (numberOfStarsByLetter.ContainsKey(cube[row, col, depth]))
                            {
                                numberOfStarsByLetter[cube[row, col, depth]]++;
                            }
                            else
                            {
                                numberOfStarsByLetter[cube[row, col, depth]] = 1;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(numberOfStars);
            foreach (char letter in numberOfStarsByLetter.Keys)
            {
                Console.WriteLine($"{letter} -> {numberOfStarsByLetter[letter]}");
            }
        }

        public static void ReadCubeLayer(char[,,] cube, int size, int depth, char[] layer)
        {
            for (int i = 0; i < layer.Length; i++)
            {
                int row = i / size;
                int col = i % size;
                cube[row, col, depth] = layer[i];
            }
        }

        public static bool CheckIfStarExists(char[,,] cube, int row, int col, int depth, char currLetter)
        {
            return cube[row + 1, col, depth] == currLetter &&
                    cube[row - 1, col, depth] == currLetter &&
                    cube[row, col + 1, depth] == currLetter &&
                    cube[row, col - 1, depth] == currLetter &&
                    cube[row, col, depth + 1] == currLetter &&
                    cube[row, col, depth - 1] == currLetter;
        }
    }
}