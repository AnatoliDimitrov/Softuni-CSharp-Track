namespace CommandPattern.Models
{
    public class Product
    {
        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public void IncreasePrice(int amount)
        {
            this.Price += amount;

            System.Console.WriteLine($"The price for {this.Name} has been increased by {amount}$");
        }

        public void DecreasePrice(int amount)
        {
            if (amount < this.Price)
            {
                this.Price -= amount;

                System.Console.WriteLine($"The price for {this.Name} has been decreased by {amount}$");
            }
        }

        public override string ToString()
        {
            return $"Current Price for the {this.Name} prodict is {this.Price}$";
        }
    }
}
