namespace _04.BestLecturesSchedule
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class BestLecturesSchedule
    {
        public static void Main()
        {
            int numberOfLectures = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            Lecture[] lectures = new Lecture[numberOfLectures];
            for (int i = 0; i < numberOfLectures; i++)
            {
                string[] lectureArgs = Console.ReadLine()
                    .Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                lectures[i] = new Lecture(lectureArgs[0], int.Parse(lectureArgs[1]), int.Parse(lectureArgs[2]));
            }

            Lecture[] presentableLectures = GetMaxPresentableLectures(lectures);
            Console.WriteLine($"Lectures ({presentableLectures.Length}):");
            Console.WriteLine(string.Join<Lecture>("\n", presentableLectures));
        }

        private static Lecture[] GetMaxPresentableLectures(Lecture[] lectures)
        {
            List<Lecture> result = new List<Lecture>();
            Lecture[] sortedLectures = lectures
                .OrderBy(l => l.Finish)
                .ToArray();

            for (int i = 0; i < sortedLectures.Length; i++)
            {
                if (result.Count == 0 || result[result.Count - 1].Finish < sortedLectures[i].Start)
                {
                    result.Add(sortedLectures[i]);
                }
            }

            return result.ToArray();
        }
    }
}