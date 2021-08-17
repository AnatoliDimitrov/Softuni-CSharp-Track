using MilitaryElite.Contracts;
namespace MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string name, int hours)
        {
            this.Name = name;
            this.HoursWorked = hours;
        }
        public string Name { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.HoursWorked}";
        }
    }
}
