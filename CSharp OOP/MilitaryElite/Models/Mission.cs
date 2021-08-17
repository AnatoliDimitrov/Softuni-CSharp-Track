using MilitaryElite.Contracts;
using MilitaryElite.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = StateTryParse(state);
        }
        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        private State StateTryParse(string stateStr)
        {
            State state;

            bool parsed = Enum.TryParse(stateStr, out state);

            if (!parsed)
            {
                throw new ArgumentException();
            }

            return state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }
    }
}
