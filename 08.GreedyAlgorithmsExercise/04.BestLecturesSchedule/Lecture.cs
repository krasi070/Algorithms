namespace _04.BestLecturesSchedule
{
    public class Lecture
    {
        public Lecture(string name, int start, int finish)
        {
            this.Name = name;
            this.Start = start;
            this.Finish = finish;
        }

        public string Name { get; private set; }

        public int Start { get; private set; }

        public int Finish { get; private set; }

        public override string ToString()
        {
            return $"{this.Start}-{this.Finish} -> {this.Name}";
        }
    }
}