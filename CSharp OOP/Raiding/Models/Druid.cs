namespace Raiding.Models
{
    public class Druid : Hero
    {
        public Druid(string name) : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility()
        {
            return $"{nameof(Druid)} - {this.Name} healed for {this.Power}";
        }
    }
}
