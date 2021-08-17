using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)missions;

        public void AddMission(Mission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{base.ToString()}");
            result.AppendLine($"Corps: {this.Corps.ToString()}");
            result.AppendLine($"Missions:");

            foreach (var item in this.missions)
            {
                result.AppendLine($"  {item.ToString()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
