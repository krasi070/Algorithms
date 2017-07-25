namespace _01.FractionalKnapsackProblem
{
    public class Item
    {
        public Item(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price { get; private set; }
        
        public double Weight { get; private set; }
        
        public double PricePerKg
        {
            get
            {
                return this.Price / this.Weight;
            }
        } 
    }
}