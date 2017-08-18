namespace _03.Lumber
{
    public class Log
    {
        public Log(int x1, int y1, int x2, int y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        public bool Intersects(Log other)
        {
            bool horizontalIntersects = this.X1 <= other.X2 && this.X2 >= other.X1;
            bool verticalIntersects = this.Y1 >= other.Y2 && this.Y2 <= other.Y1;

            return horizontalIntersects && verticalIntersects;
        }
    }
}