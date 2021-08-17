namespace ExplicitInterfaces
{
    public interface IPerson
    {

        public string Name { get; }

        public int Age { get; }

        public string GetName()
        {
            return $"{this.Name}";
        }
    }
}
