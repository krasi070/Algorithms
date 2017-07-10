namespace _06.ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;

    public class ConnectedAreasInMatrix
    {
        private const char Wall = '*';
        private const char Visited = 'v';

        private static SortedSet<Area> areas = new SortedSet<Area>();

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(rows, cols);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    CreateArea(matrix, i, j);
                }
            }

            int counter = 1;
            Console.WriteLine($"Total areas found: {areas.Count}");
            foreach (var area in areas)
            {
                Console.WriteLine($"Area #{counter} at ({area.StartX}, {area.StartY}), size: {area.Size}");
                counter++;
            }
        }

        private static void CreateArea(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == Wall || matrix[row, col] == Visited)
            {
                return;
            }

            Area area = new Area(row, col);
            FillArea(matrix, row, col, area);
            areas.Add(area);
        }

        private static void FillArea(char[,] matrix, int row, int col, Area area)
        {
            if (IsInvalidPlace(matrix, row, col))
            {
                return;
            }

            matrix[row, col] = Visited;
            area.Size++;

            FillArea(matrix, row - 1, col, area);
            FillArea(matrix, row + 1, col, area);
            FillArea(matrix, row, col + 1, area);
            FillArea(matrix, row, col - 1, area);
        }

        private static bool IsInvalidPlace(char[,] matrix, int row, int col)
        {
            return row < 0 ||
                row >= matrix.GetLength(0) ||
                col < 0 ||
                col >= matrix.GetLength(1) ||
                matrix[row, col] == Wall ||
                matrix[row, col] == Visited;
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            return matrix;
        }
    }

    public class Area : IComparable<Area>
    {
        public Area(int startX, int startY)
        {
            this.StartX = startX;
            this.StartY = startY;
            this.Size = 0;
        }

        public int StartX { get; set; }

        public int StartY { get; set; }

        public int Size { get; set; } 

        public int CompareTo(Area other)
        {
            if (other.Size == this.Size)
            {
                if (other.StartX == this.StartX)
                {
                    return this.StartY.CompareTo(other.StartY);
                }

                return this.StartX.CompareTo(other.StartX);
            }

            return other.Size.CompareTo(this.Size);
        }
    }
}