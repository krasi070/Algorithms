namespace _02.ProcessorScheduling
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ProcessorScheduling
    {
        public static void Main()
        {
            int numberOfTasks = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < numberOfTasks; i++)
            {
                int[] taskArgs = Console.ReadLine()
                    .Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Task currTask = new Task(i + 1, taskArgs[0], taskArgs[1]);
                tasks.Add(currTask);
            }

            IList<Task> result = ExecuteTasks(tasks);
            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", result.Select(t => t.Id))}");
            Console.WriteLine($"Total value: {result.Sum(v => v.Value)}");
        }

        private static IList<Task> ExecuteTasks(IList<Task> tasks)
        {
            IList<Task> result = new List<Task>();
            int lastDeadline = tasks.Max(t => t.Deadline);
            int[] deadlines = new int[lastDeadline];

            List<Task> sortedTasks = tasks
                .OrderByDescending(t => t.Value)
                .ToList();

            int step = 1;
            int index = 0;
            while (step <= lastDeadline)
            {
                Task currTask = sortedTasks[index];
                for (int i = 0; i < lastDeadline; i++)
                {
                    deadlines[i] = 1;
                }

                foreach (var task in result)
                {
                    deadlines[task.Deadline - 1]--;
                }

                bool executable = false;
                for (int i = currTask.Deadline - 1; i >= 0; i--)
                {
                    if (deadlines[i] > 0)
                    {
                        executable = true;
                        break;
                    }
                }

                if (executable)
                {
                    result.Add(currTask);
                    sortedTasks.Remove(currTask);
                    index = 0;
                    step++;
                }
                else
                {
                    index++;
                }
            }

            return result
                .OrderBy(t => t.Deadline)
                .ToList();
        }
    }
}