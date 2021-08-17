namespace BorderControl
{
    public class Robot : Visitor, IRobot
    {
        public Robot(string model, string id) : base(id)
        {
            this.Model = model;
        }

        public string Model { get; private set; }
    }
}
