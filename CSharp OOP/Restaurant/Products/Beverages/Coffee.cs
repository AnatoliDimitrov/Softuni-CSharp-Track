namespace Restaurant.Products.Beverages
{
    public class Coffee : HotBeverage
    {

        private const double CoffeeMilliliters = 50;

        private const decimal CoffeePrice = 3.5m;
        public Coffee(string name, double caffein) : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffein;
        }

        public double Caffeine { get; set; }
    }
}
