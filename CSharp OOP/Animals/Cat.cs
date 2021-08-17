using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string food) : base(name, food)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ExplainSelf());
            result.Append("MEEOW");

            return result.ToString();
        }
    }
}
