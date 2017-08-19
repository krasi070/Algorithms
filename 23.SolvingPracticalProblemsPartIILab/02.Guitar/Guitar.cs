namespace _02.Guitar
{
    using System;
    using System.Linq;

    public class Guitar
    {
        public static void Main()
        {
            int[] volumeChanges = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int startingVolume = int.Parse(Console.ReadLine());
            int maxVolume = int.Parse(Console.ReadLine());
            bool[,] matrix = new bool[volumeChanges.Length + 1, maxVolume + 1];

            matrix[0, startingVolume] = true;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                int volumeChange = volumeChanges[i - 1];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i - 1, j] == true)
                    {
                        if (j - volumeChange >= 0)
                        {
                            matrix[i, j - volumeChange] = true;
                        }

                        if (j + volumeChange <= maxVolume)
                        {
                            matrix[i, j + volumeChange] = true;
                        }
                    }
                }
            }

            int maxVolumeForLastSong = -1;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[volumeChanges.Length, i])
                {
                    maxVolumeForLastSong = i;
                }
            }

            Console.WriteLine(maxVolumeForLastSong);
        }
    }
}