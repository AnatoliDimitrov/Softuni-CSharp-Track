namespace FoodShortage
{
    public class Rebel : Person, IRebel, IBuyer
    {
        public Rebel(string name, int age, string group) : base(name, age)
        {
            this.Group = group;
            this.Food = 0;
        }

        public int Food { get; private set; }

        public string Group { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
