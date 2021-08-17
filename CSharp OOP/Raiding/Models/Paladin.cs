namespace Raiding.Models
{
    public class Paladin : Hero
    {
        public Paladin(string name) : base(name)
        {
            this.Power = 100;
        }

        public override string CastAbility()
        {
            return $"{nameof(Paladin)} - {this.Name} healed for {this.Power}";
        }
    }
}
