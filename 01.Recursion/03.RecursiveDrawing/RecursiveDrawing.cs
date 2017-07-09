namespace _03.RecursiveDrawing
{
    using System;

    public class RecursiveDrawing
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            Draw(size);
        }

        private static void Draw(int size)
        {
            if (size < 1)
            {
                return;
            }

            Console.WriteLine(new string('*', size));
            Draw(size - 1);
            Console.WriteLine(new string('#', size));
        }
    }
}