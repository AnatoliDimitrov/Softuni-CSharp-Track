namespace Animals
{
    public class Kitten : Cat
    {
        private const string FEMALE_GENDER = "Female";
        public Kitten(string name, int age) : base(name, age, FEMALE_GENDER)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
