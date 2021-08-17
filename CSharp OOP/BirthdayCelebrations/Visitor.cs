namespace BirthdayCelebrations
{
    public abstract class Visitor
    {
        public Visitor(string id)
        {
            this.Id = id;
        }
        public string Id { get; private set; }
    }
}
