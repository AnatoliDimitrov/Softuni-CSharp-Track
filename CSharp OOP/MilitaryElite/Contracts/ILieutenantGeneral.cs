using MilitaryElite.Models;
using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<IPrivate> Privates { get;}

        public void AddPrivate(IPrivate _private);
    }
}
