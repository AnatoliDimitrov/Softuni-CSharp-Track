using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<IPrivate> privates; 
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates
        {
            get
            {
                return (IReadOnlyCollection<IPrivate>)privates;
            }
        }

        public void AddPrivate(IPrivate _private)
        {
            privates.Add(_private);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{base.ToString()}");
            result.AppendLine($"Privates:");

            foreach (var item in this.privates)
            {
                result.AppendLine($"  {item.ToString()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
