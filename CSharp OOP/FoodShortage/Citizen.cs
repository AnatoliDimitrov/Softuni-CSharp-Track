namespace FoodShortage
{
    class Citizen : Person, ICitizen, IBuyer
    {
        public Citizen(string name, int age, string id, string date) : base(name, age)
        {
            this.Birthdate = date;
            this.Id = id;
            this.Food = 0;
        }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
