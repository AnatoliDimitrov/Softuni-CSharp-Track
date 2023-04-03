namespace Raiding.Models
{
    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
            this.Power = 100;
        }

        public Warrior(string name, int age) :this(name)
        {
            this.Age = age;
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set 
            { 
                if (value < 18)
                {
                    value = 18;
                }
                _age = value; 
            }
        }


        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {this.Name} hit for {this.Power} damage";
        }
    }
}
