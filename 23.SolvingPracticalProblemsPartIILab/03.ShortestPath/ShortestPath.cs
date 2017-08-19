namespace _03.ShortestPath
{
    using System;
    using System.Collections.Generic;

    public class ShortestPath
    {
        private static List<string> paths = new List<string>();

        public static void Main()
        {
            string path = Console.ReadLine();

            GenerateAllPossibleMissingSymbols(path.ToCharArray());
            Console.WriteLine(paths.Count);
            Console.WriteLine(string.Join(Environment.NewLine, paths));
        }

        private static void GenerateAllPossibleMissingSymbols(char[] path, int index = 0)
        {
            if (index >= path.Length)
            {
                paths.Add(string.Join("", path));
            }
            else
            {
                if (path[index] == '*')
                {
                    string symbols = "LRS";
                    for (int i = 0; i < symbols.Length; i++)
                    {
                        path[index] = symbols[i];
                        GenerateAllPossibleMissingSymbols(path, index + 1);
                    }

                    path[index] = '*';
                }
                else
                {
                    GenerateAllPossibleMissingSymbols(path, index + 1);
                }              
            }
        }
    }
}