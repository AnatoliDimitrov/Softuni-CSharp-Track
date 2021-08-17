using Raiding.Contracts;

namespace Raiding.Models
{
    public abstract class Hero : IHero
    {
        public Hero(string name)
        {
            this.Name = name;
        }
        public string Name { get; protected set; }

        public int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
