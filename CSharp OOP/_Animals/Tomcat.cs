namespace Animals
{
    public class Tomcat : Cat
    {
        private const string MALE_GENDER = "MAle";
        public Tomcat(string name, int age) : base(name, age, MALE_GENDER)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
