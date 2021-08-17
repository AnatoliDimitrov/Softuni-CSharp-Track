using System.Text;

namespace Animals
{
    class Dog : Animal
    {
        public Dog(string name, string food) : base(name, food)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ExplainSelf());
            result.Append("DJAAF");

            return result.ToString();
        }
    }
}
