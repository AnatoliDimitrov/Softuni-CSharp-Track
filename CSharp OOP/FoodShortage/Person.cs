namespace FoodShortage
{
    public abstract class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; }

        public int Age { get; }
    }
}
