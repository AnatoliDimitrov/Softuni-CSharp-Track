using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private double statsCount = 5.0;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get { return name; }
            private set { name = GeneratorValidator.ValidateName(value); }
        }

        public int Endurance
        {
            get { return endurance; }
            private set { endurance = GeneratorValidator.ValidateStat(value, nameof(this.Endurance)); }
        }

        public int Sprint
        {
            get { return sprint; }
            private set { sprint = GeneratorValidator.ValidateStat(value, nameof(this.Sprint)); }
        }

        public int Dribble
        {
            get { return dribble; }
            private set { dribble = GeneratorValidator.ValidateStat(value, nameof(this.Dribble)); }
        }

        public int Passing
        {
            get { return passing; }
            private set { passing = GeneratorValidator.ValidateStat(value, nameof(this.Passing)); }
        }

        public int Shooting
        {
            get { return shooting; }
            private set { shooting = GeneratorValidator.ValidateStat(value, nameof(this.Shooting)); }
        }

        public double OverallSkillLevel
        {
            get { return GetAverageStat(); }
        }

        private double GetAverageStat()
        {
            return Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / statsCount);
        }
    }
}
