namespace _02.ProcessorScheduling
{
    public class Task
    {
        public Task(int id, int value, int deadline)
        {
            this.Id = id;
            this.Value = value;
            this.Deadline = deadline;
        }

        public int Value { get; set; }

        public int Deadline { get; set; }

        public int Id { get; set; }
    }
}