using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkProjects
{
    public class Team
    {
        public string Name { get; private set; }

        public string Creator { get; private set; }

        public List<string> Members { get; set; }

        public Team(string name, string creator)
        {
            this.Name = name;
            this.Creator = creator;
            this.Members = new List<string>();
        }
    }
}
